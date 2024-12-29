import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssuntosEditComponent } from './assuntos-edit.component';

describe('AssuntosEditComponent', () => {
  let component: AssuntosEditComponent;
  let fixture: ComponentFixture<AssuntosEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssuntosEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssuntosEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
