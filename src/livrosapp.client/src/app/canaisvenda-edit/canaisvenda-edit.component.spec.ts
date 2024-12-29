import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CanaisvendaEditComponent } from './canaisvenda-edit.component';

describe('CanaisvendaEditComponent', () => {
  let component: CanaisvendaEditComponent;
  let fixture: ComponentFixture<CanaisvendaEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CanaisvendaEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CanaisvendaEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
