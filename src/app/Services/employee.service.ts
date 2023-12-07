import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environmentDev } from '../../environments/environment.development';
import {Observable} from 'rxjs';
import { Employee } from '../Interfaces/employee';
// import { environmentProd } from 'src/environments/environment.production';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  // private endpoint: string =  environmentProd.endPoint
  private endpoint: string =  environmentDev.endPoint
  private apiUrl:string = this.endpoint + 'employee/'

  constructor(private http:HttpClient) { }

  getList():Observable<Employee[]>{
    return this.http.get<Employee[]>(`${this.apiUrl}list`);
  }
  add(model:Employee):Observable<Employee>{
    return this.http.post<Employee>(`${this.apiUrl}save`,model);
  }

  update(idEmployee:number, model:Employee):Observable<Employee>{
    return this.http.put<Employee>(`${this.apiUrl}update/${idEmployee}`,model);
  }

  delete(idEmployee:number):Observable<void>{
     return this.http.delete<void>(`${this.apiUrl}delete/${idEmployee}`);
  }
}
