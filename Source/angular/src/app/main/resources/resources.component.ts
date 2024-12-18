import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ResourcesServiceProxy, ResourcesDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditResourcesModalComponent } from './create-or-edit-resources-modal.component';
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
    templateUrl: './resources.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./resources.component.css']
})
export class ResourcesComponent extends AppComponentBase {

    @ViewChild('createOrEditResourcesModal') createOrEditResourcesModal: CreateOrEditResourcesModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    ResourceTypeFilter = '';
    UnitTypeFilter = '';
    SupplierFilter = '';
    data: any;

    constructor(
        injector: Injector,
        private _resourcesServiceProxy: ResourcesServiceProxy,
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.getResources();
    }

    getResources(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._resourcesServiceProxy.getAll(        
            this.filterText,
            '',
            this.ResourceTypeFilter,
            '',
            this.UnitTypeFilter,
            this.SupplierFilter,
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

    createResources(): void {
        this.createOrEditResourcesModal.show();
    }

    deleteResources(resources: ResourcesDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteResources'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                this._resourcesServiceProxy.delete(resources.id)
                    .subscribe(() => {
                            this.notify.success(this.l('SuccessfullyDeleted'));
                            this.reloadPage();

                    });
            }
        });
        this.reloadPage();

    }

    clearFilter() {
        this.filterText = '';
        this.getResources();
    }
}
