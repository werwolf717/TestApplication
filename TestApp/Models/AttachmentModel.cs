using TestApp.Models.Interfaces;

namespace TestApp.Models
{
    public class AttachmentModel : IAttachment
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }

        public AttachmentModel(string name, string v, long length)
        {
            FileName = name;
            MimeType = v;
            Size = (int)length;
        }
    }
}
