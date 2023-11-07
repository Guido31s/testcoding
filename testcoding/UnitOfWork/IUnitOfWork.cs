using testcoding.Repositorio;

public interface IUnitOfWork
{
    IProductoRepository Productos { get; }
    ICategoriaRepository Categoria { get; }
    void Save();
}
