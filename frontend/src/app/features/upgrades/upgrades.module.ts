import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UpgradesPageComponent } from './pages/upgrades/upgrades.page.component';
import { UpgradesRoutingModule } from './upgrades-routing.module';

@NgModule({
  imports: [SharedModule, UpgradesRoutingModule],
  declarations: [UpgradesPageComponent],
})
export class UpgradesModule {}
