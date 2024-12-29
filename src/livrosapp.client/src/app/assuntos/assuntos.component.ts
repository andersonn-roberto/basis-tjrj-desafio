import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AssuntosService } from './assuntos.service';

@Component({
  selector: 'app-assuntos',
  standalone: false,

  templateUrl: './assuntos.component.html',
  styleUrl: './assuntos.component.css',
})
export class AssuntosComponent {
  assuntos: any[] = [];

  constructor(
    private readonly assutosService: AssuntosService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.getAssuntos();
  }

  getAssuntos() {
    this.assutosService.getAssuntos().subscribe((response: any) => {
      this.assuntos = response;
    });
  }

  addAssunto() {
    this.router.navigate(['/assuntosAdd']);
  }

  deleteAssunto(codAs: number) {
    this.assutosService.deleteAssunto(codAs).subscribe({
      next: () => {
        this.getAssuntos();
      },
      error: (error) => {
        window.alert(error.error);
      },
    });
  }
}
