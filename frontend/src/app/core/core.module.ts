import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import {RouterModule} from "@angular/router";

import { AuthPageComponent } from './pages/auth/auth.page.component';
import { StrategyPageComponent } from './pages/strategy/strategy.page.component';
import { StatsComponent } from './components/stats/stats.component';

@NgModule({
    declarations: [
        AuthPageComponent,
        StrategyPageComponent,
        StatsComponent
      ],
      imports: [
        BrowserModule,
        FormsModule,
        RouterModule
      ]
})
export class CoreModule {

}
