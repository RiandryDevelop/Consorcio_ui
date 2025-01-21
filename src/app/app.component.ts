import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {MatDialog} from '@angular/material/dialog';
import { DialogAddEditComponent } from "./Dialogs/dialog-add-edit/dialog-add-edit.component";
 

import { Employee } from "./Interfaces/employee";
import { EmployeeService } from './core/Services/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogDeleteComponent } from './Dialogs/dialog-delete/dialog-delete.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],

})
export class AppComponent implements AfterViewInit,OnInit{
  title = 'Consorcio_ui';
  displayedColumns: string[] = ['fullName', 'department', 'salary', 'contractDate', 'Actions'];
  dataSource = new MatTableDataSource<Employee>();

  constructor(
    private _EmployeeService: EmployeeService,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar

    ){

  }
  dialogNewEmployee() {
    this.dialog.open(DialogAddEditComponent,{
      disableClose: true,
      width: '350px',
    }).afterClosed().subscribe(result =>{
      if(result === 'created'){
        this.showEmployees();
      }  
  })
  }



  dialogEditEmployee(employeeData: Employee){
    this.dialog.open(DialogAddEditComponent,{
      disableClose: true,
      width: '350px',
      data: employeeData,
    }).afterClosed().subscribe(result =>{
      if(result === 'edited'){
        this.showEmployees();
      }  
  })
  }

  dialogDeleteEmployee(employeeData: Employee){
    this.dialog.open(DialogDeleteComponent,{
      disableClose: true,
      data: employeeData,
    }).afterClosed().subscribe(result =>{
      if(result === 'delete'){
        this._EmployeeService.delete(employeeData.idEmployee).subscribe({
          next: (data)=>{
            this.showAlert("The employee has been deleted","ready");
            this.showEmployees();
          },
           error: (e)=> console.error(e)
        })
      }  
  })
  }

  
  showAlert(message: string, action: string) {
    this._snackBar.open(message, action,{
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000, 
    });
  }




  ngOnInit(): void {
   this.showEmployees() 
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showEmployees(){
    this._EmployeeService.getList().subscribe({
      next:(data)=>{
        this.dataSource.data = data;

      },error:(e)=> console.error(e)
    })
  }
}

