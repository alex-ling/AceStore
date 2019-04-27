using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.Models
{
    public class Response<T>
    {
        public int Status { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }
    }
}
