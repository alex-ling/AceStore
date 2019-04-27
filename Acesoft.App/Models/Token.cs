using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.Models
{
    public class Token
    {
        public string Access_Token { get; set; }
        public DateTime Created { get; set; }
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
        public string Token_Type { get; set; }
    }
}
