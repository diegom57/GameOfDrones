import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Player } from "src/app/models/player.model";
import { GameService } from "src/app/services/game.service";
import { PlayerDetailComponent } from "../shared/player-detail/player-detail.component";
import { ApiMessage } from 'src/app/models/message.model';

@Component({
  selector: "app-game-screen",
  templateUrl: "./game-screen.component.html"
})
export class GameScreenComponent implements OnInit {
  currentPlayer: Player;
  currentRound: any;
  activeRound: boolean;
  activeGame: boolean;

  showRoundResult: boolean;
  currentMovePlayerOne: any;
  currentMovePlayerTwo: any;
  rockImageSource: String = "assets/img/rock.png";
  scissorsImageSource: String = "assets/img/scissors.png";
  paperImageSource: String = "assets/img/paper.png";
  playerOne: Player;
  playerTwo: Player;
  playerOneName: any = "";
  playerTwoName: any = "";

  winner: Player;
  roundWinners: number[] = [];

  constructor(
    private route: ActivatedRoute,
    private _gameService: GameService
  ) {
    try {
      this.route.params.subscribe(params => {
        this.playerOneName = params["name1"];
        this.playerTwoName = params["name2"];
      });

      this.getPlayerFromApi(this.playerOneName, this.playerTwoName);

      this.startGame();
    } catch (ex) {
      this.logErrorApi("An error has occurred when starting the game - " + ex);
    }
  }

  startGame() {
    this.roundWinners = [];
    this.currentRound = this.roundWinners.length + 1;
    this.currentPlayer = this.playerOne;
    this.activeRound = true;
    this.activeGame = true;
    this.showRoundResult = false;
    this.logActionApi(
      "A new game has started: " +
        this.playerOneName +
        " vs " +
        this.playerTwoName
    );
  }

  makeMove(move: string) {
    try {
      this.logActionApi(
        this.currentPlayer.playerName + " has selected " + (move === "S"
          ? "Scissors"
          : move === "P"
          ? "Paper"
          : "Rock")
      );
      if (this.currentPlayer.playerId === this.playerOne.playerId) {
        this.currentMovePlayerOne = move;
        this.currentPlayer = this.playerTwo;
      } else {
        this.currentMovePlayerTwo = move;
        this.finishRound();
      }
    } catch (ex) {
      this.logErrorApi("An error has occurred when making a move - " + ex);
    }
  }

  evaluateRoundWinner() {
    if (
      this.currentMovePlayerOne === "S" &&
      this.currentMovePlayerTwo === "P"
    ) {
      this.setRoundWinner(this.playerOne);
    } else if (
      this.currentMovePlayerOne === "S" &&
      this.currentMovePlayerTwo === "R"
    ) {
      this.setRoundWinner(this.playerTwo);
    } else if (
      this.currentMovePlayerOne === "R" &&
      this.currentMovePlayerTwo === "P"
    ) {
      this.setRoundWinner(this.playerTwo);
    } else if (
      this.currentMovePlayerOne === "R" &&
      this.currentMovePlayerTwo === "S"
    ) {
      this.setRoundWinner(this.playerOne);
    } else if (
      this.currentMovePlayerOne === "P" &&
      this.currentMovePlayerTwo === "R"
    ) {
      this.setRoundWinner(this.playerOne);
    } else if (
      this.currentMovePlayerOne === "P" &&
      this.currentMovePlayerTwo === "S"
    ) {
      this.setRoundWinner(this.playerTwo);
    } else if (
      this.currentMovePlayerOne === "S" &&
      this.currentMovePlayerTwo === "S"
    ) {
      this.roundWinners[this.roundWinners.length] = 0;
    } else if (
      this.currentMovePlayerOne === "P" &&
      this.currentMovePlayerTwo === "P"
    ) {
      this.roundWinners[this.roundWinners.length] = 0;
    } else if (
      this.currentMovePlayerOne === "R" &&
      this.currentMovePlayerTwo === "R"
    ) {
      this.roundWinners[this.roundWinners.length] = 0;
    }
  }

  setRoundWinner(player: Player) {
    this.roundWinners[this.roundWinners.length] = player.playerId;
    this.logActionApi(
      player.playerName + " has won round " + this.roundWinners.length
    );
  }

  setRoundDraw() {
    this.roundWinners[this.roundWinners.length] = 0;
    this.logActionApi("Round " + this.roundWinners.length + " has been a draw");
  }

  finishRound() {
    try {
      this.activeRound = false;
      this.evaluateRoundWinner();

      let pOneVictories = this.getPlayerOneWonRounds();
      let pTwoVictories = this.getPlayerTwoWonRounds();

      if (pOneVictories === 3) {
        this.finishGame(this.playerOne, this.playerTwo);
      } else if (pTwoVictories === 3) {
        this.finishGame(this.playerTwo, this.playerOne);
      } else {
        this.showRoundResult = true;
      }
    } catch (ex) {
      this.logErrorApi(
        "An error has occurred when finishing the round - " + ex
      );
    }
  }

  getPlayerOneWonRounds() {
    return this.roundWinners.filter(win => win === this.playerOne.playerId)
      .length;
  }

  getPlayerTwoWonRounds() {
    return this.roundWinners.filter(win => win === this.playerTwo.playerId)
      .length;
  }

  finishGame(winner: Player, loser: Player) {
    this.winner = winner;
    this.activeGame = false;
    this.activeRound = false;
    this.gameFinishApi(winner.playerName, loser.playerName);
  }

  carryOn() {
    try {
      this.currentRound = this.roundWinners.length + 1;
      this.showRoundResult = false;
      this.activeRound = true;
      this.currentPlayer = this.playerOne;
    } catch (ex) {
      this.logErrorApi("An error has occurred when getting players - " + ex);
    }
  }

  playAgain() {
    this.startGame();
  }

  getPlayerFromApi(p1: string, p2: string) {
    this.playerOne = {
      playerName: "",
      playerStreak: 0,
      playerTotalGames: 0,
      playerDefeats: 0,
      playerId: 0,
      playerVictories: 0
    };
    this.playerTwo = {
      playerName: "",
      playerStreak: 0,
      playerTotalGames: 0,
      playerDefeats: 0,
      playerId: 0,
      playerVictories: 0
    };
    try {
      this._gameService.playerLogIn(p1).subscribe(data => {
        this.playerOne = data;
        this.currentPlayer = data;
      });

      this._gameService.playerLogIn(p2).subscribe(data => {
        this.playerTwo = data;
      });
    } catch (ex) {
      this.logErrorApi("An error has occurred when getting players - " + ex);
    }
  }

  logActionApi(messageParam) {
    let messageObject : ApiMessage = {message:messageParam};
    this._gameService.logAction(messageObject).subscribe(
      response => console.log(response),
      err => console.log(err)
    );;
    //  this._gameService.logAction(messageObject);
  }

   gameFinishApi(winner, loser) {
     this._gameService.gameFinish(winner, loser).subscribe(
      response => console.log(response),
      err => console.log(err)
    );;
  }

   logErrorApi(messageParam) {
    let messageObject : ApiMessage = {message:messageParam};
     this._gameService.logError(messageObject).subscribe(
      response => console.log(response),
      err => console.log(err)
    );;
  }

  ngOnInit() {}
}
