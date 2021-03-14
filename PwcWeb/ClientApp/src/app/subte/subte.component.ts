import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, ViewChild, ElementRef, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Message } from '../Interfaces';
import { Observable } from 'rxjs';
import { SubteService } from '../service/subte.service';
import { RootObject, Entity, Subte } from './SubteInterfaces';
import { RootObjectGTFS } from './SubteGTFSInterfaces';
import { DatePipe } from '@angular/common';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Component({
  selector: 'subte-app',
  templateUrl: './subte.component.html',
  styleUrls: ['./subte.component.css']
})


export class SubteComponent {
  public SubteInfo: RootObject;
  public SubteList: Subte[];
  public SubteInfoGTFS: RootObjectGTFS;
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string, protected subteService: SubteService, public datepipe: DatePipe) {
    //this.GetSubte();
    this.baseUrl = baseUrl;
    this.SubteGet();
    this.SubteGetGTFS();
  }


  public SubteGet() {
    this.http.get<Subte[]>(this.baseUrl + "api/Subtes/GetSubtes", httpOptions).subscribe(result => {
      this.SubteList = result;
      var date = new Date();
      this.SubteList.forEach((subte) => {
        //
        //subte.Fecha.
          //= this.datepipe.transform(subte.Fecha, 'dd/MM/yyyy d h:mm TT');
      })
      console.log(result);
    }, error => console.error(error));
  }
  public SubteGetGTFS() {
    this.http.get<RootObjectGTFS>(this.baseUrl + "api/Subtes/GetSubtesGTFS", httpOptions).subscribe(result => {
      this.SubteInfoGTFS = result;
      console.log(result);
    }, error => console.error(error));
  }
  //public GetSubte() {
  //  this.SubteInfo = this.subteService.SubteGet();
  //}
  //public SubteGetGTFS() {
  //  this.SubteInfoGTFS = this.subteService.SubteGetGTFS();
  //}
}
