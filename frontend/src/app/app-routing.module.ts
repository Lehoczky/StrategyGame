import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AuthPageComponent } from './core/pages/auth/auth.page.component';
import { StrategyPageComponent } from './core/pages/strategy/strategy.page.component';

const routes: Routes = [
  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path: 'auth', component: AuthPageComponent },
  {
    path: 'strategy', component: StrategyPageComponent, canActivate: [AuthGuard], children: [
      { path: 'features/buildings', loadChildren: './features/buildings/buildings.module#BuildingsModule' },
      { path: 'features/attack', loadChildren: './features/attack/attack.module#AttackModule' },
      { path: 'features/battle', loadChildren: './features/battle/battle.module#BattleModule' },
      { path: 'features/units', loadChildren: './features/units/units.module#UnitsModule' },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
