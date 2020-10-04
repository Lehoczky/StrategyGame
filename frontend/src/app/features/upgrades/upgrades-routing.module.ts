import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UpgradesPageComponent } from './pages/upgrades/upgrades.page.component';

const routes: Routes = [
    { path: '', component: UpgradesPageComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UpgradesRoutingModule { }