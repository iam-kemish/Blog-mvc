using DatasInformation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatasInformation.Views.ViewModels
{
    public class PostVM
    {
        public Post? Post { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IFormFile? FeatureImage { get; set; }
    }
}
