import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import {
    EmployeesServiceProxy,
    CreateOrEditEmployeesDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Subject } from "@node_modules/rxjs";
import { debounceTime, distinctUntilChanged } from "@node_modules/rxjs/operators";


@Component({
    selector: 'createOrEditEmployeesModal',
    templateUrl: './create-or-edit-employees-modal.component.html'
})
export class CreateOrEditEmployeesModalComponent extends AppComponentBase implements OnInit {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    employees: CreateOrEditEmployeesDto = new CreateOrEditEmployeesDto();
    listUnit = [];
    seletedUnits = [];
    appUnitInput = new Subject<string>();


    constructor(
        injector: Injector,
        private _employeesServiceProxy: EmployeesServiceProxy
    ) {
        super(injector);
    }

    ngOnInit() {

    }

    get isCreateScreen() {
        return !this.employees.id;
    }

    show(employeesId?: number): void {
        if (this.listUnit && this.listUnit.length == 0) {
            this.appUnitInput.next('');
        }
        if (!employeesId) {
            this.employees = new CreateOrEditEmployeesDto();
            this.employees.id = employeesId;
            this.active = true;
            this.modal.show();
        } else {
            this._employeesServiceProxy.getEmployeesForView(employeesId).subscribe(result => {
                this.employees = result.employees;
                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._employeesServiceProxy.createOrEdit(this.prepareData())
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    prepareData(): CreateOrEditEmployeesDto {

        const result = this.copyObject(this.employees) as CreateOrEditEmployeesDto;
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
