using System.ComponentModel.DataAnnotations;

namespace ournms.Entities;

public class BaseEntity
{
    [Key] 
    public required int Id { get; set; }
}