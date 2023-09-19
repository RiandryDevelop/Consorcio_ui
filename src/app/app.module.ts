import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// Material Components...
import { ReactiveFormsModule } from "@angular/forms";
import {MatTableModule} from "@angular/material/table"
import {MatPaginatorModule} from "@angular/material/paginator"
import {HttpClientModule} from '@angular/common/http'
//
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatButtonModule } from "@angular/material/button";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatIconModule } from "@angular/material/icon";
import { MatDialogModule} from "@angular/material/dialog";
import { MatGridListModule } from "@angular/material/grid-list";
import { DialogAddEditComponent } from './Dialogs/dialog-add-edit/dialog-add-edit.component';
import { DialogDeleteComponent } from './Dialogs/dialog-delete/dialog-delete.component';

@NgModule({
  declarations: [
    AppComponent,
    DialogAddEditComponent,
    DialogDeleteComponent
  ],
  imports: [
  MatGridListModule,
  MatDialogModule,
  MatIconModule,
  MatSnackBarModule,
  MatFormFieldModule,
  MatInputModule ,
  MatSelectModule,
  MatDatepickerModule,
  MatNativeDateModule,
  BrowserModule,
  BrowserAnimationsModule,
  HttpClientModule,
  MatPaginatorModule,
  MatTableModule,
  MatButtonModule,
  ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
