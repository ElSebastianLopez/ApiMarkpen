using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MarkpenDefinitivo.Model
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }

        
        public DateTime FechaPublicacion { get; set; }

        public string UrlImagen { get; set; }

        public string DescripcionPublicacion { get; set; }

        public int? idLugar { get; set; }    

        public virtual Lugar lugar { get; set; }

       
     }
}
