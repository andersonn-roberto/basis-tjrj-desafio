import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CanaisvendaService {

  constructor(readonly http: HttpClient) { }

  getCanaisVenda() {
    return this.http.get('https://localhost:7095/api/canaisvenda');
  }

  addCanalVenda(canalVenda: any) {
    return this.http.post('https://localhost:7095/api/canaisvenda', canalVenda);
  }

  editCanalVenda(canalVenda: any) {
    return this.http.put('https://localhost:7095/api/canaisvenda', canalVenda);
  }

  getCanalVendaById(codCv: number) {
    return this.http.get('https://localhost:7095/api/canaisvenda/' + codCv);
  }

  deleteCanalVenda(codCv: number) {
    return this.http.delete('https://localhost:7095/api/canaisvenda/' + codCv);
  }
}
