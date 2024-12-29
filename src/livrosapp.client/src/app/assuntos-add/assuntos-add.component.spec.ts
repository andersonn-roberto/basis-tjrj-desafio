import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssuntosAddComponent } from './assuntos-add.component';

describe('AssuntosAddComponent', () => {
  let component: AssuntosAddComponent;
  let fixture: ComponentFixture<AssuntosAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssuntosAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssuntosAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
