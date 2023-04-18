import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlDetailedComponent } from './control-detailed.component';

describe('ControlDetailedComponent', () => {
  let component: ControlDetailedComponent;
  let fixture: ComponentFixture<ControlDetailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ControlDetailedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
