import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Component({
  selector: 'subte-history-app',
  templateUrl: './subwayHistory.component.html',
  styleUrls: ['./subwayHistory.component.css']
})

export class SubteHistoryComponent {
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

}
