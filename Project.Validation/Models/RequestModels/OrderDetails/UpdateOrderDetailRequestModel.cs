namespace Project.Validation.Models.RequestModels.OrderDetails
{
    public class UpdateOrderDetailRequestModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
