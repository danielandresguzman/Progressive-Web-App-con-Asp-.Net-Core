using Microsoft.AspNetCore.Mvc;
using MiProgressApp.Clases;
using MiProgressApp.Models;
namespace MiProgressApp.Controllers
{
    public class TipoLibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoLibroCLS> listarTipoLibro(string filtro)
        {
            List<TipoLibroCLS> lista = new List<TipoLibroCLS>();
            using (db_a89ad8_bdbibliotecaContext bd = new db_a89ad8_bdbibliotecaContext())
            {
                if (filtro == null)
                {

                    lista = (from tl in bd.TipoLibros
                             where tl.Bhabilitado == 1
                             select new TipoLibroCLS
                             {
                                 Iidtipolibro = tl.Iidtipolibro,
                                 nombre = tl.Nombretipolibro,
                                 descripcion = tl.Descripcion
                             }).ToList();
                }
                else
                {

                    lista = (from tl in bd.TipoLibros
                             where tl.Bhabilitado == 1
                             && tl.Nombretipolibro.Contains(filtro)
                             select new TipoLibroCLS
                             {
                                 Iidtipolibro = tl.Iidtipolibro,
                                 nombre = tl.Nombretipolibro,
                                 descripcion = tl.Descripcion
                             }).ToList();
                }

                    
                return lista;
            }

        }
   
        public int guardarTipoLibro(TipoLibroCLS obj)
        {

            int res = 0;

            using (db_a89ad8_bdbibliotecaContext bd = new db_a89ad8_bdbibliotecaContext())
            {

                try
                {
                    if (obj.Iidtipolibro == 0)
                    {
                        TipoLibro tl = new TipoLibro();
                        tl.Nombretipolibro = obj.nombre;
                        tl.Descripcion = obj.descripcion;
                        tl.Bhabilitado = 1;
                        bd.TipoLibros.Add(tl);
                        bd.SaveChanges();
                        res = 1;
                    }
                    else
                    {
                        TipoLibro tl =
                            bd.TipoLibros.Where(p => p.Iidtipolibro == obj.Iidtipolibro).First();

                        tl.Nombretipolibro = obj.nombre;
                        tl.Descripcion = obj.descripcion;
                        bd.SaveChanges();
                        res = 1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                

            }

                return res;
        }
    
    }
}
