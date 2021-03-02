using Employee.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.ModelBinders
{
    public class EmployeeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType.Equals(typeof(EmployeeEntity)))
                return new EmployeeModelBinder();
            return null;

        }
    }
}
