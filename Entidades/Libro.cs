using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        public Guid ID_Libro { get; set; }
        public string ISBN { get; set; }
        public string ISBN_10 { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Paginas { get; set; }
        public string DatosEnvio { get; set; }
        public Editorial ID_Editorial { get; set; }
        public byte[] image { get; set; }

        public Libro()
        {
            ID_Libro = Guid.NewGuid();
        }

    }
}
