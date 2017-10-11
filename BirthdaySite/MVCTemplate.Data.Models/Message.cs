using MVCTemplate.Data.Common.Models;

namespace MVCTemplate.Data.Models
{
    public class Message : BaseModel<int>
    {
        public Message()
        {

        }

        public Message(string author, string content)
        {
            this.Author = author;
            this.Content = content;
        }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}