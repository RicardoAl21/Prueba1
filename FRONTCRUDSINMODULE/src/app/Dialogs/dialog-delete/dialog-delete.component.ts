import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from 'src/app/Interfaces/user';

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html',
  styleUrls: ['./dialog-delete.component.css']
})
export class DialogDeleteComponent implements OnInit{
/**
 *
 */
constructor(
  private dialogRef:MatDialogRef<DialogDeleteComponent>,
  @Inject (MAT_DIALOG_DATA) public dataUser:User
  ) { }


  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  confirmar_eliminar(){
    if(this.dataUser){
      this.dialogRef.close("eliminado")
    }
  }
}
