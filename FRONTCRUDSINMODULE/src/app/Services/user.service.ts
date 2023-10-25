import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from '../Interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint +"usuarios/";

  constructor(private http:HttpClient) {   }

  getList():Observable<User[]>{
      return this.http.get<User[]>(`${this.apiUrl}lista`);
  }

  getListByCar(cargo:number):Observable<User[]>{
    return this.http.get<User[]>(`${this.apiUrl}FilterByCargo/${cargo}`);
  }

  getListByDep(depa:number):Observable<User[]>{
    return this.http.get<User[]>(`${this.apiUrl}FilterByDepartamento/${depa}`);
  }

  add(modelo:User):Observable<User>{
    return this.http.post<User>(`${this.apiUrl}guardar`, modelo);
  }

  update(idUser:number, modelo:User):Observable<User>{
    return this.http.put<User>(`${this.apiUrl}actualizar/${idUser}`, modelo);
  }

  delete(idUser:number):Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}eliminar/${idUser}`);
  }
}
