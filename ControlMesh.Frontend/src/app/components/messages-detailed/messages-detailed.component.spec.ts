import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MessagesDetailedComponent } from './messages-detailed.component';

describe('MessagesDetailedComponent', () => {
  let component: MessagesDetailedComponent;
  let fixture: ComponentFixture<MessagesDetailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MessagesDetailedComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(MessagesDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
