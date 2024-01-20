using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Groupchat
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        [MaxLength(280), MinLength(1)]
        public string Description { get; set; } = string.Empty;
        public List<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    }
}
