using testcoding.Models;

public interface ICategoriaRepository
{
    Categorium GetCategoriaById(int id);
    IEnumerable<Categorium> GetAllCategorias();
    void AddCategoria(Categorium categoria);
    void UpdateCategoria(Categorium categoria);
    void DeleteCategoria(int id);
}
