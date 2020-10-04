import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnitsPageComponent } from './pages/units/units.page.component';

const routes: Routes = [
    { path: '', component: UnitsPageComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UnitsRoutingModule { }