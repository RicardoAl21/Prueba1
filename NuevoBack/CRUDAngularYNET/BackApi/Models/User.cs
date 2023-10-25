using System;
using System.Collections.Generic;

namespace BackApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Usuario { get; set; }

    public string? Primernombre { get; set; }

    public string? Segundonombre { get; set; }

    public string? Primerapellido { get; set; }

    public string? Segundoapellido { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdCargo { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }
}
