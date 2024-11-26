namespace NailWarehouse.WebApplication.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; init; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
