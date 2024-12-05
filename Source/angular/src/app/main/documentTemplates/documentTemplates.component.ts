import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocumentTemplatesServiceProxy, DocumentTemplatesDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditDocumentTemplatesModalComponent } from './create-or-edit-documentTemplates-modal.component';
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
    templateUrl: './documentTemplates.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./documentTemplates.component.css']
})
export class DocumentTemplatesComponent extends AppComponentBase {

    @ViewChild('createOrEditDocumentTemplatesModal') createOrEditDocumentTemplatesModal: CreateOrEditDocumentTemplatesModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    TemplateNameFilter = '';
    AttachedFileLinkFilter = '';
    AttachedFileNameFilter = '';
    data: any;

    constructor(
        injector: Injector,
        private _documentTemplatesServiceProxy: DocumentTemplatesServiceProxy,
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.getDocumentTemplates();
    }

    getDocumentTemplates(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._documentTemplatesServiceProxy.getAll(        
            this.filterText,
            this.TemplateNameFilter,
            this.AttachedFileLinkFilter,
            this.AttachedFileNameFilter,
            undefined,
            undefined,
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
        console.log(`The value of paginator on reloadPage() is ${this.paginator}`)
        this.paginator.changePage(this.paginator.getPage());
    }

    createDocumentTemplates(): void {
        this.createOrEditDocumentTemplatesModal.show();
    }

    deleteDocumentTemplates(documentTemplates: DocumentTemplatesDto): void {
        Swal.fire({
            title: this.l('MsgConfirmDeleteDocumentTemplates'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: this.l('Yes'),
            cancelButtonText: this.l('No')
        }).then(result => {
            if (result.value) {
                console.log(`the deleted data is: ${JSON.stringify(documentTemplates)}`)
                this._documentTemplatesServiceProxy.delete(documentTemplates.id)
                    .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                    });
            }
        });
    }

    clearFilter() {
        this.filterText = '';
        this.getDocumentTemplates();
    }
}
