import {Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import {
    ResourcesServiceProxy,
    CreateOrEditResourcesDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import {Subject} from "@node_modules/rxjs";
import {debounceTime, distinctUntilChanged} from "@node_modules/rxjs/operators";


@Component({
    selector: 'createOrEditResourcesModal',
    templateUrl: './create-or-edit-resources-modal.component.html'
})
export class CreateOrEditResourcesModalComponent extends AppComponentBase implements  OnInit{

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    resources: CreateOrEditResourcesDto = new CreateOrEditResourcesDto();
    listUnit = [];
    seletedUnits = [];
    appUnitInput = new Subject<string>();


    constructor(
        injector: Injector,
        private _resourcesServiceProxy: ResourcesServiceProxy
    ) {
        super(injector);
    }

    ngOnInit() {

    }

    get isCreateScreen() {
        return !this.resources.id;
    }

    show(resourcesId?: number): void {
        if(this.listUnit && this.listUnit.length == 0) {
            this.appUnitInput.next('');
        }
        if (!resourcesId) {
            this.resources = new CreateOrEditResourcesDto();
            this.resources.id = resourcesId;
            this.active = true;
            this.modal.show();
        } else {
            this._resourcesServiceProxy.getResourcesForView(resourcesId).subscribe(result => {
                this.resources = result.resources;
                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._resourcesServiceProxy.createOrEdit(this.prepareData())
         .pipe(finalize(() => { this.saving = false;}))
         .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
         });
    }

    prepareData(): CreateOrEditResourcesDto {

        const result = this.copyObject(this.resources) as CreateOrEditResourcesDto;
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
