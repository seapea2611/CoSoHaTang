﻿import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { MainRoutingModule } from './main-routing.module';

import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';
import { SubheaderModule } from '@app/shared/common/sub-header/subheader.module';

import {ResourcesComponent} from './resources/resources.component';
import {CreateOrEditResourcesModalComponent} from './resources/create-or-edit-resources-modal.component';
import { ResourcesServiceProxy, ResourcesDto} from '@shared/service-proxies/service-proxies';

import {DocumentTemplatesComponent} from './documentTemplates/documentTemplates.component';
import {CreateOrEditDocumentTemplatesModalComponent} from './documentTemplates/create-or-edit-documentTemplates-modal.component';
import { DocumentTemplatesServiceProxy, DocumentTemplatesDto} from '@shared/service-proxies/service-proxies';

NgxBootstrapDatePickerConfigService.registerNgxBootstrapDatePickerLocales();

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot(),
        SubheaderModule
    ],
    declarations: [
        ResourcesComponent,
        CreateOrEditResourcesModalComponent,
        DocumentTemplatesComponent,
        CreateOrEditDocumentTemplatesModalComponent
    ],
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale },
        ResourcesServiceProxy,
        DocumentTemplatesServiceProxy
    ]
})
export class MainModule { }
