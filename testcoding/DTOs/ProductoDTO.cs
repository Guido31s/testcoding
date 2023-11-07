namespace testcoding.DTOs
{
    public class ProductoDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CantMin { get; set; }
        public int? CantMax { get; set; }
        public int? CantTotal { get; set; }
        public int? CategoriaId { get; set; }
    }
}
