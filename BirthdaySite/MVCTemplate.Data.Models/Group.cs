using MVCTemplate.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCTemplate.Data.Models
{
    public class Group : BaseModel<int>
    {
        public Group()
        {
            this.Messages = new List<Message>();
        }

        public Group(string name)
        {
            this.Name = name;
            this.Messages = new List<Message>();
        }

        //[Required]
        //[Display(Name = "GroupName")]
        //[DataType(DataType.Text)]
        //[StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
