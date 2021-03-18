import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { RootObject, MainObject } from './SubteGTFSInterfaces';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'subte-gtfs-app',
  templateUrl: './subteGTFS.component.html',
  styleUrls: ['./subteGTFS.component.css']
})

export class SubteGTFSComponent {
  public SubwayGTFS: MainObject;
  baseUrl: string;
  lineSubway: string = '0';
  stationSubway: string = "0";
  destinationSubway: string = '0';

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.SubwayGetGTFS();
  }

  public SubwayGetGTFS(search = '0') {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'my-auth-token' }),
      params: new HttpParams().set('Line', this.lineSubway).set('Station', this.stationSubway).set('Destination', this.destinationSubway).set('search', search)
    };
    this.http.get<MainObject>(this.baseUrl + "api/Subtes/GetSubtesGTFS", httpOptions).subscribe(result => {
      this.SubwayGTFS = result;
      console.log(this.SubwayGTFS);
    }, error => console.error(error));
  }
}



