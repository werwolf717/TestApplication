using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestApp.Classes.Interfaces
{
    public interface ISaveStorageService
    {
        public Task LoadFile(IFormFile _file);
    }
}
