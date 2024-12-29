import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CanaisvendaService } from '../canaisvenda/canaisvenda.service';

@Component({
  selector: 'app-canaisvenda-add',
  standalone: false,
  
  templateUrl: './canaisvenda-add.component.html',
  styleUrl: './canaisvenda-add.component.css'
})
export class CanaisvendaAddComponent {

  nome = new FormControl('');

  constructor(private readonly canaisVendaService: CanaisvendaService, private readonly router: Router) { }

  addCanalVenda() {
    this.canaisVendaService.addCanalVenda({ nome: this.nome.value })
      .subscribe(() => {
        this.router.navigate(['/canaisvenda']);
      });
  }
}
