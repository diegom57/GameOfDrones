import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { GameScreenComponent } from './components/game-screen/game-screen.component';


const APP_ROUTES: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'gameScreen/:name1/:name2', component: GameScreenComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
