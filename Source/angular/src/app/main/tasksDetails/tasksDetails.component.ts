import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TasksServiceProxy, TasksDto, ProjectsServiceProxy, EmployeesServiceProxy, TaskResourcesServiceProxy, ResourcesServiceProxy, DocumentsServiceProxy, GetTasksForViewDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
// import { CreateOrEditTasksModalComponent } from './create-or-edit-tasks-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
//import { Table } from 'primeng/components/table/table';
import { Table } from 'primeng/table';
//import { Paginator } from 'primeng/components/paginator/paginator';
import { Paginator } from 'primeng/paginator';
//import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import Swal from "sweetalert2";

@Component({
    templateUrl: './tasksDetails.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./tasksDetails.component.css']
})
export class TasksDetailsComponent extends AppComponentBase {

    // @ViewChild('createOrEditTasksModal') createOrEditTasksModal: CreateOrEditTasksModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    ResourceTypeFilter = '';
    UnitTypeFilter = '';
    SupplierFilter = '';
    data: any;
    projectId: number = 0;
    projects: any[] = [];
   employees: any[] = [];
   tenDuAn: string = '';
   taskId: number =0;
   documents: {record: GetTasksForViewDto[], totalCount: number} = {record: null, totalCount: 0};


    constructor(
        private router: Router,
        private route: ActivatedRoute,
        injector: Injector,
        private _tasksServiceProxy: TasksServiceProxy,
        private _projectsServiceProxy: ProjectsServiceProxy,
        private _employeesServiceProxy: EmployeesServiceProxy,
        private _documentsServiceProxy: DocumentsServiceProxy,
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.route.params.subscribe(params => {
          this.taskId = +params['id']; // Retrieve the projectId from the route parameters
        });
        this.loadProjects();
        this.loadEmployees();
        this.getTasks();
        this.tenDuAn = this.getProjectName(this.projectId);
      }

    getTasks(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._tasksServiceProxy.getTasksForView(this.projectId).subscribe(result => {
            console.log(result);
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    // createTasks(): void {
    //     this.createOrEditTasksModal.show(null,this.projectId);
    // }

    deleteTasks(tasks: TasksDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteTasks'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                this._tasksServiceProxy.delete(tasks.id)
                    .subscribe(() => {
                            this.notify.success(this.l('SuccessfullyDeleted'));
                            console.log('Deleted');
                            this.reloadPage();
                            console.log('Reloaded');
                    });
            }
        });
        this.reloadPage();

    }
    loadProjects() {
        this._projectsServiceProxy.getAll('', '', '', 0, 1000).subscribe(result => {
          console.log(result);
          console.log(result.items);
          this.projects = result.items;
        });
      }
    
      loadEmployees() {
        this._employeesServiceProxy.getAll('', '', '', '', '', '', 0, 1000).subscribe(result => {
          console.log(result);
          console.log(result.items);
          this.employees = result.items;
        });
      }
    
      getProjectName(projectId: number): string {
        const project = this.projects.find(p => p.projects.id == projectId);
        return project.projects.projectName;
      }
    
      getEmployeeName(employeeId: number): string {
        const employee = this.employees.find(e => e.employees.id == employeeId);
        return employee.employees.fullName;
      }

    clearFilter() {
        this.filterText = '';
        this.getTasks();
    }
    getDocument(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._tasksServiceProxy.getTasksByTaskID(this.taskId).subscribe(result => {
            console.log(result);
            this.documents.totalCount = result.totalCount;
            this.documents.record = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }
}
