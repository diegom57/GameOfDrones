import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-image-container',
  templateUrl: './image-container.component.html'
})
export class ImageContainerComponent implements OnInit {

  @Input() imgSrc: any = {};

  constructor() { }

  ngOnInit() {
  }

}
