import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeesServiceProxy, EmployeesDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditEmployeesModalComponent } from './create-or-edit-employees-modal.component';
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
    templateUrl: './employees.component.html',
    animations: [appModuleAnimation()],
    styleUrls: ['./employees.component.css']
})
export class EmployeesComponent extends AppComponentBase {

    @ViewChild('createOrEditEmployeesModal') createOrEditEmployeesModal: CreateOrEditEmployeesModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    employeeFilter = '';
    roleFilter = '';
    data: any;

    constructor(
        injector: Injector,
        private _employeesServiceProxy: EmployeesServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getEmployees();
    }

    getEmployees(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._employeesServiceProxy.getAll(
            this.filterText,
            this.employeeFilter,
            '',
            '',
            this.roleFilter,
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

    createEmployees(): void {
        this.createOrEditEmployeesModal.show();
    }

    deleteEmployees(employees: EmployeesDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteEmployees'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                this._employeesServiceProxy.delete(employees.id)
                    .subscribe(() => {
                        this.reloadPage();
                        this.notify.success(this.l('SuccessfullyDeleted'));
                    });
            }
        });
    }

    clearFilter() {
        this.filterText = '';
        this.getEmployees();
    }
}
