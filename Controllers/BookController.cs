using AutoMapper;
using LibraryProject.Core.DTO;
using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.AspNetCore.Mvc;


namespace LibraryProject.Controllers;

[Route("v1/api/book")]
[ApiController]


public class BookController : ControllerBase
{
    private readonly IBookRepository _context;
    private readonly IMapper _mapper;

    public BookController(IBookRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IEnumerable<BookDTO>> Get()
    {
        var books = await _context.Get();
        var booksDTO = _mapper.Map <IEnumerable<BookDTO>>(books);
        return booksDTO;



    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> Get(int id)
    {
        var book = await _context.Get(id);
        if (book != null)
        {
            var bookDTO = _mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }
        return NotFound("Book not found");
    }


    [HttpPost]
    public async Task<ActionResult<BookDTO>> Post(Book book)
    {
        var bookCreate = await _context.Create(book);

        if (bookCreate != null)
        {
            var bookDTO = _mapper.Map<BookDTO>(bookCreate);
            return Ok(bookDTO);
        }
        return BadRequest("Check the book information in payload");
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var book = await _context.Delete(id);
        
        if(book)
            return Ok("Removed book");

        return NotFound("Book borrowed or id invalid");
    }

}
