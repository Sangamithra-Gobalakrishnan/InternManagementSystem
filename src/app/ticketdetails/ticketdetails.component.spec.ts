import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketdetailsComponent } from './ticketdetails.component';

describe('TicketdetailsComponent', () => {
  let component: TicketdetailsComponent;
  let fixture: ComponentFixture<TicketdetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TicketdetailsComponent]
    });
    fixture = TestBed.createComponent(TicketdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
