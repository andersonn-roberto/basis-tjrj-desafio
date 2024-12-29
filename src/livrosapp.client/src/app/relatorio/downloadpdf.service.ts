import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DownloadpdfService {

  constructor(readonly http: HttpClient) { }

  getPdf() {
    return this.http.get('https://localhost:7095/api/relatorios', {
      responseType: "arraybuffer",
    });
  }
}
