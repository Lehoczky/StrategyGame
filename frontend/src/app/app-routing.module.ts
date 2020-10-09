import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './core/auth/auth.component';
import { StrategyComponent } from './core/components/strategy/strategy.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  {
    path: 'strategy', component: StrategyComponent, canActivate: [AuthGuard], children: [
      { path: 'features/buildings', loadChildren: './features/buildings/buildings.module#BuildingsModule' },
      { path: 'features/attack', loadChildren: './features/attack/attack.module#AttackModule' },
      { path: 'features/upgrades', loadChildren: './features/upgrades/upgrades.module#UpgradesModule' },
      { path: 'features/battle', loadChildren: './features/battle/battle.module#BattleModule' },
      { path: 'features/leaderboard', loadChildren: './features/leaderboard/leaderboard.module#LeaderboardModule' },
      { path: 'features/units', loadChildren: './features/units/units.module#UnitsModule' }
    ]
  },
  { path: '**', redirectTo: '/strategy', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
