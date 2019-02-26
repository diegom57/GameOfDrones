import { Component, OnInit, NgModule } from "@angular/core";
import { Router, NavigationExtras } from "@angular/router";
import { Player } from "src/app/models/player.model";
import { PlayerDetailComponent } from "../shared/player-detail/player-detail.component";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit {
  isPlayerOneValid: any = true;
  isPlayerTwoValid: any = true;

  constructor(private router: Router) {}

  ngOnInit() {}

  StartGame(playerOneName: string, playerTwoName: string) {
    !playerOneName
      ? (this.isPlayerOneValid = false)
      : (this.isPlayerOneValid = true);
    !playerTwoName
      ? (this.isPlayerTwoValid = false)
      : (this.isPlayerTwoValid = true);

    if (this.isPlayerOneValid && this.isPlayerTwoValid) {
      this.router.navigate(["/gameScreen", playerOneName, playerTwoName]);
      // { queryParams: { playerOneParam: playerOneName, playerTwoParam: playerTwoName} }
    }
  }
}
