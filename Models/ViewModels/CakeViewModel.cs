namespace asp_exam_iliyana.Models.ViewModels
{
    public class CakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CakeFilling Filling { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public CakeViewModel(string name, string description, CakeFilling filling, double price, string imageUrl)
        {
            Name = name;
            Filling = filling;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
        }

    }
}
