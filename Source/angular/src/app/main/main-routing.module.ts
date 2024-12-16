import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DocumentTemplatesComponent } from './documentTemplates/documentTemplates.component';
import { ResourcesComponent } from './resources/resources.component';
import { EmployeesComponent } from './employees/employees.component';
import { ContractorsComponent } from './contractors/contractors.component';
import { ProjectsComponent } from './projects/projects.component';
import { TasksComponent } from './tasks/tasks.component';
import { TasksComponent } from './tasks/tasks.component';


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
                    { path: 'documentTemplates/documentTemplates', component: DocumentTemplatesComponent, data: { permission: 'Pages.DocumentTemplates' }  },
                    { path: 'employees/employees', component: EmployeesComponent, data: { permission: 'Pages.Employees' } },
                    { path: 'contractors/contractors', component: ContractorsComponent, data: { permission: 'Pages.Contractors' } },
                    { path: 'projects/projects', component: ProjectsComponent, data: { permission: 'Pages.Projects' } },
                    { path: 'projects/projects/:id', component: TasksComponent, data: { permission: 'Pages.Tasks' } },
                    { path: 'projects/projects/:id', component: TasksComponent, data: { permission: 'Pages.Tasks' } },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
