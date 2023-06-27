namespace N3MerxImsApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ContactId { get; set; }
        public int ProductTypeId { get; set; }
        public string ContactProductId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int InStock { get; set; }
        public int CalcStock { get; set; }
        public string CalcStockNote { get; set; } = string.Empty;
        public DateTime CalcStockDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}

