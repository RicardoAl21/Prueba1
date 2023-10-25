export interface User {
  idUser:number,
  usuario:string,
  primernombre:string,
  segundonombre:string,
  primerapellido:string,
  segundoapellido:string,
  idDepartamento: number,
  nombreDepartamento?:string,
  idCargo: number,
  nombreCargo?:string
}
