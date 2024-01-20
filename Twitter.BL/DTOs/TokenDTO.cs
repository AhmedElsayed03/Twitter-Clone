using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.BL.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiry { get; set; }
        public string UserId { get; set; } = string.Empty;

    }
}
