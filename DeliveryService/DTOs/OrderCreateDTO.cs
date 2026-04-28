using System.ComponentModel.DataAnnotations;
namespace DeliveryService.DTOs
{
    public class OrderCreateDTO
    {
        [Required]
        public string SenderCity { get; set; } = string.Empty;
        [Required]
        public string SenderAddress { get; set; } = string.Empty;
        [Required]
        public string ReceiverCity { get; set; } = string.Empty;
        [Required]
        public string ReceiverAddress { get; set; } = string.Empty;
        [Required]
        [Range(0.1, 10000)]
        public double Weight { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
    }
}
