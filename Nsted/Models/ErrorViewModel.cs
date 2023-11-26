namespace Nsted.Models
{
    // Modell som representerer feilinformasjon som kan vises i applikasjonen.
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}