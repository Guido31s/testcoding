﻿using testcoding.Models;
using testcoding.Repositorio;

public class ProductoRepository : IProductoRepository
{
    private readonly TestCodingContext _context;

    public ProductoRepository(TestCodingContext context)
    {
        _context = context;
    }

    public Producto GetProductoById(int id)
    {
        return _context.Productos.Find(id);
    }

    public IEnumerable<Producto> GetAllProductos()
    {
        return _context.Productos.ToList();
    }

    public void AddProducto(Producto producto)
    {
        _context.Productos.Add(producto);
    }

    public void UpdateProducto(Producto producto)
    {
        _context.Productos.Update(producto);
    }

    public void DeleteProducto(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
        }
    }
}
