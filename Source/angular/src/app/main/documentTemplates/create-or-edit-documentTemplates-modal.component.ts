import {Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import {
    DocumentTemplatesServiceProxy,
    CreateOrEditDocumentTemplatesDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import {Subject} from "@node_modules/rxjs";
import {debounceTime, distinctUntilChanged} from "@node_modules/rxjs/operators";


@Component({
    selector: 'createOrEditDocumentTemplatesModal',
    templateUrl: './create-or-edit-documentTemplates-modal.component.html'
})
export class CreateOrEditDocumentTemplatesModalComponent extends AppComponentBase implements  OnInit{

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    documentTemplates: CreateOrEditDocumentTemplatesDto = new CreateOrEditDocumentTemplatesDto();
    listUnit = [];
    seletedUnits = [];
    appUnitInput = new Subject<string>();


    constructor(
        injector: Injector,
        private _documentTemplatesServiceProxy: DocumentTemplatesServiceProxy
    ) {
        super(injector);
    }

    ngOnInit() {

    }

    get isCreateScreen() {
        return !this.documentTemplates.id;
    }

    show(documentTemplatesId?: number): void {
        if(this.listUnit && this.listUnit.length == 0) {
            this.appUnitInput.next('');
        }
        if (!documentTemplatesId) {
            this.documentTemplates = new CreateOrEditDocumentTemplatesDto();
            this.documentTemplates.id = documentTemplatesId;
            this.active = true;
            this.modal.show();
        } else {
            this._documentTemplatesServiceProxy.getDocumentTemplatesForView(documentTemplatesId).subscribe(result => {
                this.documentTemplates = result.documentTemplates;
                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._documentTemplatesServiceProxy.createOrEdit(this.prepareData())
         .pipe(finalize(() => { this.saving = false;}))
         .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
         });
    }

    prepareData(): CreateOrEditDocumentTemplatesDto {

        const result = this.copyObject(this.documentTemplates) as CreateOrEditDocumentTemplatesDto;
        return result;
    }

    close(): void {
        this.active = false;
        this.seletedUnits = [];
        this.modal.hide();
    }

    copyObject(data: any) {
        return JSON.parse(JSON.stringify(data));
    }
}
