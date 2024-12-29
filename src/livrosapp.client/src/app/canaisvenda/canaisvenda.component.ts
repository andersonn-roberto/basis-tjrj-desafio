import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CanaisvendaService } from './canaisvenda.service';

@Component({
  selector: 'app-canaisvenda',
  standalone: false,

  templateUrl: './canaisvenda.component.html',
  styleUrl: './canaisvenda.component.css',
})
export class CanaisvendaComponent {
  canaisVenda: any[] = [];

  constructor(
    private readonly canaisVendaService: CanaisvendaService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.getCanaisVenda();
  }

  getCanaisVenda() {
    this.canaisVendaService.getCanaisVenda().subscribe((response: any) => {
      this.canaisVenda = response;
    });
  }

  addCanalVenda() {
    this.router.navigate(['/canaisvendaAdd']);
  }

  deleteCanalVenda(codCv: number) {
    this.canaisVendaService.deleteCanalVenda(codCv).subscribe({
      next: () => {
        this.getCanaisVenda();
      },
      error: (error) => {
        window.alert(error.error);
      },
    });
  }
}
