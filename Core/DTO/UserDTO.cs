using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryProject.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }


    }
}
