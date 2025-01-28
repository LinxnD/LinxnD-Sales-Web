using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
