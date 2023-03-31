using System;
using System.Collections.Generic;

namespace Almacenn.Models;

public partial class Producto2
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int Stock { get; set; }
}
