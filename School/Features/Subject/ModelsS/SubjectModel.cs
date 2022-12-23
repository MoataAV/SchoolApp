using School.Base;

namespace School.Features.Subject.ModelsS;

public class SubjectModel : Model
{
    public string Name { get; set; }
    public string ProfessorMail { get; set; }
    public List<Double> Grades { get; set; }
}
