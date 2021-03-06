/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BattlePageComponent } from './battle.page.component';

describe('BattlePageComponent', () => {
  let component: BattlePageComponent;
  let fixture: ComponentFixture<BattlePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BattlePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BattlePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
