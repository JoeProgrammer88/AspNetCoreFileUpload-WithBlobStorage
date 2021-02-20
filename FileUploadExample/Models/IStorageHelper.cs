using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public interface IStorageHelper
    {
        Task<string> UploadBlob(IFormFile photo);
    }
}