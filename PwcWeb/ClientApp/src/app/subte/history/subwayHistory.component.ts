import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HistoryView } from './subwayHistoryInterfaces';


@Component({
  selector: 'subte-history-app',
  templateUrl: './subwayHistory.component.html',
  styleUrls: ['./subwayHistory.component.css']
})

export class SubteHistoryComponent {
  baseUrl: string;
  HistorySubways: HistoryView;
  lineSubway: string;
  dateSubway: string;

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.dateSubway = new Date().toISOString();
    this.lineSubway = "Todas las Lineas";
    this.SubteHistoryGet();
  }

  public SubteHistoryGet() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'my-auth-token' }),
      params: new HttpParams().set('FechaDesde', this.dateSubway).set('Line', this.lineSubway)
    };
    this.http.get<HistoryView>(this.baseUrl + "api/Subtes/GetHistories", httpOptions).subscribe(result => {
      this.HistorySubways = result;
      this.lineSubway = this.HistorySubways.lines[0].id.toString();
      console.log(result);
    }, error => console.error(error));
  }

}
