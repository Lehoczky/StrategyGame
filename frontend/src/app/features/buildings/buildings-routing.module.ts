import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingsPageComponent } from './pages/buildings/buildings.page.component';

const routes: Routes = [
    { path: '', component: BuildingsPageComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BuildingsRoutingModule { }
