import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AssuntosService } from '../assuntos/assuntos.service';

@Component({
  selector: 'app-assuntos-add',
  standalone: false,
  
  templateUrl: './assuntos-add.component.html',
  styleUrl: './assuntos-add.component.css'
})
export class AssuntosAddComponent {

  descricao = new FormControl('');

  constructor(private readonly assuntosService: AssuntosService, private readonly router: Router) { }

  addAssunto() {
    this.assuntosService.addAssunto({ descricao: this.descricao.value })
      .subscribe(() => {
        this.router.navigate(['/assuntos']);
      });
  }
}
