using MVCTemplate.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

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

        //[Required]
        //[Display(Name = "Author")]
        //[DataType(DataType.Text)]
        //[StringLength(10)]
        public string Author { get; set; }

        //[Required]
        //[Display(Name = "Content")]
        //[DataType(DataType.Text)]
        //[StringLength(30)]
        public string Content { get; set; }
    }
}