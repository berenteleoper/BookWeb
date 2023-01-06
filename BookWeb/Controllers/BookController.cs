using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers
{
    public class BookController : Controller
    {
        static IList<Book> BookList = new List<Book>();
       

        public IActionResult Index()
        {
            return View(BookList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Book model)
        {
            int counter = 0;
            if (model.Img != null)
            {
                model.ImgUrl = new List<string>();
                foreach (var x in model.Img) 
                {
                    IFormFile img = x;
                    counter++;
                    string extension = Path.GetExtension(img.FileName);
                    string imgName = model.BookName + counter.ToString() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwroot/images/{imgName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    img.CopyTo(stream);
                    model.ImgUrl.Add(imgName);

                }
            }
            BookList.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(BookList.FirstOrDefault(x => x.Isbn == id));

        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            int counter = 0;
            if (model.Img != null)
            {
                model.ImgUrl = new List<string>();
                foreach (var item in model.Img) 
                {
                    IFormFile img = item;
                    counter++;
                    string extension = Path.GetExtension(img.FileName);
                    string imgName = model.BookName + counter.ToString() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwroot/images/{imgName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    img.CopyTo(stream);
                    model.ImgUrl.Add(imgName);
                }
            }
            Book existLog = BookList.FirstOrDefault(x => x.Isbn == model.Isbn);
            if (existLog != null)
            {
                existLog.ImgUrl = model.ImgUrl;
                existLog.BookName = model.BookName;
                existLog.Author = model.Author;
                existLog.Year = model.Year;
                existLog.Genre = model.Genre;
                existLog.Place = model.Place;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            BookList.Remove(BookList.FirstOrDefault(x => x.Isbn == id));
            return Ok();
        }


    }
}
