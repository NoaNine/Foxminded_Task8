using System.ComponentModel.DataAnnotations;

namespace University.DAL.Models;

public abstract class BaseModel
{
    [Key]
    public int Id { get; set; }
}
