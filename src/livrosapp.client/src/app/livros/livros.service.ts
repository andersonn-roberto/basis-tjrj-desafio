import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LivrosService {
  constructor(readonly http: HttpClient) {}

  getLivros() {
    return this.http.get('https://localhost:7095/api/livros');
  }

  addLivro(livro: any) {
    return this.http.post('https://localhost:7095/api/livros', livro);
  }

  editLivro(livro: any) {
    return this.http.put('https://localhost:7095/api/livros', livro);
  }

  getLivroById(codL: number) {
    return this.http.get('https://localhost:7095/api/livros/' + codL);
  }

  deleteLivro(codL: number) {
    return this.http.delete('https://localhost:7095/api/livros/' + codL);
  }
}
