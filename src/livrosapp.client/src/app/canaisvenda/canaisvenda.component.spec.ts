import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CanaisvendaComponent } from './canaisvenda.component';

describe('CanaisvendaComponent', () => {
  let component: CanaisvendaComponent;
  let fixture: ComponentFixture<CanaisvendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CanaisvendaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CanaisvendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
