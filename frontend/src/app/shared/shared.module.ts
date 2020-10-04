import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import {MatDialogModule} from '@angular/material';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        RouterModule,
        MatDialogModule,
        HttpClientModule
    ],
    exports: [
        CommonModule
    ]
})
export class SharedModule { }
