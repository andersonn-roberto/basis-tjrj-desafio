import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AssuntosService } from '../assuntos/assuntos.service';

@Component({
  selector: 'app-assuntos-add',
  standalone: false,

  templateUrl: './assuntos-add.component.html',
  styleUrl: './assuntos-add.component.css',
})
export class AssuntosAddComponent {
  descricao = new FormControl('');

  constructor(
    private readonly assuntosService: AssuntosService,
    private readonly router: Router
  ) {}

  addAssunto() {
    this.assuntosService
      .addAssunto({ descricao: this.descricao.value })
      .subscribe({
        next: () => {
          this.router.navigate(['/assuntos']);
        },
        error: (error) => {
          let key = Object.keys(error.error.errors)[0];
          let value = error.error.errors[key][0];
          window.alert(value);
        },
      });
  }
}
