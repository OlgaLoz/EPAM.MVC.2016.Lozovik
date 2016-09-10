using System;
using System.Globalization;
using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = bindingContext.Model as Person ?? new Person();

            model.PersonId = int.Parse((string)GetValue(bindingContext, "PersonId"));
            model.BirthDate = (DateTime)GetValue(bindingContext, "BirthDate");
            model.FirstName = (string)GetValue(bindingContext, "FirstName");
            model.LastName = (string)GetValue(bindingContext, "LastName");       
            model.Role = (Role)GetValue(bindingContext, "Role", controllerContext);
            model.HomeAddress = (Address)new AddressModelBinder().BindModel(controllerContext, bindingContext);

            return model;
        }

        private object GetValue(ModelBindingContext context, string name, ControllerContext controllerContext = null)
        {
            ValueProviderResult result = context.ValueProvider.GetValue(name);

            if (result == null)
            {
                return "<Not found>";
            }

            switch (name)
            {
                case "BirthDate":
                    DateTime dt;
                    DateTime.TryParseExact(result.AttemptedValue, "yyyy*MM*dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dt);            
                    return dt;

                case "Role":
                    if (result.AttemptedValue == "" || result.AttemptedValue == "Guest")
                    {
                        return Role.Guest;
                    }

                    if (controllerContext != null && controllerContext.RequestContext.HttpContext.Request.IsLocal && result.AttemptedValue == "Admin")
                    {
                        return Role.Admin;
                    }

                    return Role.User;
            }

            return result.AttemptedValue;
        }
    }
}