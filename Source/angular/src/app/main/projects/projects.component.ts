import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectsServiceProxy, ProjectsDto, EmployeesServiceProxy} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditProjectsModalComponent } from './create-or-edit-projects-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
//import { Table } from 'primeng/components/table/table';
import { Table } from 'primeng/table';
//import { Paginator } from 'primeng/components/paginator/paginator';
import { Paginator } from 'primeng/paginator';
//import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import Swal from "sweetalert2";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
    templateUrl: './projects.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./projects.component.css']
})
export class ProjectsComponent extends AppComponentBase {

    @ViewChild('createOrEditProjectsModal') createOrEditProjectsModal: CreateOrEditProjectsModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    ProjectNameFilter = '';
    UnitTypeFilter = '';
    SupplierFilter = '';
    data: any;
    employees: any[] = [];
    actualBudget: number;

    private actualBudgetCache: Map<number, Observable<number>> = new Map<number, Observable<number>>();

    constructor(
        injector: Injector,
        private _projectsServiceProxy: ProjectsServiceProxy,
        private _employeesServiceProxy: EmployeesServiceProxy,
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.getProjects();
        this.loadEmployees();
    }

    getProjects(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._projectsServiceProxy.getAll(        
            this.filterText,
            this.ProjectNameFilter,
            '',
            0,
            10
        ).subscribe(result => {
            console.log(result);
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createProjects(): void {
        this.createOrEditProjectsModal.show();
    }

    deleteProjects(projects: ProjectsDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteProjects'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                this._projectsServiceProxy.delete(projects.id)
                    .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                    });
            }
        });
    }

    clearFilter() {
        this.filterText = '';
        this.getProjects();
    }

    loadEmployees() {
        this._employeesServiceProxy.getAll('', '', '', '', '', '', 0, 1000).subscribe(result => {
          console.log(result);
          console.log(result.items);
          this.employees = result.items;
        });
      }

    getEmployeeName(employeeId: number): string {
        const employee = this.employees.find(e => e.employees.id == employeeId);
        return employee.employees.fullName;
      }
     getActualBudget(id: number): Observable<number> {
        if (this.actualBudgetCache.has(id)) {
            return this.actualBudgetCache.get(id);
        } else {
            const budget$ = this._projectsServiceProxy.geBudget(id).pipe(
                catchError(() => of(0)) // Handle errors and return 0 if there's an error
            );
            this.actualBudgetCache.set(id, budget$);
            return budget$;
        }
    }
    
}
