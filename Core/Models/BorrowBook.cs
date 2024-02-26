using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryProject.Core.Model;

public class BorrowBook
{
    [JsonIgnore]
    [Required]
    public int Id { get; set; }
    [Required]
    [JsonIgnore]
    public DateTime BorrowDate { get; set; }
    [JsonIgnore]
    [Required]
    public DateTime ReturnBorrowDate { get; set; }

    [Required]
    public bool IsBorrowed { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int BookId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Book? Book { get; set; }
}
