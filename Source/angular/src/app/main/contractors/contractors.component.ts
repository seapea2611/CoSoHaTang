import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContractorsServiceProxy, ContractorsDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditContractorsModalComponent } from './create-or-edit-contractors-modal.component';
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
    templateUrl: './contractors.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./contractors.component.css']
})
export class ContractorsComponent extends AppComponentBase {

    @ViewChild('createOrEditContractorsModal') createOrEditContractorsModal: CreateOrEditContractorsModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    ContractorNameFilter = '';
    PhoneFilter = '';
    EmailContractorFilter = '';
    SpecializationFilter = ''
    data: any;

    constructor(
        injector: Injector,
        private _contractorsServiceProxy: ContractorsServiceProxy,
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.getContractors();
    }

    getContractors(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._contractorsServiceProxy.getAll(        
            this.filterText,
            this.ContractorNameFilter,
            this.PhoneFilter,
            this.EmailContractorFilter,
            this.SpecializationFilter,
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

    createContractors(): void {
        this.createOrEditContractorsModal.show();
    }

    deleteContractors(contractors: ContractorsDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteContractors'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                this._contractorsServiceProxy.delete(contractors.id)
                    .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                    });
            }
        });
    }

    clearFilter() {
        this.filterText = '';
        this.getContractors();
    }
}
