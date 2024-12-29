import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Autor } from './autor';

@Injectable({
  providedIn: 'root'
})
export class AutoresService {

  constructor(readonly http: HttpClient) { }

  getAutores() {
    return this.http.get<Autor[]>('https://localhost:7095/api/autores');
  }

  addAutor(autor: Autor) {
    return this.http.post('https://localhost:7095/api/autores', autor);
  }

  editAutor(autor: Autor) {
    return this.http.put('https://localhost:7095/api/autores', autor);
  }

  getAutorById(codAu: number) {
    return this.http.get<Autor>('https://localhost:7095/api/autores/' + codAu);
  }

  deleteAutor(codAu: number) {
    return this.http.delete('https://localhost:7095/api/autores/' + codAu);
  }
}
