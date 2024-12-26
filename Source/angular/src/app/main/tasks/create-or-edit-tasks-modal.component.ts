import {Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import {
    TasksServiceProxy,
    CreateOrEditTasksDto,
    EmployeesServiceProxy,
    EmployeesDto,
    ProjectsDto,
    ProjectsServiceProxy
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import {Subject} from "@node_modules/rxjs";
import {debounceTime, distinctUntilChanged} from "@node_modules/rxjs/operators";
import * as moment from 'moment';

@Component({
    selector: 'createOrEditTasksModal',
    templateUrl: './create-or-edit-tasks-modal.component.html'
})
export class CreateOrEditTasksModalComponent extends AppComponentBase implements  OnInit{

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    tasks: CreateOrEditTasksDto = new CreateOrEditTasksDto();
    nhanvien: EmployeesDto = new EmployeesDto();
    duan: ProjectsDto = new ProjectsDto();

    listUnit = [];
    seletedUnits = [];
    appUnitInput = new Subject<string>();
    datarenge: Date[] = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
    datarange: Date[] = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
    listEmployeeName: any [] = [];
    listEmployee: any [] = [];
    listProject: any [] = [];
    listProjectName: any [] = [];
    listStage: any = [{text: "Chuẩn bị dự án"}, {text: "Thi công"}, {text: "Nghiệm thu bàn giao"}];
    listStatus: any = [{text: "Đã xong"}, {text: "Đang thực hiện"}];

    constructor(
        injector: Injector,
        private _tasksServiceProxy: TasksServiceProxy,
        private _employeeServiceProxy: EmployeesServiceProxy,
        private _projectsServiceProxy: ProjectsServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit() {
       this.suggestEmployee();
       this.loadEmployees();
       this.loadProjects();
      }


    get isCreateScreen() {
        return !this.tasks.id;
    }

    show(tasksId?: number, projectId?: number): void {
        this.duan.id = projectId;
        if(this.listUnit && this.listUnit.length == 0) {
            this.appUnitInput.next('');
        }
        if (!tasksId) {
            this.tasks = new CreateOrEditTasksDto();
            this.tasks.id = tasksId;
            this.active = true;
            this.suggestEmployee();        
            this.modal.show();
        } else {
            this._tasksServiceProxy.getTasksForEdit(tasksId).subscribe(result => {
                this.tasks = result.tasks;
                this.datarenge[0] = this.tasks.startDate.toJSDate();
                this.datarenge[1] = this.tasks.endDate.toJSDate();
                this.datarange[0] = this.tasks.estimatedStartDate.toJSDate();
                this.datarange[1] = this.tasks.estimatedEndDate.toJSDate();
                this.active = true;
                this.suggestEmployee();
                this.modal.show();
            });
        }
    }
    checkBeforeSave(): void {
        this._tasksServiceProxy.checkBeforeSave(this.duan.id, this.tasks.stage).subscribe(result => {
            if (result == true) {
                this.save();
            } else {
                this.notify.error('', 'Bước trước đó chưa hoàn thành, không thể tạo công việc');
            }
        });
    }

    save(): void {
        this.saving = true;

        this._tasksServiceProxy.createOrEdit(this.prepareData())
         .pipe(finalize(() => { this.saving = false;}))
         .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
         });
        console.log('sucess');
        this._tasksServiceProxy.updateProjectProgress(this.duan.id).subscribe(() => {
            this.notify.info(this.l('UpdateProjectProgress'));
        });
    }

    prepareData(): CreateOrEditTasksDto {
        this.tasks.startDate = this.datarenge[0] ? moment(this.datarenge[0]).toDate() as any : undefined;
        this.tasks.endDate = this.datarenge[1] ? moment(this.datarenge[1]).toDate() as any : undefined;
        this.tasks.estimatedStartDate = this.datarange[0] ? moment(this.datarange[0]).toDate() as any : undefined;
        this.tasks.estimatedEndDate = this.datarange[1] ? moment(this.datarange[1]).toDate() as any : undefined;
        this.tasks.managerEmployeeID = this.getEmployeeId(this.nhanvien.fullName);
        if(this.tasks.projectID == null) {
            this.tasks.projectID = this.duan.id;
        }
        const result = this.copyObject(this.tasks) as CreateOrEditTasksDto;
        
        return result;
    }

    close(): void {
        this.datarenge = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
        this.datarange = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
        this.active = false;
        this.seletedUnits = [];
        this.modal.hide();
    }

    copyObject(data: any) {
        return JSON.parse(JSON.stringify(data));
    }
    suggestEmployee() {
        this._employeeServiceProxy.getAll('', '', '', '', '', '', 0, 100).subscribe(result => {
            this.listEmployeeName = result.items;
        });
    }
    loadEmployees() {
        this._employeeServiceProxy.getAll('', '', '', '', '', '', 0, 1000).subscribe(result => {
          console.log(result);
          console.log(result.items);
          this.listEmployee = result.items;
        });
      }

    getEmployeeId(employeeName: string): number {
        const employee = this.listEmployee.find(e => e.employees.fullName == employeeName);
        return employee.employees.id;
      }

    loadProjects() {
        this._projectsServiceProxy.getAll('', '', '', 0, 1000).subscribe(result => {
          console.log(result);
          console.log(result.items);
          this.listProject = result.items;
        });
      }
    //   getProjectId(projectName: string): number {
    //     const project = this.listProject.find(p => p.projects.projectName == projectName);
    //     return project.projects.id;
    //   }
    //   getProjectName(projectId: number): string {
    //     const project = this.listProject.find(p => p.projects.id == projectId);
    //     return project.projects.projectName;
    //   }

    onUnwantedChange(event: boolean): void {
        this.tasks.unwanted = event ? 1 : 0;
    }
}

