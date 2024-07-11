using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL_ALMACEN.PRECENTACION
{
    public class Propiedades_Articulos
    {
        public int codigo_articulos { get; set; }
        public string descripcion_articulos { get; set; }
        public string marca_articulos { get; set; }
        public int codigo_um { get; set; }
        public int codigo_categoria { get; set; }
        public decimal stock_actual { get; set; }
        public string fecha_crea { get; set; }
        public string fecha_modifica { get; set; }
    }
}
