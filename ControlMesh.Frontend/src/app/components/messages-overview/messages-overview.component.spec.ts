import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagesOverviewComponent } from './messages-overview.component';

describe('MessagesOverviewComponent', () => {
  let component: MessagesOverviewComponent;
  let fixture: ComponentFixture<MessagesOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessagesOverviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MessagesOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
