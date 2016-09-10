using System;
using System.Globalization;
using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class AddressModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Address model = bindingContext.Model as Address ?? new Address();

            model.Line1 = GetValue(bindingContext, "Line1");
            model.Line2 = GetValue(bindingContext, "Line2");
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            model.PostalCode = GetValue(bindingContext, "PostalCode");

            if (CheckProperty(model.PostalCode) && CheckProperty(model.City) && CheckProperty(model.Line1))
            {
                model.AdressSummary = $"{model.PostalCode} {model.City}, {model.Line1}";
            }
            else
            { 
                model.AdressSummary = "No personal address!";
            }

            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            ValueProviderResult result = context.ValueProvider.GetValue("HomeAddress." + name);

            if (result == null)
            {
                return "<Not found>";
            }

            if (result.AttemptedValue.Contains("PO BOX"))
            {
                return "<Not defined>";
            }

            switch (name)
            {
                case "Line2":
                    if (result.AttemptedValue == "")
                    {
                         return "<Not defined>";
                    }
                    return result.AttemptedValue;

                case "PostalCode":
                    if (result.AttemptedValue.Length < 6)
                    {
                         return "<Not defined>";
                    }
                    return result.AttemptedValue;
            }

            return result.AttemptedValue;
        }

        private bool CheckProperty(string value)
        {
            if (value == "<Not defined>" || value == "")
            {
                return false;
            }

            return true;
        }

    }
}
