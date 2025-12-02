using Project.Entities.Enums;

namespace Project.Validation.Models.ResponseModels.Categories
{
    public class CategoryResponseModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; }
    }
}
