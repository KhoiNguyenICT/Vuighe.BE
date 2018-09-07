using Vuighe.Common.Extensions;

namespace Vuighe.Common.Errors
{
    public class CustomValidationError
    {
        public CustomValidationError(string field, string message)
        {
            Field = field?.ToCamelCasing();
            Message = message;
        }

        public CustomValidationError(string message)
        {
            Message = message;
        }

        public string Field { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Field = {Field} | Message = {Message}";
        }
    }
}
