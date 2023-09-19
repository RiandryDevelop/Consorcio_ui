import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

import { Employee } from "src/app/Interfaces/employee";

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html',
  styleUrls: ['./dialog-delete.component.css']
})
export class DialogDeleteComponent implements OnInit {
  constructor(
    private referenceDialog: MatDialogRef<DialogDeleteComponent>,
   
    @Inject(MAT_DIALOG_DATA) public employeeData: Employee
    ){

    }

    ngOnInit(): void {
    }

    deleteConfirmation():void{
      if(this.employeeData){
        this.referenceDialog.close("delete");
      }
    }
}
