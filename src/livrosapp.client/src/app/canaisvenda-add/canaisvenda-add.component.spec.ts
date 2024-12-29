import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CanaisvendaAddComponent } from './canaisvenda-add.component';

describe('CanaisvendaAddComponent', () => {
  let component: CanaisvendaAddComponent;
  let fixture: ComponentFixture<CanaisvendaAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CanaisvendaAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CanaisvendaAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
