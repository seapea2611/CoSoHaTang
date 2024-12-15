import {Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import {
    ProjectsServiceProxy,
    CreateOrEditProjectsDto,
    EmployeesServiceProxy,
    EmployeesDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import {Subject} from "@node_modules/rxjs";
import {debounceTime, distinctUntilChanged} from "@node_modules/rxjs/operators";
import * as moment from 'moment';

@Component({
    selector: 'createOrEditProjectsModal',
    templateUrl: './create-or-edit-projects-modal.component.html'
})
export class CreateOrEditProjectsModalComponent extends AppComponentBase implements  OnInit{

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    projects: CreateOrEditProjectsDto = new CreateOrEditProjectsDto();
    nhanvien: EmployeesDto = new EmployeesDto();

    listUnit = [];
    seletedUnits = [];
    appUnitInput = new Subject<string>();
    datarenge: Date[] = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
    listEmployeeName: any [] = [];
    listEmployee: any [] = [];


    constructor(
        injector: Injector,
        private _projectsServiceProxy: ProjectsServiceProxy,
        private _employeeServiceProxy: EmployeesServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit() {
       this.suggestEmployee();
       this.loadEmployees();
      }


    get isCreateScreen() {
        return !this.projects.id;
    }

    show(projectsId?: number): void {
        if(this.listUnit && this.listUnit.length == 0) {
            this.appUnitInput.next('');
        }
        if (!projectsId) {
            this.projects = new CreateOrEditProjectsDto();
            this.projects.id = projectsId;
            this.active = true;
            this.suggestEmployee();
            this.modal.show();
        } else {
            this._projectsServiceProxy.getProjectsForView(projectsId).subscribe(result => {
                this.projects = result.projects;
                this.datarenge[0] = this.projects.startDate.toJSDate();
                this.datarenge[1] = this.projects.estimatedEndDate.toJSDate();
                this.active = true;
                this.suggestEmployee();
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._projectsServiceProxy.createOrEdit(this.prepareData())
         .pipe(finalize(() => { this.saving = false;}))
         .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
         });
    }

    prepareData(): CreateOrEditProjectsDto {
        this.projects.startDate = this.datarenge[0] ? moment(this.datarenge[0]).toDate() as any : undefined;
        this.projects.estimatedEndDate = this.datarenge[1] ? moment(this.datarenge[1]).toDate() as any : undefined;
        this.projects.responsibleEmployeeID = this.getEmployeeId(this.nhanvien.fullName);
        const result = this.copyObject(this.projects) as CreateOrEditProjectsDto;
        return result;
    }

    close(): void {
        this.datarenge = [moment().startOf('day').toDate(), moment().endOf('day').toDate()];
        this.active = false;
        this.seletedUnits = [];
        this.modal.hide();
    }

    copyObject(data: any) {
        return JSON.parse(JSON.stringify(data));
    }
    suggestEmployee() {
        this._employeeServiceProxy.getAll('', '', '', '', '', '', 0, 100).subscribe(result => {
            console.log(result);
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
}
