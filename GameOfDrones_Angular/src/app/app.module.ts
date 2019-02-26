import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// Routes
import {APP_ROUTING} from './app.routes';

// servicios
import {GameService} from './services/game.service';

// componentes
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { GameScreenComponent } from './components/game-screen/game-screen.component';
import { PlayerDetailComponent } from './components/shared/player-detail/player-detail.component';
import { ImageContainerComponent } from './components/shared/image-container/image-container.component';
import { ClickableImageContainerComponent } from './components/shared/clickable-image-container/clickable-image-container.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameScreenComponent,
    PlayerDetailComponent,
    ImageContainerComponent,
    ClickableImageContainerComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    GameService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
