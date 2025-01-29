import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DialogAddEditComponent } from './Dialogs/dialog-add-edit/dialog-add-edit.component';
import { isAdminGuard } from './core/guards/is-admin.guard';

export const routes: Routes = [
    {path: '', component: AppComponent},
    {path: 'employee/create', component:DialogAddEditComponent , canActivate: [isAdminGuard]},
    {path: 'employee/edit/:id', component:DialogAddEditComponent , canActivate: [isAdminGuard]},
    {path: '**', redirectTo: ''},
   
];