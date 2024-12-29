import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoresEditComponent } from './autores-edit.component';

describe('AutoresEditComponent', () => {
  let component: AutoresEditComponent;
  let fixture: ComponentFixture<AutoresEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AutoresEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AutoresEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
