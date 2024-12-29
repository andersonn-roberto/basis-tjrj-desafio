import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutoresComponent } from './autores/autores.component';
import { AssuntosComponent } from './assuntos/assuntos.component';
import { CanaisvendaComponent } from './canaisvenda/canaisvenda.component';
import { LivrosComponent } from './livros/livros.component';
import { RelatorioComponent } from './relatorio/relatorio.component';
import { AutoresAddComponent } from './autores-add/autores-add.component';
import { AutoresEditComponent } from './autores-edit/autores-edit.component';
import { AssuntosAddComponent } from './assuntos-add/assuntos-add.component';
import { AssuntosEditComponent } from './assuntos-edit/assuntos-edit.component';
import { CanaisvendaAddComponent } from './canaisvenda-add/canaisvenda-add.component';
import { CanaisvendaEditComponent } from './canaisvenda-edit/canaisvenda-edit.component';
import { LivrosAddComponent } from './livros-add/livros-add.component';
import { LivrosEditComponent } from './livros-edit/livros-edit.component';

const routes: Routes = [
  { path: 'autores', component: AutoresComponent },
  { path: 'autoresAdd', component: AutoresAddComponent },
  { path: 'autoresEdit/:codAu', component: AutoresEditComponent },
  { path: 'assuntos', component: AssuntosComponent },
  { path: 'assuntosAdd', component: AssuntosAddComponent },
  { path: 'assuntosEdit/:codAs', component: AssuntosEditComponent },
  { path: 'canaisvenda', component: CanaisvendaComponent },
  { path: 'canaisvendaAdd', component: CanaisvendaAddComponent },
  { path: 'canaisvendaEdit/:codCv', component: CanaisvendaEditComponent },
  { path: 'livros', component: LivrosComponent },
  { path: 'livrosAdd', component: LivrosAddComponent },
  { path: 'livrosEdit/:codL', component: LivrosEditComponent },
  { path: 'relatorio', component: RelatorioComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
