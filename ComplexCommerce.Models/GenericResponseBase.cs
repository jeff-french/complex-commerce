using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ComplexCommerce.Models
{
    public abstract class GenericResponseBase<T>
    {
        public virtual ResponseStatus ResponseStatus { get; set; }
        public virtual T Result { get; set; }
    }
}
