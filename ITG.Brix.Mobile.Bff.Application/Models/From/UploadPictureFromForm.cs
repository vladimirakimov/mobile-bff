using Microsoft.AspNetCore.Http;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class UploadPictureFromForm
    {
        public IFormFile File { get; set; }
    }
}
