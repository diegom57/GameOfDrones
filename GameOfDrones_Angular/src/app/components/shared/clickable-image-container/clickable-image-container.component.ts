import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-clickable-image-container',
  templateUrl: './clickable-image-container.component.html'
})
export class ClickableImageContainerComponent implements OnInit {

  @Input() imgSrc: any = {};

  constructor() { }

  ngOnInit() {
  }

}
