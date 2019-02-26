import { Component, OnInit, Input } from '@angular/core';
import { Player } from "src/app/models/player.model";

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html'
})
export class PlayerDetailComponent implements OnInit {

  @Input() player: Player;
  @Input() roundWinners: any[];
  
  constructor() { }

  ngOnInit() {
  }

}
