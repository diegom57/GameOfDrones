import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Player } from "../models/player.model";
import { ApiMessage } from '../models/message.model';
import { GameApi } from '../models/game.model';



const endpoint = "https://localhost:44391/Api/";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable()
export class GameService {
  playerObservable: Observable<Player>;

  constructor(private http: HttpClient) {}
  headers = new HttpHeaders({
    'Content-Type': 'application/json'
  });

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }

  playerLogIn(playerName : string): Observable<any> {
    return this.http
      .get(endpoint + 'Player/PlayerLogIn?playerName='+playerName)
      .pipe(map(this.extractData));
  } 

  logAction (message: ApiMessage): Observable<ApiMessage> {
    let url = endpoint + 'Logging/LogAction/';
    console.log(url);
    return this.http.post<ApiMessage>(url, message, httpOptions)
      .pipe(
        catchError(this.handleError('message', message))
      );
  }

  logError (message : ApiMessage): Observable<any> {

    let url = endpoint + 'Logging/LogError/';
    console.log(url);
    return this.http.post<ApiMessage>(url, message, httpOptions)
      .pipe(
        catchError(this.handleError('message', message))
      );  
  }  
  
  gameFinish (winnerParam: string, loserParam: string): Observable<any>{
    let game:GameApi = {winner:winnerParam,opponent:loserParam};
    let url = endpoint + 'Game/GameFinish/';
    console.log(url);
    return this.http.post<ApiMessage>(url, game, httpOptions)
      .pipe(
        catchError(this.handleError('message', game))
      );  
  }
  

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.log(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
