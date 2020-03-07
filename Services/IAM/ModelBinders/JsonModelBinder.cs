using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nmro.IAM.ModelBinders
{
    public class JsonModelBinder : IModelBinder
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<JsonModelBinder> _logger;

        private readonly string key;

        public JsonModelBinder(IConfiguration configuration, ILogger<JsonModelBinder> logger)
        {
            _logger = logger;
            _configuration = configuration;

            key = _configuration.GetValue<string>("JsonQueryKeyParam");
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(key);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var jsonString = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(jsonString))
            {
                return Task.CompletedTask;
            }

            try
            {
                var modelObject = JsonSerializer.Deserialize(jsonString, bindingContext.ModelType, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Set result state of binding the model
                bindingContext.Result = ModelBindingResult.Success(modelObject);
            }
            catch (Exception)
            {
                bindingContext.ModelState
                    .TryAddModelError(bindingContext.ModelName, "Invalid data");

                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
