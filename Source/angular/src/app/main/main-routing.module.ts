import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {ResourcesComponent} from './resources/resources.component';
import {ContractorsComponent} from './contractors/contractors.component';import {ProjectsComponent} from './projects/projects.component'


@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'dashboard',
                        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
                        data: { permission: 'Pages.Tenant.Dashboard' }
                    },
                    { path: 'resources/resources', component: ResourcesComponent, data: { permission: 'Pages.Resources' }  },
                    { path: 'contractors/contractors', component: ContractorsComponent, data: { permission: 'Pages.Contractors' } },
                    { path: 'projects/projects', component: ProjectsComponent, data: { permission: 'Pages.Projects' }  },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
