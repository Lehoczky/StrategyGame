import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthPageComponent } from './pages/auth/auth.page.component';
import { StrategyPageComponent } from './pages/strategy/strategy.page.component';
import { StatsComponent } from './components/stats/stats.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ProfileCardComponent } from './components/profile-card/profile-card.component';
import { SharedModule } from '../shared/shared.module';
import { BuildingsModule } from '../features/buildings/buildings.module';
import { UnitsModule } from '../features/units/units.module';
import { BattleModule } from '../features/battle/battle.module';
import { AttackModule } from '../features/attack/attack.module';
import { UpgradesModule } from '../features/upgrades/upgrades.module';
import { LeaderboardModule } from '../features/leaderboard/leaderboard.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AuthPageComponent,
    StrategyPageComponent,
    StatsComponent,
    SidebarComponent,
    ProfileCardComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    SharedModule,
    BuildingsModule,
    UnitsModule,
    BattleModule,
    AttackModule,
    UpgradesModule,
    LeaderboardModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
})
export class CoreModule {}
