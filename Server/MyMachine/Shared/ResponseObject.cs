using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseObject<T1>
    {
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; }
        public T1 Result { get; set; }
    }
}
