using System.ComponentModel.DataAnnotations;

namespace School.Features.Subject.ViewsS;

public class SubjectsRequest
{
    [Required]public string Name { get; set; }
    [Required]public string ProfessorMail { get; set; }
    [Required]public List<Double> Grades { get; set; }
}