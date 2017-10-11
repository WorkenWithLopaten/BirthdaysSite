using MVCTemplate.Data.Models;
using System.Collections.Generic;

namespace BirthdaySite.ViewModels.Forum
{
    public class GroupViewModel
    {
        public string Name { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }
    }
}