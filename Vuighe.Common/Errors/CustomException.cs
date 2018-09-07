using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vuighe.Common.Errors
{
    public class CustomException : Exception
    {
        public CustomError Error { get; set; }

        public string SerializedErrors => JsonConvert.SerializeObject(Error, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

        public CustomException()
        {
        }

        public CustomException(string field, string message)
        {
            Error = new CustomError(new List<CustomValidationError> { new CustomValidationError(field, message) });
        }

        public CustomException(string message, int statusCode = 400)
        {
            Error = new CustomError(new List<CustomValidationError> { new CustomValidationError(message) }, statusCode);
        }

        public CustomException(CustomValidationError validationError)
        {
            Error = new CustomError(new List<CustomValidationError> { validationError });
        }

        public CustomException(IEnumerable<CustomValidationError> validationErrors)
        {
            Error = new CustomError(validationErrors);
        }
    }
}
