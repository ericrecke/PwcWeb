import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Component({
  selector: 'documentation-app',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.css']
})

export class DocumentationComponent {
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

}
