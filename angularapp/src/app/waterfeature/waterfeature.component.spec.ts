import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterfeatureComponent } from './waterfeature.component';

describe('WaterfeatureComponent', () => {
  let component: WaterfeatureComponent;
  let fixture: ComponentFixture<WaterfeatureComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WaterfeatureComponent]
    });
    fixture = TestBed.createComponent(WaterfeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
