using DatasInformation.Models;
using DatasInformation.Repositary.CategoryRepositary;
using DatasInformation.Repositary.PostRepositary;
using DatasInformation.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatasInformation.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _IPost;
        private readonly ICategory _ICategory;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public PostController(IPost post, ICategory category, IWebHostEnvironment webHostEnvironment)
        {
            _IPost = post;
            _ICategory = category;
            _WebHostEnvironment = webHostEnvironment;
        }

     
        public async Task<IActionResult> Create()
        {
         
            var categoryList = await _ICategory.GetAllAsync();
            var categorySelect = categoryList.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            PostVM postVM = new PostVM
            {
                Post = new Post(),
                Categories = categorySelect
            };
          return View(postVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostVM postVM)
        {
            if (ModelState.IsValid)
            {
                if (postVM.FeatureImage != null)
                {
                    string wwwRootPath = _WebHostEnvironment.WebRootPath;
                    string folderPath = Path.Combine(wwwRootPath, "images");

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(postVM.FeatureImage.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await postVM.FeatureImage.CopyToAsync(stream);
                    }

                    postVM.Post.FeatureImagePath = "/images/" + fileName;
                }

            }
            await _IPost.AddAsync(postVM.Post);
                        return RedirectToAction(nameof(Create));
        }
    }
}
