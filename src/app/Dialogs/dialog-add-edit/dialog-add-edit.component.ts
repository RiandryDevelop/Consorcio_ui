import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MAT_DATE_FORMATS } from "@angular/material/core";

import * as moment from 'moment';
import { Employee } from "src/app/Interfaces/employee";
import { Department } from "src/app/Interfaces/department";
import { EmployeeService } from 'src/app/core/Services/employee.service';
import { DepartmentService } from 'src/app/core/Services/department.service';




export const MY_DATE_FORMATS = {
parse:{
  dateInput:"DD/MM/YYYY",
},
display:{
  dateInput:"DD/MM/YYYY",
  monthYearLabel:"MMMM YYYY",
  dateA11yLabel:"LL",
  monthYearA11yLabel:"MMMM YYYY", 
}
}
@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],
  providers:[
    {provide:MAT_DATE_FORMATS, useValue:MY_DATE_FORMATS}
  ],
})
export class DialogAddEditComponent implements OnInit {
employeeForm:FormGroup; 
actionTitle:String = "New";
actionBtn:string = "Save";
departmentsList:Department[] = []

constructor(
private referenceDialog: MatDialogRef<DialogAddEditComponent>,
private fb: FormBuilder,
private _snackBar: MatSnackBar,
private _deparmentService: DepartmentService,
private _employeeService: EmployeeService,
@Inject(MAT_DIALOG_DATA) public employeeData: Employee
){
this.employeeForm = this.fb.group({
  fullName: ["", Validators.required],
  idDepartment: ["", Validators.required],
  salary:["", Validators.required],
  contractDate: ["", Validators.required],
})

this._deparmentService.getList().subscribe({
  next: (data)=>{ 
   this.departmentsList = data
   return data
    
  },error(err) {
    console.error(err)
  },
})
}


  showAlert(message: string, action: string) {
    this._snackBar.open(message, action,{
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000, 
    });
  }

  addEditEmployee(){
  const model: Employee = {
    idEmployee: 0,
    fullName: this.employeeForm.value.fullName,
    idDepartment: this.employeeForm.value.idDepartment,
    salary: this.employeeForm.value.salary,
    contractDate: moment(this.employeeForm.value.contractDate).format('MM/DD/YYYY'),
  }
 
  if(this.employeeData == null){
    this._employeeService.add(model).subscribe({
      next:(data) => {
        this.showAlert('Employee added successfully','Ready');
        this.referenceDialog.close('Created');
        window.location.reload();
      },error:(err)=> {
        this.showAlert('Employee could not be added successfully','Error');
      },
    })
  }else{
    this._employeeService.update(this.employeeData.idEmployee,model).subscribe({
      next:(data) => {
        this.showAlert('Employee updated successfully','Ready');
        this.referenceDialog.close('edited');
      },error:(err)=> {
        this.showAlert('Employee could not be updated successfully','Error');
      },
    })
  }
 }

 ngOnInit(): void {
  if(this.employeeData){
    this.employeeForm.patchValue({
      fullName: this.employeeData.fullName,
      idDepartment: this.employeeData.idDepartment,
      salary: this.employeeData.salary,
      contractDate: moment(this.employeeData.contractDate, "MM/DD/YYYY").toDate(),    
    })

    console.log("Update Date:" + moment(this.employeeData.contractDate, "MM/DD/YYYY").toDate())
    this.actionTitle = "Edit"
    this.actionBtn = "Update"
  }

}


}
