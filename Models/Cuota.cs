//namespace BackClub.Models
//{
//    public class Cuota
//    {
//        public int Id { get; set; }
//        public decimal Monto { get; set; }
//        public DateTime FechaPago { get; set; }
//        public string EstadoPago { get; set; } = "pendiente";

//        // Clave externa para relacionar con Deportista
//        public int DeportistaId { get; set; }
//        public Deportista Deportista { get; set; }

//        public override string ToString()
//        {
//            return $"Monto: {Monto}, Estado: {EstadoPago}";
//        }
//    }
//}
using System;
using System.Globalization;

namespace BackClub.Models
{
    public class Cuota
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoPago { get; set; } = "pendiente";

        // Clave externa para relacionar con Deportista
        public int DeportistaId { get; set; }
        public Deportista Deportista { get; set; }

        public override string ToString()
        {
            // Formatear Monto como moneda en pesos argentinos
            string montoFormateado = Monto.ToString("C", new CultureInfo("es-AR"));
            return $"Monto: {montoFormateado}, Estado: {EstadoPago}, Fecha de Pago: {FechaPago.ToShortDateString()}";
        }
    }
}
