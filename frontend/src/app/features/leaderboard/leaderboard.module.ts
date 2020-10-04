import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { LeaderboardRoutingModule } from './leaderboard-routing.module';
import { LeaderboardPageComponent } from './pages/leaderboard.page/leaderboard.page.component';
import { LeaderboardService } from './services/leaderboard.service';

@NgModule({
    imports: [
        SharedModule,
        LeaderboardRoutingModule
    ],
    providers: [
        LeaderboardService
    ],
    declarations: [
        LeaderboardPageComponent
    ]
})
export class LeaderboardModule { }
