using System.Collections.Generic;
using testcoding.Models;

namespace testcoding.Repositorio
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProductos();
        Producto GetProductoById(int id);
        void AddProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
    }
}