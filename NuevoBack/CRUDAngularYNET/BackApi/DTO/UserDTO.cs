namespace BackApi.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        public string? Usuario { get; set; }

        public string? Primernombre { get; set; }

        public string? Segundonombre { get; set; }

        public string? Primerapellido { get; set; }

        public string? Segundoapellido { get; set; }

        public int? IdDepartamento { get; set; }

        public string? NombreDepartamento { get; set; }

        public int? IdCargo { get; set; }

        public string? NombreCargo { get; set; }
    }
}
