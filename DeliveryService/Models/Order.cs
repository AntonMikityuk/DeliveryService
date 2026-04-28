using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Город отправителя обязателен для ввода")]
        public string SenderCity { get; set; } = string.Empty;
        [Required(ErrorMessage = "Адрес отправителя обязателен для ввода")]
        public string SenderAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Город получателя обязателен для ввода")]
        public string ReceiverCity { get; set; } = string.Empty;
        [Required(ErrorMessage = "Адрес получателя обязателен для ввода")]
        public string ReceiverAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Вес груза отправителя обязателен для ввода")]
        [Range(0.1, 10000, ErrorMessage = "Вес должен быть больше 0 и меньше 10000")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Дата забора груза обязательна для ввода")]
        public DateTime PickupDate { get; set; }
    }
}
