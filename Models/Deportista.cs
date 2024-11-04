namespace BackClub.Models
{
    public class Deportista
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;

        // Clave externa para relacionar con Deporte
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }

        // Lista de cuotas
        public List<Cuota> Cuotas { get; set; } = new List<Cuota>();

        public bool CuotaAlDia()
        {
            return Cuotas.Any(cuota => cuota.EstadoPago == "pagado");
        }

        public override string ToString()
        {
            return ApellidoNombre;
        }
    }
}
