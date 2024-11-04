namespace BackClub.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Clave externa para relacionar con Deporte
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
