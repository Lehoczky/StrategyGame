import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AttackRoutingModule } from './attack-routing.module';
import { AttackPageComponent } from './pages/attack/attack.page.component';
import { AttackService } from './services/attack.service';

@NgModule({
    imports: [
        SharedModule,
        AttackRoutingModule
    ],
    providers: [
        AttackService
    ],
    declarations: [
        AttackPageComponent
    ]
})
export class AttackModule { }
