using testcoding.Models;

public class CategoriaService : ICategoriaService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Categorium GetCategoriaById(int id)
    {
        // Implementa la lógica para obtener una categoría por su ID
        return _unitOfWork.Categoria.GetCategoriaById(id);
    }

    public IEnumerable<Categorium> GetAllCategorias()
    {
        // Implementa la lógica para obtener todas las categorías
        return _unitOfWork.Categoria.GetAllCategorias();
    }

    public void AddCategoria(Categorium categoria)
    {
        // Implementa la lógica para agregar una nueva categoría
        _unitOfWork.Categoria.AddCategoria(categoria);
        _unitOfWork.Save();
    }

    public bool UpdateCategoria(Categorium categoria)
    {
        try
        {
            // Lógica de actualización
            _unitOfWork.Categoria.UpdateCategoria(categoria);
            _unitOfWork.Save();
            return true; // Actualización exitosa
        }
        catch (Exception ex)
        {
            // Manejar errores aquí, registrarlos, etc.
            return false; // Actualización fallida
        }
    }

    public bool DeleteCategoria(int id)
    {
        try
        {
            // Lógica de actualización
            _unitOfWork.Categoria.DeleteCategoria(id);
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
