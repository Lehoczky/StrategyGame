import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BuildingsRoutingModule } from './buildings-routing.module';
import { BuildingsPageComponent } from './pages/buildings/buildings.page.component';

@NgModule({
  imports: [SharedModule, BuildingsRoutingModule],
  declarations: [BuildingsPageComponent],
})
export class BuildingsModule {}
