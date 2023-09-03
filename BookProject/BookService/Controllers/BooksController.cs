using AutoMapper;
using BookService.DbContexts;
using BookService.Services;
using BookService.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private readonly IBookSvc _bookSvc;
        
        public BooksController(ILogger<BooksController> logger, IBookSvc bookSvc)
        {
            _logger = logger;
            _bookSvc = bookSvc;
        }
        [HttpGet]
        public List<Models.BookModel> Get()
        {
            _logger.LogInformation("Start API: Books.Get() ");
            return _bookSvc.GetBooks().ToList();
        }
        [HttpGet]
        [Route("GetBooksTitleSentenceCase")]
        public List<Models.BookModel> GetBooksApplySentenceCase()
        {
            _logger.LogInformation("Start API: Books.GetBooksApplySentenceCase() ");
            var books = _bookSvc.GetBooks().ToList();
            books = new BookTransformer().GetBookNameSentenceCase(books);
            return books;
        }

    }
}
