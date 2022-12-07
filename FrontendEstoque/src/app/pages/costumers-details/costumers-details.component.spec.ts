import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CostumersDetailsComponent } from './costumers-details.component';

describe('CostumersDetailsComponent', () => {
  let component: CostumersDetailsComponent;
  let fixture: ComponentFixture<CostumersDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CostumersDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CostumersDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
