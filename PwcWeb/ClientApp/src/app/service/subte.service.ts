import { Inject, Injectable } from '@angular/core';
import { Message, MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RootObject } from '../subte/SubteInterfaces';
import { RootObjectGTFS } from '../subte/SubteGTFSInterfaces';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})


export class SubteService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public SubteGet(): Observable<RootObject[]> {
    return this.http.get<any>(this.baseUrl + "api/Subtes/GetSubtes", httpOptions);
    //this.http.get<RootObject[]>(this.baseUrl + "api/Subtes/GetSubtes", httpOptions).subscribe(result => {
    //  console.log(result);
    //  return result;
    //  }, error => console.error(error));
  }
  //public SubteGet(): Observable<RootObject> {
  //  this.http.get<RootObject>(this.baseUrl + "api/Subtes/GetSubtes", httpOptions).subscribe(result => {
  //    console.log(result);
  //    return result;
  //    }, error => console.error(error));
  //}
  public SubteGetGTFS(): Observable<any> {
    return this.http.get<any>(this.baseUrl + "api/Subtes/GetSubtesGTFS", httpOptions);
  }

}

