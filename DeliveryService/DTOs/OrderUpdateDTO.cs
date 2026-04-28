using System.ComponentModel.DataAnnotations;
namespace DeliveryService.DTOs
{
    public class OrderUpdateDTO
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
        [Range(0.1, 10000, ErrorMessage = "Вес должен быть от 0.1 до 10000 кг")]
        public double Weight { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
    }
}
