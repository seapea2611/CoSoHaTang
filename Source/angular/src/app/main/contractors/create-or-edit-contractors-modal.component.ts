// import {Component, ViewChild, Injector, Output, EventEmitter, OnInit} from '@angular/core';
// import { ModalDirective } from 'ngx-bootstrap';
// import { finalize } from 'rxjs/operators';
// import {
//     ContractorsServiceProxy,
//     CreateOrEditContractorsDto
// } from '@shared/service-proxies/service-proxies';
// import { AppComponentBase } from '@shared/common/app-component-base';
// import {Subject} from "@node_modules/rxjs";
// import {debounceTime, distinctUntilChanged} from "@node_modules/rxjs/operators";


// @Component({
//     selector: 'createOrEditContractorsModal',
//     templateUrl: './create-or-edit-contractors-modal.component.html'
// })
// export class CreateOrEditContractorsModalComponent extends AppComponentBase implements  OnInit{

//     @ViewChild('createOrEditModal') modal: ModalDirective;
//     @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

//     active = false;
//     saving = false;

//     contractors: CreateOrEditContractorsDto = new CreateOrEditContractorsDto();
//     listUnit = [];
//     seletedUnits = [];
//     appUnitInput = new Subject<string>();


//     constructor(
//         injector: Injector,
//         private _contractorsServiceProxy: ContractorsServiceProxy
//     ) {
//         super(injector);
//     }

//     ngOnInit() {

//     }

//     get isCreateScreen() {
//         return !this.contractors.id;
//     }

//     show(contractorsId?: number): void {
//         if(this.listUnit && this.listUnit.length == 0) {
//             this.appUnitInput.next('');
//         }
//         if (!contractorsId) {
//             this.contractors = new CreateOrEditContractorsDto();
//             this.contractors.id = contractorsId;
//             this.active = true;
//             this.modal.show();
//         } else {
//             this._contractorsServiceProxy.getContractorsForView(contractorsId).subscribe(result => {
//                 this.contractors = result.contractors;
//                 this.active = true;
//                 this.modal.show();
//             });
//         }
//     }

//     save(): void {
//         this.saving = true;

//         this._contractorsServiceProxy.createOrEdit(this.prepareData())
//          .pipe(finalize(() => { this.saving = false;}))
//          .subscribe(() => {
//             this.notify.info(this.l('SavedSuccessfully'));
//             this.close();
//             this.modalSave.emit(null);
//          });
//     }

//     prepareData(): CreateOrEditContractorsDto {

//         const result = this.copyObject(this.contractors) as CreateOrEditContractorsDto;
//         return result;
//     }

//     close(): void {
//         this.active = false;
//         this.seletedUnits = [];
//         this.modal.hide();
//     }

//     copyObject(data: any) {
//         return JSON.parse(JSON.stringify(data));
//     }
// }
