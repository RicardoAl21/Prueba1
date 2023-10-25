import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { Cargo } from './Interfaces/cargo';
import { CargoService } from './Services/cargo.service';
import { Departamento } from './Interfaces/departamento';
import { DepartamentoService } from './Services/departamento.service';
import { User } from './Interfaces/user';
import { UserService } from './Services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogAddEditComponent } from './Dialogs/dialog-add-edit/dialog-add-edit.component';
import { DialogDeleteComponent } from './Dialogs/dialog-delete/dialog-delete.component';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['usuario', 'Primernombre', 'primerApellido',
  'segundoApellido','Departamento','Cargo','Actions'];
  dataSource = new MatTableDataSource<User>();
  listaDepartamento:Departamento[]=[];
  listCargo:Cargo[]=[];



  constructor(
    private _userServicio:UserService,
    private _cargoServicio:CargoService,
    private _departamentoServicio:DepartamentoService,
    public dialog:MatDialog,
    private _snackBar : MatSnackBar
    ){
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

    DialogoNuevoUser() {
      this.dialog.open(DialogAddEditComponent,{
        disableClose:true,
        width:"500px"
      }).afterClosed().subscribe(resultado=>{
        if(resultado === "creado"){
          this.mostrarUsuarios();
        }
      })
    }

    DialogoEditUser(dataUser:User) {
      this.dialog.open(DialogAddEditComponent,{
        width:"500px",
        data : dataUser
      }).afterClosed().subscribe(resultado=>{
        if(resultado === "editado"){
          this.mostrarUsuarios();
        }
      })
    }

    mostrarUsuarios(){
      this._userServicio.getList().subscribe({
        next:(dataResponse) =>{
          this.dataSource.data = dataResponse;
        },error:(e)=>{}
      })
    }

    mostrarUsuariosByCargo(idCargo:number){
      if(idCargo != null){
        this._userServicio.getListByCar(idCargo).subscribe(data =>{
          this.dataSource.data = data;
        })
      }else{
        this.mostrarUsuarios();
      }
    }

  mostrarUsuariosByDepartamento(idDepartamento:number){
    if(idDepartamento != null) {
      this._userServicio.getListByDep(idDepartamento).subscribe(data =>{
        this.dataSource.data = data;
      })
    }else{
      this.mostrarUsuarios();

    }
  }

    ngOnInit(): void {
      this.mostrarUsuarios();
    }

    mostrarAlerta(message: string, action: string) {
      this._snackBar.open(message, action,{
        horizontalPosition:'end',
        verticalPosition:'top',
        duration:3000
      });
    }

    DialogoDeleteUser(dataUser: User){
      this.dialog.open(DialogDeleteComponent,{
        data : dataUser
      }).afterClosed().subscribe(resultado=>{
        if(resultado === "eliminado"){
          this._userServicio.delete(dataUser.idUser).subscribe({
            next:(data)=>{
              this.mostrarAlerta("Usuario Eliminado","Listo");
              this.mostrarUsuarios();
            }, error:(e)=>{
              console.log(e)
              this.mostrarAlerta("No fue posible actualizar el registro", "Error");
            }
          })
        }
      })
    }
}
