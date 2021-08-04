using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Classes.Services
{
    public interface ISaveContentService
    {
        public ISaveDbService saveDb { get; set;}
        public ISaveStorageService saveStorage { get; set; }

        public void SaveDbContent();
        public void SaveStorageContent();
    }
}
