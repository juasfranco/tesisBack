using EhealthApi.Models;
using System.Threading.Tasks;

namespace EhealthApi.Logic
{
    public interface IFileManagerLogic
    {
        Task<string> Upload(FileModel model);
        Task<byte[]> Get(string imageName);
    }
}
