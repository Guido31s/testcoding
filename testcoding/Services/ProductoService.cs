using testcoding.Models;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Producto GetProductoById(int id)
    {
        // Implementa la lógica para obtener un producto por su ID
        return _unitOfWork.Productos.GetProductoById(id);
    }

    public IEnumerable<Producto> GetAllProductos()
    {
        // Implementa la lógica para obtener todos los productos
        return _unitOfWork.Productos.GetAllProductos();
    }

    public void AddProducto(Producto producto)
    {
        // Implementa la lógica para agregar un nuevo producto
        _unitOfWork.Productos.AddProducto(producto);
        _unitOfWork.Save();
    }

    public bool UpdateProducto(Producto producto)
    {
        try
        {
            // Lógica de actualización
            _unitOfWork.Productos.UpdateProducto(producto);
            _unitOfWork.Save();
            return true; // Actualización exitosa
        }
        catch (Exception ex)
        {
            // Manejar errores aquí, registrarlos, etc.
            return false; // Actualización fallida
        }
    }

    public bool DeleteProducto(int producto)
    {
        try
        {
            // Lógica de actualización
            _unitOfWork.Productos.DeleteProducto(producto);
            _unitOfWork.Save();
            return true; // Actualización exitosa
        }
        catch (Exception ex)
        {
            // Manejar errores aquí, registrarlos, etc.
            return false; // Actualización fallida
        }

    }
}
