using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProjectPyP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PyPController : ControllerBase
    {
        public string substring = "";
        string fecha = DateTime.Now.ToString("dd/MM/yyyy");
        string hora = DateTime.Now.ToString("HH:mm");
        public string dia = DateTime.Now.ToString("dddd", new CultureInfo("es-ES"));

        List<PyP> PyPs = new List<PyP>()
        {
            new PyP()
            {
                Id= 1,
                Name= "Hoy NO puede Circular, desde las 6:00 a 9:30 am y de 16:00 a 20:00 pm",
            },

            new PyP()
            {
                Id= 2,
                Name= "Si puede Circular",
            },

            new PyP()
            {
                Id= 3,
                Name= "Ingrese bien la placa, porfavor",
            }
        };

        [HttpGet]
        public ActionResult<PyP> Get(string Id)
        {

            string nom = "";

            int aux = 0;

            int log = Id.Length;

            if (log == 6) { substring = Id.Substring(5, 1); }
            if (log == 7) { substring = Id.Substring(6, 1); }
            if (log != 6 && log !=7) { aux = 3; }


            if (substring == "1" || substring == "2") { nom = "lunes"; if (nom == dia) { aux = 1; } else { aux = 2; } }
            if (substring == "3" || substring == "4") { nom = "martes"; if (nom == dia) { aux = 1; } else { aux = 2; } }
            if (substring == "5" || substring == "6") { nom = "miercoles"; if (nom == dia) { aux = 1; } else { aux = 2; } }
            if (substring == "7" || substring == "8") { nom = "jueves"; if (nom == dia) { aux = 1; } else { aux = 2; } }
            if (substring == "9" || substring == "0") { nom = "viernes"; if (nom == dia) { aux = 1; } else { aux = 2; } }

            var PyP = PyPs.Where(d => d.Id == aux).FirstOrDefault();
            if (PyP == null) return NotFound();

            return PyP;
        }
    }

    public class PyP
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /*public void miboton_Click(object sender, EventArgs e)
    {

    }

    Button miBoton = (button)Page.FindControl('miBoton');
    miBoton.Click+= new EventHandler(BotonPresionar);

    protected void BotonPresionar()
    {
    }*/
}
