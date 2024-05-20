using System.ComponentModel.DataAnnotations;

namespace asp_exam_iliyana.Models
{
    public class Cake
    {
        private Guid _id = Guid.NewGuid();
        [Key]
        public Guid Id { get { return _id; } set { _id = value; } }

        private string _name;
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Min 3 characters and max 40 characters")]
        public string Name { get { return _name; } set { _name = value; } }

        private int _fillingId;
        [Required]
        public int FillingId { get { return _fillingId; } set { _fillingId = value; } }
        public CakeFilling Filling { get; set; }

        private string _description;
        [Required]
        [StringLength(100, MinimumLength = 50, ErrorMessage ="Min 50 characters and max 100 characters")]
        public string Description { get { return _description; } set { _description = value; } }

        private double _price;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The price must be a positive value.")]
        public double Price { get { return _price; } set { _price = value; } }

        private string _imageUrl;
        public string ImageUrl { get { return _imageUrl; } set { _imageUrl = value; } }

        public Cake()
        {

        }
        public Cake (string name, int fillingId, string description, double price, string imageUrl = "")
        {
            Name = name;
            FillingId = fillingId;
            Filling.Id = FillingId;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}