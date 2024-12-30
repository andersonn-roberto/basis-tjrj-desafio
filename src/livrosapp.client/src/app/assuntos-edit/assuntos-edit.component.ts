import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { AssuntosService } from '../assuntos/assuntos.service';

@Component({
  selector: 'app-assuntos-edit',
  standalone: false,

  templateUrl: './assuntos-edit.component.html',
  styleUrl: './assuntos-edit.component.css',
})
export class AssuntosEditComponent {
  codAs: any;
  descricao = new FormControl('');

  constructor(
    private readonly assuntosService: AssuntosService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.codAs = this.route.snapshot.params['codAs'];
    this.getAssuntoById();
  }

  getAssuntoById() {
    this.assuntosService.getAssuntoById(this.codAs).subscribe({
      next: (response: any) => {
        this.codAs = response.codAs;
        this.descricao.setValue(response.descricao);
      },
      error: (error) => {
        let errorMessage = error.error.substring(
          error.error.indexOf(':') + 2,
          error.error.indexOf('.\r\n') + 1
        );
        window.alert(errorMessage);
        this.router.navigate(['/assuntos']);
      },
    });
  }

  editAssunto() {
    this.assuntosService
      .editAssunto({ codAs: this.codAs, descricao: this.descricao.value })
      .subscribe(() => {
        this.router.navigate(['/assuntos']);
      });
  }
}
