import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss']
})
export class BuildingsPageComponent implements OnInit {
  @ViewChild('buildingFirst', { static: false }) buildingFirst: ElementRef;
  @ViewChild('buildingSecond', { static: false }) buildingSecond: ElementRef;

  constructor() { }

  ngOnInit() {
  }

  selectBuilding(building: number) {
    (building === 1) ?
      this.buildingFirst.nativeElement.tabIndex = 1 : this.buildingSecond.nativeElement.tabIndex = 1;
    }
  }

