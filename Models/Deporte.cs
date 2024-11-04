namespace BackClub.Models
{
    public class Deporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public TimeSpan Hora { get; set; }

        // Lista de profesores que enseñan este deporte
        public List<Profesor> Profesores { get; set; } = new List<Profesor>();

        public override string ToString()
        {
            return Nombre;
        }
    }
}
