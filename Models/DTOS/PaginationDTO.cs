namespace Web_API.Models.DTOS
{
    public class PaginationDTO
    {
        public string? ProductName { get; set; }
        public decimal? Price { get; set; } = default!;
    }
}
