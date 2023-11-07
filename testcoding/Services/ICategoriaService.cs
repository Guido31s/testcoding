using testcoding.Models;

public interface ICategoriaService
{
    Categorium GetCategoriaById(int id);
    IEnumerable<Categorium> GetAllCategorias();
    void AddCategoria(Categorium categoria);
    bool UpdateCategoria(Categorium categoria);
    bool DeleteCategoria(int id);
}
