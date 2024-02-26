using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryProject.Core.DTO;

public class BorrowBookDTO
{

    public int Id { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnBorrowDate { get; set; }

    public bool IsBorrowed { get; set; }
    [Required]
    public int UserId { get; set; }

    public int BookId { get; set; }
}

