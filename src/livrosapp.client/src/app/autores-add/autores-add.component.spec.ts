import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoresAddComponent } from './autores-add.component';

describe('AutoresAddComponent', () => {
  let component: AutoresAddComponent;
  let fixture: ComponentFixture<AutoresAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AutoresAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AutoresAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
