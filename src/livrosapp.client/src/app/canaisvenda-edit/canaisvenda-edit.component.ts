import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CanaisvendaService } from '../canaisvenda/canaisvenda.service';

@Component({
  selector: 'app-canaisvenda-edit',
  standalone: false,
  
  templateUrl: './canaisvenda-edit.component.html',
  styleUrl: './canaisvenda-edit.component.css'
})
export class CanaisvendaEditComponent {

  codCv: any;
  nome = new FormControl('');

  constructor(private readonly canaisVendaService: CanaisvendaService, private readonly router: Router, private readonly route: ActivatedRoute) { }

  ngOnInit() {
    this.codCv = this.route.snapshot.params["codCv"];
    this.getCanalVendaById();
  }

  getCanalVendaById() {
    this.canaisVendaService.getCanalVendaById(this.codCv)
      .subscribe((response: any) => {
        this.codCv = response.codCv;
        this.nome.setValue(response.nome);
      });
  }

  editCanalVenda() {
    this.canaisVendaService.editCanalVenda({ codCv: this.codCv, nome: this.nome.value })
      .subscribe(() => {
        this.router.navigate(['/canaisvenda']);
      });
  }
}
