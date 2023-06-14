import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketsolutionComponent } from './ticketsolution.component';

describe('TicketsolutionComponent', () => {
  let component: TicketsolutionComponent;
  let fixture: ComponentFixture<TicketsolutionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TicketsolutionComponent]
    });
    fixture = TestBed.createComponent(TicketsolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
