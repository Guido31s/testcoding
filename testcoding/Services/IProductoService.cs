using testcoding.Models;

public interface IProductoService
{
    Producto GetProductoById(int id);
    IEnumerable<Producto> GetAllProductos();
    void AddProducto(Producto producto);
    bool UpdateProducto(Producto producto);
    bool DeleteProducto(int id);
}
