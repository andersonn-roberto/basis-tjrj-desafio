import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LivrosService } from '../livros/livros.service';
import { AssuntosService } from '../assuntos/assuntos.service';
import { AutoresService } from '../autores/autores.service';
import { CanaisvendaService } from '../canaisvenda/canaisvenda.service';

@Component({
  selector: 'app-livros-add',
  standalone: false,

  templateUrl: './livros-add.component.html',
  styleUrl: './livros-add.component.css',
})
export class LivrosAddComponent {
  autores: any[] = [];
  assuntos: any[] = [];
  canaisVenda: any[] = [];

  autoresSelecionados = new FormControl();
  assuntosSelecionados = new FormControl();
  canaisVendaSelecionados = new FormControl();
  titulo = new FormControl();
  editora = new FormControl();
  edicao = new FormControl();
  anoPublicacao = new FormControl();
  valor = new FormControl();

  constructor(
    private readonly autoresService: AutoresService,
    private readonly assuntosService: AssuntosService,
    private readonly canaisVendaService: CanaisvendaService,
    private readonly livrosService: LivrosService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.getAutores();
    this.getAssuntos();
    this.getCanaisVenda();
  }

  getAutores() {
    this.autoresService.getAutores().subscribe((autores: any) => {
      this.autores = autores;
    });
  }

  getAssuntos() {
    this.assuntosService.getAssuntos().subscribe((assuntos: any) => {
      this.assuntos = assuntos;
    });
  }

  getCanaisVenda() {
    this.canaisVendaService.getCanaisVenda().subscribe((canaisVenda: any) => {
      this.canaisVenda = canaisVenda;
    });
  }

  addLivro() {
    const livro = {
      titulo: this.titulo.value,
      editora: this.editora.value,
      edicao: this.edicao.value,
      anoPublicacao: this.anoPublicacao.value,
      livrosautores: this.autoresSelecionados.value,
      livrosassuntos: this.assuntosSelecionados.value,
      tabelaprecos: [
        {
          codcv: this.canaisVendaSelecionados.value,
          valor: this.valor.value,
        },
      ],
    };

    this.livrosService.addLivro(livro).subscribe(() => {
      this.router.navigate(['/livros']);
    });
  }
}
