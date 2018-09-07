using System.Collections.Generic;
using System.Linq;

namespace Vuighe.Common.Errors
{
    public class CustomError
    {
        public int StatusCode { get; set; }
        private readonly string _message;
        public IDictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
        public IEnumerable<string> Messages
        {
            get
            {
                if (ValidationErrors != null && ValidationErrors.Any())
                {
                    var listMessages = new List<string>();
                    foreach (var err in ValidationErrors)
                    {
                        if (err.Value != null && err.Value.Any())
                            listMessages.AddRange(err.Value);
                    }
                    return listMessages;
                }

                return !string.IsNullOrEmpty(_message) ? new List<string> { _message } : new List<string>();
            }
        }

        public CustomError(int statusCode = 400)
        {
            ValidationErrors = new Dictionary<string, IEnumerable<string>>();
            StatusCode = statusCode;
        }

        public CustomError(string message, int statusCode = 400)
        {
            _message = message;
            StatusCode = statusCode;
        }

        public CustomError(IEnumerable<CustomValidationError> validationErrors, int statusCode = 400)
        {
            AddErrors(validationErrors);
            StatusCode = statusCode;
        }

        public CustomError()
        {
        }

        public void AddError(CustomValidationError validationError)
        {
            if (ValidationErrors == null)
            {
                ValidationErrors = new Dictionary<string, IEnumerable<string>>();
            }
            var fieldName = validationError.Field ?? "Generic";
            if (ValidationErrors.ContainsKey(fieldName))
            {
                var value = ValidationErrors[fieldName];
                var enumerable = value as string[] ?? value.ToArray();
                if (value != null && enumerable.Any())
                {
                    enumerable.Append(validationError.Message);
                }
                else
                {
                    ValidationErrors[fieldName] = new List<string> { validationError.Message };
                }
            }
            else
            {
                ValidationErrors[fieldName] = new List<string> { validationError.Message };
            }
        }

        public void AddErrors(IEnumerable<CustomValidationError> validationErrors)
        {
            var errors = validationErrors as IList<CustomValidationError> ?? validationErrors.ToList();
            if (validationErrors == null || !errors.Any())
                return;
            foreach (var err in errors)
            {
                AddError(err);
            }
        }
    }
}
