import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivrosAddComponent } from './livros-add.component';

describe('LivrosAddComponent', () => {
  let component: LivrosAddComponent;
  let fixture: ComponentFixture<LivrosAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LivrosAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LivrosAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
