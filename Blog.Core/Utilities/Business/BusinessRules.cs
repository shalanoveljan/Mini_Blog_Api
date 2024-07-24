using Blog.Core.Utilities.Results.Abstract;
using Blog.Core.Utilities.Results.Concrete.ErrorResults;
using Blog.Core.Utilities.Results.Concrete.SuccessResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Check(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}
