import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BuildingsRoutingModule } from './buildings-routing.module';
import { BuildingsPageComponent } from './pages/buildings/buildings.page.component';
import { BuildingService } from './services/building.service';

@NgModule({
    imports: [
        SharedModule,
        BuildingsRoutingModule
    ],
    providers: [
        BuildingService
    ],
    declarations: [
        BuildingsPageComponent
    ]
})
export class BuildingsModule { }