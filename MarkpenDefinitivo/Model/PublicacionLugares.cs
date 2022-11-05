using System.ComponentModel.DataAnnotations;

namespace MarkpenDefinitivo.Model
{
    public class PublicacionLugares
    {
                       
        [Key]
        public int idPublicacionLugares { get; set; }

        public string DireccionLugar { get; set; }

        public string NombreLugar { get; set; }

        public string DescripcionLugar { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string UrlImagen { get; set; }

        public string DescripcionPublicacion { get; set; }
    }
}

