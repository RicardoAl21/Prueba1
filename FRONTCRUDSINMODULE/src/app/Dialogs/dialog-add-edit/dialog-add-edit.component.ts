import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Departamento } from 'src/app/Interfaces/departamento';
import { Cargo } from 'src/app/Interfaces/cargo';
import { User } from 'src/app/Interfaces/user';
import { DepartamentoService } from 'src/app/Services/departamento.service';
import { CargoService } from 'src/app/Services/cargo.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css']
})
export class DialogAddEditComponent implements OnInit{
formUser:FormGroup;
tituloAccion:string = "Nuevo";
botonAccion:string = "Guardar";
listaDepartamento:Departamento[]=[];
listCargo:Cargo[]=[];

constructor(
  private dialogRef:MatDialogRef<DialogAddEditComponent>,
  private fb:FormBuilder,
  private _snackBar:MatSnackBar,
  private _departamentoServicio: DepartamentoService,
  private _cargoServicio: CargoService,
  private _userServicio: UserService,
  @Inject (MAT_DIALOG_DATA) public dataUser:User
){

  this.formUser = this.fb.group({
    usuario:["",Validators.required],
    primernombre:["",Validators.required],
    segundonombre:["",Validators.required],
    primerapellido:["",Validators.required],
    segundoapellido:["",Validators.required],
    IdDepartamento:[null,Validators.required],
    IdCargo:[null,Validators.required]
  })

  this._departamentoServicio.getList().subscribe({
    next:(datacargo)=>{
      this.listaDepartamento = datacargo;
    },error:(e)=>{}
  })

  this._cargoServicio.getList().subscribe({
    next:(datadepa)=>{
      this.listCargo = datadepa;
    },error:(e)=>{}
  })
}

mostrarAlerta(message: string, action: string) {
  this._snackBar.open(message, action,{
    horizontalPosition:'end',
    verticalPosition:'top',
    duration:3000
  });
}

addEditUser(){
 const modelo : User ={
  idUser : 0,
  usuario:this.formUser.value.usuario,
  primernombre:this.formUser.value.primernombre,
  segundonombre:this.formUser.value.segundonombre,
  primerapellido:this.formUser.value.primerapellido,
  segundoapellido:this.formUser.value.segundoapellido,
  idDepartamento:this.formUser.value.IdDepartamento,
  idCargo:this.formUser.value.IdCargo
 }

  if(this.dataUser == null){
    this._userServicio.add(modelo).subscribe({
      next:(data)=>{
        this.mostrarAlerta("Empleado fue creado","Listo");
        this.dialogRef.close("creado");
      }, error:(e)=>{
        this.mostrarAlerta("No fue posible crear el registro", "Error");
      }
   })
  }else{
    this._userServicio.update(this.dataUser.idUser, modelo).subscribe({
      next:(data)=>{
        this.mostrarAlerta("Datos actualizados","Listo");
        this.dialogRef.close("editado");
      }, error:(e)=>{
        this.mostrarAlerta("No fue posible actualizar el registro", "Error");
      }
   })
  }
}

  ngOnInit(): void {
      if(this.dataUser){
        this.formUser.patchValue({
          usuario: this.dataUser.usuario,
          primernombre: this.dataUser.primernombre,
          segundonombre: this.dataUser.segundonombre,
          primerapellido: this.dataUser.primerapellido,
          segundoapellido: this.dataUser.segundoapellido,
          IdDepartamento: this.dataUser.idDepartamento,
          IdCargo: this.dataUser.idCargo
      })
      this.tituloAccion="Editar";
      this.botonAccion="Actualizar";
      }
  }
}
