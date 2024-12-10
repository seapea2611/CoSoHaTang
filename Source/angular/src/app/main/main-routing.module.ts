import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ResourcesComponent } from './resources/resources.component';
import { EmployeesComponent } from './employees/employees.component';


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
                    { path: 'resources/resources', component: ResourcesComponent, data: { permission: 'Pages.Resources' } },
                    { path: 'employees/employees', component: EmployeesComponent, data: { permission: 'Pages.Employees' } },
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
