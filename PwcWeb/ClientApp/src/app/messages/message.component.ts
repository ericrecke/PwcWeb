import { Component, Input } from '@angular/core';


@Component({
  selector: "app-message",
  templateUrl: "./message.component.html"
})
export class MessageComponent {
  @Input() oMessage: Message;
  @Input() oSubte: any;
}


interface Message {
  Id: number,
  Name: string,
  Text: string;
}
