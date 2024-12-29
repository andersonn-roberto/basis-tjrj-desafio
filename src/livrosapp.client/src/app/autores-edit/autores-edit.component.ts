import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AutoresService } from '../autores/autores.service';

@Component({
  selector: 'app-autores-edit',
  standalone: false,
  
  templateUrl: './autores-edit.component.html',
  styleUrl: './autores-edit.component.css'
})
export class AutoresEditComponent {
  editAutorForm: AutorForm = new AutorForm();

  @ViewChild("AutorForm")
  AutorForm!: NgForm;

  codAu: any;

  constructor(private readonly autoresService: AutoresService, private readonly router: Router, private readonly route: ActivatedRoute) { }

  ngOnInit() {
    this.codAu = this.route.snapshot.params["codAu"];
    this.getAutorById();
  }

  getAutorById() {
    this.autoresService.getAutorById(this.codAu)
      .subscribe((response) => {
        this.editAutorForm = response
        console.log(this.editAutorForm);
      });
  }

  editAutor() {
    this.autoresService.editAutor(this.editAutorForm)
      .subscribe(() => {
        this.router.navigate(['/autores']);
      });
  }
}

export class AutorForm {
  codAu: number = 0;
  nome: string = "";
}
