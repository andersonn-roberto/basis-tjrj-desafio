import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AutoresService } from '../autores/autores.service';

@Component({
  selector: 'app-autores-add',
  standalone: false,
  
  templateUrl: './autores-add.component.html',
  styleUrl: './autores-add.component.css'
})
export class AutoresAddComponent {
  addAutorForm: AutorForm = new AutorForm();

  @ViewChild("AutorForm")
  AutorForm!: NgForm;

  constructor(private readonly autoresService: AutoresService, private readonly router: Router) { }

  addAutor() {
    this.autoresService.addAutor(this.addAutorForm)
      .subscribe(() => {
        this.router.navigate(['/autores']);
      });
  }
}

export class AutorForm {
  codAu: number = 0;
  nome: string = "";
}
