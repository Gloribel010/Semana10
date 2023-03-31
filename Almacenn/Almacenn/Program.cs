// See https://aka.ms/new-console-template for more information
/*onsole.WriteLine("Hello, World!");*/

using Almacenn.DAO;
using Almacenn.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Xml;

CrudProductos crudProductos = new CrudProductos();
Producto2 Producto = new Producto2();

bool Continuar = true;
while (Continuar)


{
    Console.WriteLine("Menu");
    Console.WriteLine("seleccione 1 para realizar insertar productos");
    Console.WriteLine("seleccione 2 para realizar una actualizacion de productos");
    Console.WriteLine("seleccione 3 para realizar una eliminacion de productos");
    Console.WriteLine("seleccione 4 para obtener un listado de productos");
    var Menu = Convert.ToInt32(Console.ReadLine());


    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa el nombre del producto");
                Producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa la descripcion");
                Producto.Descripcion = Console.ReadLine();
                Console.WriteLine("Ingresa el precio del producto");
                Producto.Precio = Convert.ToInt32(Console.ReadLine());
                crudProductos.AgregarProducto(Producto);
                Console.WriteLine("El producto se ingreso correctamente");
                Console.WriteLine("Pulsa 1 para continuar insertando productos");
                Console.WriteLine("Pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Ingresa el ID del producto a actualizar");
            var ProductoIndividualU = crudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualU == null)
            {
                Console.WriteLine("El producto no existe");
            }
            else
            {
                Console.WriteLine($"Nombre {ProductoIndividualU.Nombre} , Descripcion {ProductoIndividualU.Descripcion}");


                Console.WriteLine("Para actulizar nombre coloca el # 1");

                Console.WriteLine("Para actulizar la descripcion coloca el # 2");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Ingrese el nombre");
                    ProductoIndividualU.Nombre = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingrese la descripcion ");
                    ProductoIndividualU.Descripcion = Console.ReadLine();
                }
                crudProductos.ActualizarProducto(ProductoIndividualU, Lector);
                Console.WriteLine("Actualizacion correcta");
            }
            break;

        case 3:
            Console.WriteLine("Ingresa el ID del producto a eliminar");
            var ProductoIndividualD = crudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar producto");
                Console.WriteLine($"Nombre {ProductoIndividualD.Nombre} , Descripcion {ProductoIndividualD.Descripcion}");
                Console.WriteLine("El producto encontrado es el correcto?");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(ProductoIndividualD.Id);
                    Console.WriteLine(crudProductos.EliminarProducto(Id));
                }
                else
                {
                    Console.WriteLine("Inicia de nuevo ");
                }

            }
            break;
        case 4:
            Console.WriteLine("Lista de productos");
            var ListarProducto = crudProductos.ListarProductos();
            foreach (var iteracionProducto in ListarProducto)
            {
                Console.WriteLine($"{iteracionProducto.Id} , {iteracionProducto.Nombre} , {iteracionProducto.Descripcion}");
            }
            break;
    }
    Console.WriteLine("Desea continuar con mas transacciones ?");
    var cont = Console.ReadLine();
    if (cont.Equals("N")) { 
 
        Continuar = false;
    }
}
