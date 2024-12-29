import { Component } from '@angular/core';
import { DownloadpdfService } from './downloadpdf.service';

@Component({
  selector: 'app-relatorio',
  standalone: false,
  
  templateUrl: './relatorio.component.html',
  styleUrl: './relatorio.component.css'
})
export class RelatorioComponent {

  constructor(private readonly downloadService: DownloadpdfService) { }

  ngOnInit() {
    this.downloadService.getPdf()
      .subscribe((response) => {
        const pdfBlob = new Blob([response], { type: 'application/pdf' });

        const temporaryUrl = URL.createObjectURL(pdfBlob);

        const temporaryAnchor = document.createElement('a');
        temporaryAnchor.href = temporaryUrl;
        temporaryAnchor.download = 'relatorio.pdf';

        document.body.appendChild(temporaryAnchor);
        temporaryAnchor.click();
        temporaryAnchor.remove();
    });
  }
}
