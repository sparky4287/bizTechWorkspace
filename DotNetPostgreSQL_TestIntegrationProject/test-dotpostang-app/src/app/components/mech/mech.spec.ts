import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Mech } from './mech';

describe('Mech', () => {
  let component: Mech;
  let fixture: ComponentFixture<Mech>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Mech]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Mech);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
