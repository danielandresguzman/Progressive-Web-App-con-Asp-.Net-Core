using Microsoft.AspNetCore.Mvc;
using MiProgressApp.Clases;
using MiProgressApp.Models;

namespace MiProgressApp.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PersonaCLS> listarPersonas()
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();
            using(db_a89ad8_bdbibliotecaContext bd = new db_a89ad8_bdbibliotecaContext())
            {
                lista = (from persona in bd.Personas
                         where persona.Bhabilitado == 1
                         select new PersonaCLS
                         {
                             iidpersona = persona.Iidpersona,
                             nombrecompleto = persona.Nombre+" "+persona.Appaterno+" "+persona.Apmaterno,
                             correo = persona.Correo
                         }).ToList();

                return lista;
            }

        }
    }
}
