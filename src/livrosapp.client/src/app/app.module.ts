import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AutoresComponent,
    AssuntosComponent,
    CanaisvendaComponent,
    LivrosComponent,
    RelatorioComponent,
    AutoresAddComponent,
    AutoresEditComponent,
    AssuntosAddComponent,
    AssuntosEditComponent,
    CanaisvendaAddComponent,
    CanaisvendaEditComponent,
    LivrosAddComponent,
    LivrosEditComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
