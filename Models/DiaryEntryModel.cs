using System.ComponentModel.DataAnnotations;

namespace Diary.Models;

public class DiaryEntry
{
    // [Key]
    public int Id {get; set;}
    // ? creates nullable
    [Required(ErrorMessage ="Please enter a title!")]
    [StringLength(100, MinimumLength =3, 
        ErrorMessage ="Title must be between 3 and 100 characters!")]
    public string Title {get; set;} = string.Empty;
    // = string.Empty initialising by default value 
    [Required(ErrorMessage ="Please enter content")]
    public string Content {get; set;} = string.Empty;
    [Required(ErrorMessage = "Please enter date")]
    public DateTime Created {get; set;} = DateTime.Now;
}
