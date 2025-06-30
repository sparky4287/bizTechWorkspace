import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Mechwarrior } from './mechwarrior';

describe('Mechwarrior', () => {
  let component: Mechwarrior;
  let fixture: ComponentFixture<Mechwarrior>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Mechwarrior]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Mechwarrior);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
