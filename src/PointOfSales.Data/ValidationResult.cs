namespace PointOfSale.Data
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string message = null)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
