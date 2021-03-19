import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SubteComponent } from './subte/subte.component';
import { SubteGTFSComponent } from './subte/gtfs/subteGTFS.component';
import { SubteHistoryComponent } from './subte/history/subwayHistory.component';
import { DocumentationComponent } from './documentation/documentation.component';
import * as moment from 'moment';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SubteComponent,
    SubteGTFSComponent,
    SubteHistoryComponent,
    DocumentationComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, ReactiveFormsModule, 
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'subte', component: SubteComponent },
      { path: 'subte/gtfs', component: SubteGTFSComponent },
      { path: 'subte/history', component: SubteHistoryComponent },
      { path: 'documentation', component: DocumentationComponent },
    ])
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
