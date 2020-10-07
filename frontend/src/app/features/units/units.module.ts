import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UnitsPageComponent } from './pages/units/units.page.component';
import { UnitsRoutingModule } from './units-routing.module';

@NgModule({
  imports: [SharedModule, UnitsRoutingModule],
  declarations: [UnitsPageComponent],
})
export class UnitsModule {}
