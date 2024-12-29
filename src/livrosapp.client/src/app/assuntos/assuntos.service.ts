import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AssuntosService {

  constructor(readonly http: HttpClient) { }

  getAssuntos() {
    return this.http.get('https://localhost:7095/api/assuntos');
  }

  addAssunto(assunto: any) {
    return this.http.post('https://localhost:7095/api/assuntos', assunto);
  }

  editAssunto(assunto: any) {
    return this.http.put('https://localhost:7095/api/assuntos', assunto);
  }

  getAssuntoById(codAs: number) {
    return this.http.get('https://localhost:7095/api/assuntos/' + codAs);
  }

  deleteAssunto(codAs: number) {
    return this.http.delete('https://localhost:7095/api/assuntos/' + codAs);
  }
}
