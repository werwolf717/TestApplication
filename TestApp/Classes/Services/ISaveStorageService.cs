using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestApp.Classes.Services
{
    public interface ISaveStorageService
    {
        public Task LoadFile(IFormFile _file);
    }
}
