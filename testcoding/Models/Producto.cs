using System;
using System.Collections.Generic;

namespace testcoding.Models;

public partial class Producto
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? CantMin { get; set; }

    public int? CantMax { get; set; }

    public int? CantTotal { get; set; }

    public int? CategoriaId { get; set; }

    public int ProductoId { get; set; }

    public virtual Categorium? Categoria { get; set; }
}
