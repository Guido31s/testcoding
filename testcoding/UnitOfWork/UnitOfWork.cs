using testcoding.Models;
using testcoding.Repositorio;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestCodingContext _context;

    public IProductoRepository Productos { get; }
    public ICategoriaRepository Categoria { get; }

    public UnitOfWork(TestCodingContext context)
    {
        _context = context;
        Productos = new ProductoRepository(_context);
        Categoria = new CategoriaRepository(_context);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
