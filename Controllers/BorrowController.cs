using AutoMapper;
using LibraryProject.Core.DTO;
using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.AspNetCore.Mvc;


namespace LibraryProject.Controllers;

[Route("v1/api/borrows")]
[ApiController]

public class BorrowController : ControllerBase
{
    private readonly IBorrowBookRepository _context;
    private readonly IMapper _mapper;

    public BorrowController(IBorrowBookRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BorrowBookDTO>> Get()
    {
        var borrowBooks = await _context.Get();
        var borrowDTO = _mapper.Map<IEnumerable<BorrowBookDTO>>(borrowBooks);

        return borrowDTO;
    }

    [HttpPost]
    public async Task<ActionResult<BorrowBookDTO>> Post(BorrowBook borrow){

                
        var borrowBook = await _context.Create(borrow);
        if (borrowBook) { 
            var borrowDTO = _mapper.Map<BorrowBookDTO>(borrow);
            return Ok(borrowDTO);
        }

        return BadRequest("It's not possible borrow book now");   
    }

    [HttpPut]
    [Route("/returnbook")]
    public async Task<ActionResult> Update(int id)
    {
        var returnBook = await _context.ReturnBorrow(id);
        if (returnBook)
        {
            return Ok("Book Returned");
        }
        return Ok("Book is not borrowed");
    }   

    

}
