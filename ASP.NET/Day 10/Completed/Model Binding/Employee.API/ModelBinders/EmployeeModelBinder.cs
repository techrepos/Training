using Employee.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.ModelBinders
{
    public class EmployeeModelBinder : IModelBinder
    {
        public Task BindModelAsync( ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            //var value = bindingContext.ValueProvider.GetValue("Form");
            //if (value.Length == 0)
            //    return Task.CompletedTask;
            string name = bindingContext.ValueProvider.GetValue("Name").FirstValue;
            string email = bindingContext.ValueProvider.GetValue("EmailAddress").FirstValue;

            var nameArray = name.Split(",");
            EmployeeEntity empModel = new EmployeeEntity
            {
                FirstName = nameArray[0],
                LastName = nameArray[1],
                EmailAddress = email
            };
            bindingContext.Result = ModelBindingResult.Success(empModel);

            return Task.CompletedTask;
            
        }
    }
}
