using Microsoft.AspNetCore.Mvc;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
