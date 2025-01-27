using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;

        [ForeignKey("ProductId")]
        public Product? Product { get; set; } 
        
    }
}