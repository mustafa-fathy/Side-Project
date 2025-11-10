using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class ResultDto
    {
        public object Result { get; set; }
        public string Message { get; set; }
    }
    public class ResultDtoThirdParty<T>
    {
        public T Result { get; set; }
        
    }
}
