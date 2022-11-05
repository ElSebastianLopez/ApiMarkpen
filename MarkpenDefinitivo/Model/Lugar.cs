using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MarkpenDefinitivo.Model
{
    public class Lugar
    {                
        [Key]
        public int IdLugar { get; set; }

        public string DireccionLugar { get; set; }

        public string NombreLugar { get; set; }
        public string DescripcionLugar { get; set; }
    }
}
