import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthPageComponent } from './core/pages/auth/auth.page.component';
import { StrategyPageComponent } from './core/pages/strategy/strategy.page.component';

const routes: Routes = [
  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path: 'auth', component: AuthPageComponent },
  { path: 'strategy', component: StrategyPageComponent },
  {
    path: 'battle',
    loadChildren: './features/battle/battle.module#BattleModule'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
