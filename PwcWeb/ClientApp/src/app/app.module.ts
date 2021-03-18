import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ChatComponent } from './chat/chat.component';
import { MessageComponent } from './messages/message.component';
import { SubteComponent } from './subte/subte.component';
import { SubteGTFSComponent } from './subte/gtfs/subteGTFS.component';
import { SubteHistoryComponent } from './subte/history/subwayHistory.component';
//Services
import { ChatService } from './service/chat.service';
import { SubteService } from './service/subte.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ChatComponent,
    MessageComponent,
    SubteComponent,
    SubteGTFSComponent,
    SubteHistoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'chat', component: ChatComponent },
      { path: 'subte', component: SubteComponent },
      { path: 'subte/gtfs', component: SubteGTFSComponent },
      { path: 'subte/history', component: SubteHistoryComponent },
    ])
  ],
  providers: [ChatService, SubteService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
