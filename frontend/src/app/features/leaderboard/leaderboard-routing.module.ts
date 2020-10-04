import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeaderboardPageComponent } from './pages/leaderboard.page/leaderboard.page.component';

const routes: Routes = [
    { path: '', component: LeaderboardPageComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LeaderboardRoutingModule { }