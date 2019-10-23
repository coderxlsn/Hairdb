using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Model
{
    public class ApiResultModel<T>
    {

        public ApiResultModel() { }

        public ApiResultModel(int id, T res)
        {
            Status = id;
            Result = res;
        }
        public int Status { get; set; }
        public T Result { get; set; }
    }
}
