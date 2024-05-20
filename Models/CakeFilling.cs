using System.ComponentModel.DataAnnotations;

namespace asp_exam_iliyana.Models
{
    public class CakeFilling
    {
        private int _id;
        public int Id { get { return _id; } set{ _id = value; } } 

        private string _name;
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Min 2 characters and max 30 characters")]
        public string Name { get { return _name; } set { _name = value; } }

        public CakeFilling()
        {

        }

        public CakeFilling(string name)
        {
            Name = name;
        }
    }
}
