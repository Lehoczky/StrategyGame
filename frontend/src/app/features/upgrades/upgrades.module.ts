import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UpgradesPageComponent } from './pages/upgrades/upgrades.page.component';
import { UpgradeService } from './services/upgrade.service';
import { UpgradesRoutingModule } from './upgrades-routing.module';

@NgModule({
    imports: [
        SharedModule,
        UpgradesRoutingModule
    ],
    providers: [
        UpgradeService
    ],
    declarations: [
        UpgradesPageComponent
    ]
})
export class UpgradesModule { }