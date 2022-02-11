import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketerComponent } from './marketer.component';

describe('MarketerComponent', () => {
  let component: MarketerComponent;
  let fixture: ComponentFixture<MarketerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
