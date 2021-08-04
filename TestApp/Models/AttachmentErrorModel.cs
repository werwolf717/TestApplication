using TestApp.Models.Interfaces;

namespace TestApp.Models
{
    public class AttachmentErrorModel : IAttachmentError
    {
        public string Reason { get; }
        public string Message { get; }
        public AttachmentErrorModel(string _Reason, string _Message)
        {
            Reason = _Reason;
            Message = _Message;
        }
    }
}
