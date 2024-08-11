using System.ComponentModel.DataAnnotations;

namespace Diary.Models;

public class DiaryEntry
{
    // [Key]
    public int Id {get; set;}
    // ? creates nullable
    [Required]
    public string Title {get; set;} = string.Empty;
    // = string.Empty initialising by default value 
    [Required]
    public string Content {get; set;} = string.Empty;
    [Required]
    public DateTime Created {get; set;} = DateTime.Now;

}
