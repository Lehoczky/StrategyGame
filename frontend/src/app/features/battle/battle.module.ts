import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BattleRoutingModule } from './battle-routing.module';
import { BattleService } from './services/battle.service';
import { BattlePageComponent } from './pages/battle/battle.page.component';

@NgModule({
    imports: [
        SharedModule,
        BattleRoutingModule
    ],
    providers: [
        BattleService
    ],
    declarations: [
        BattlePageComponent
    ]
})
export class BattleModule { }
