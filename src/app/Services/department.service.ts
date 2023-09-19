import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environmentDev } from 'src/environments/environment.development';
import {Observable} from 'rxjs';
import { Department } from '../Interfaces/department';
import { environmentProd } from 'src/environments/environment.production';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private endpoint: string =  environmentProd.endPoint
  private apiUrl:string = this.endpoint + 'department/'


  constructor(private http:HttpClient) {}

     getList():Observable<Department[]>{
      return this.http.get<Department[]>(`${this.apiUrl}list`);
    }
}
