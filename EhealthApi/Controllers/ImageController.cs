using EhealthApi.Logic;
using EhealthApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EhealthApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IFileManagerLogic _fileManagerLogic;

        public ImageController(IFileManagerLogic fileManagerLogic)
        {
            _fileManagerLogic = fileManagerLogic;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            var toPredictImage = new imageToPredict();
            if (model.ImageFile != null)
                toPredictImage.uploadedUrl = await _fileManagerLogic.Upload(model);

            return Ok(new { toPredictImage });
        }
    }
}
