import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UnitsPageComponent } from './pages/units/units.page.component';
import { UnitService } from './services/unit.service';
import { UnitsRoutingModule } from './units-routing.module';

@NgModule({
    imports: [
        SharedModule,
        UnitsRoutingModule
    ],
    providers: [
        UnitService
    ],
    declarations: [
        UnitsPageComponent
    ]
})
export class UnitsModule { }
