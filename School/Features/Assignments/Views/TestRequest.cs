using System.ComponentModel.DataAnnotations;

namespace School.Features.Test.Views;

public class TestRequest
{
    [Required]public string Subject { get; set; }

    [Required]public DateTime TestDate { get; set; }
}