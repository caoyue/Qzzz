using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qzzz.Admin
{
    public class BoolResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public class BoolResult<T> : BoolResult
    {
        public T Result { get; set; }
    }
}
