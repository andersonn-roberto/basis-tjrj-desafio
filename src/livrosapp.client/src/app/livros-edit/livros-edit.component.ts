import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AssuntosService } from '../assuntos/assuntos.service';
import { AutoresService } from '../autores/autores.service';
import { CanaisvendaService } from '../canaisvenda/canaisvenda.service';
import { LivrosService } from '../livros/livros.service';

@Component({
  selector: 'app-livros-edit',
  standalone: false,

  templateUrl: './livros-edit.component.html',
  styleUrl: './livros-edit.component.css',
})
export class LivrosEditComponent {
  codL: any;

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
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.codL = this.route.snapshot.params['codL'];
    this.getLivroById();
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

  getLivroById() {
    this.livrosService.getLivroById(this.codL).subscribe((response: any) => {
      this.titulo.setValue(response.titulo);
      this.editora.setValue(response.editora);
      this.edicao.setValue(response.edicao);
      this.anoPublicacao.setValue(response.anoPublicacao);
      this.autoresSelecionados.setValue(
        response.livrosAutores.map((autor: any) => autor.autor_CodAu)
      );
      this.assuntosSelecionados.setValue(
        response.livrosAssuntos.map((assunto: any) => assunto.assunto_CodAs)
      );
      this.canaisVendaSelecionados.setValue(response.tabelaPrecos[0].codCv);
      this.valor.setValue(response.tabelaPrecos[0].valor);
    });
  }

  editLivro() {
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

    // this.livrosService.addLivro(livro).subscribe(() => {
    //   this.router.navigate(['/livros']);
    // });
  }
}
