using Almacenn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacenn.DAO
{
    public class CrudProductos
    {
        public void AgregarProducto(Producto2 ParametroProducto)
        {

            using (AlmacennContext db =
               new AlmacennContext())
            {

                Producto2 producto2 = new Producto2();
                producto2.Nombre = ParametroProducto.Nombre;
                producto2.Descripcion = ParametroProducto.Descripcion;
                producto2.Precio = ParametroProducto.Precio;
                producto2.Stock = ParametroProducto.Stock;
                db.Add(producto2);
                db.SaveChanges();
            }

        }
        public Producto2 ProductoIndividual(int id)
        {
            using (AlmacennContext bd = new AlmacennContext())
            {


                var buscar = bd.Producto2s.FirstOrDefault(x => x.Id == id);

                return buscar;

            }
        }
        public void ActualizarProducto(Producto2 ParametroProducto, int Lector)
        {

            using (AlmacennContext db =
                new AlmacennContext())
            {


                var buscar = ProductoIndividual(ParametroProducto.Id);
                if (buscar == null)
                {

                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParametroProducto.Nombre;
                    }
                    else
                    {

                        buscar.Descripcion = ParametroProducto.Descripcion;
                    }

                    db.Update(buscar);
                    db.SaveChanges();

                }

            }
        }
        public string EliminarProducto(int id)
        {
            using (AlmacennContext db =
                    new AlmacennContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {

                    db.Producto2s.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";
                }

            }
        }
        public List<Producto2> ListarProductos()
        {
            using (AlmacennContext db =
                   new AlmacennContext())
            {
                return db.Producto2s.ToList();
            }

        }




    }
}







