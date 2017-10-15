using MVCTemplate.Data.Common.Models;
using System.Collections.Generic;

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

        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
