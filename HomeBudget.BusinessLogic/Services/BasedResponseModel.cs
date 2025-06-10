using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services
{
    public class BasedResponseModel
    {
        public Boolean IsSuccess  { get; set; }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
