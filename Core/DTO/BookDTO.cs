using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryProject.Core.DTO;

public class BookDTO
{

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? ISBN { get; set; }

    public int YearPublication { get; set; }

}
