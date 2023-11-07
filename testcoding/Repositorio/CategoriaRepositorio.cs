using testcoding.Models;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly TestCodingContext _context;

    public CategoriaRepository(TestCodingContext context)
    {
        _context = context;
    }

    public Categorium GetCategoriaById(int id)
    {
        return _context.Categoria.Find(id);
    }

    public IEnumerable<Categorium> GetAllCategorias()
    {
        return _context.Categoria.ToList();
    }

    public void AddCategoria(Categorium categoria)
    {
        _context.Categoria.Add(categoria);
    }

    public void UpdateCategoria(Categorium categoria)
    {
        _context.Categoria.Update(categoria);
    }

    public void DeleteCategoria(int id)
    {
        var categoria = _context.Categoria.Find(id);
        if (categoria != null)
        {
            _context.Categoria.Remove(categoria);
        }
    }
}
