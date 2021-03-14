import { Inject, Injectable } from '@angular/core';
import { Message, MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ChatService {
  public algo: string = "Hola prueba2.0";
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  public GetMessage(): Observable<Message[]> {
    return this.http.get<Message[]>(this.baseUrl + "api/Chat/Message");
    //http.get<Message[]>(baseUrl + "api/Chat/Message").subscribe(result => {
    //  this.lstMessages = result;
    //}, error => console.error(error));
  }

  public Add(name, text) {
    this.http.post<MyResponse>(this.baseUrl + "api/Chat/Add", { 'Name': name, 'Text': text }, httpOptions)
      .subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}

