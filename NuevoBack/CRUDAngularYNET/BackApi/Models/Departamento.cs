﻿using System;
using System.Collections.Generic;

namespace BackApi.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public int? IdUsuarioCreacion { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
