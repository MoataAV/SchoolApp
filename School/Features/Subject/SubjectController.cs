using Microsoft.AspNetCore.Mvc;
using School.Features.Subject.ModelsS;
using School.Features.Subject.ViewsS;


namespace School.Features.Subject;

[ApiController]
[Route("Subject")]
public class SubjectController
{
    private static List<SubjectModel> _mockDb = new List<SubjectModel>();

    [HttpPost]
    public SubjectResponse Add(SubjectsRequest request)
    {
        var Subject = new SubjectModel()
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };

        _mockDb.Add(Subject);

        return new SubjectResponse()
        {
            Id = Subject.Id,
            Name = Subject.Name,
            ProfessorMail = Subject.ProfessorMail,
            Grades = Subject.Grades
        };
    }
    
    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDb.Select(
            Subject => new SubjectResponse()
            {
                Id = Subject.Id,
                Name = Subject.Name,
                ProfessorMail = Subject.ProfessorMail,
                Grades = Subject.Grades
            }).ToList();
    }
    
    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var Subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (Subject is null)
        {
            return null;
        }
        return new SubjectResponse()
        {
            Id = Subject.Id,
            Name = Subject.Name,
            ProfessorMail = Subject.ProfessorMail,
            Grades = Subject.Grades
        };
    }
    
    [HttpDelete]
    
    public SubjectResponse Delete([FromRoute] string id)
    {
        var Subject = _mockDb.FirstOrDefault(x => x.Id == id);

        if (Subject is null)
        {
            return null;
        }
        
        _mockDb.Remove(Subject);
        
        return new SubjectResponse()
        {
            Id = Subject.Id, 
            Name = Subject.Name,
            ProfessorMail = Subject.ProfessorMail,
            Grades = Subject.Grades
        };
    }
    
    [HttpPatch("{id}")]
    public SubjectResponse Update([FromRoute] string id,[FromBody] SubjectsRequest request)
    {
        var Subject = _mockDb.FirstOrDefault(user => user.Id == id);
        if (Subject is null)
        {
            return null;
            
        }

        Subject.Updated = DateTime.UtcNow;
        Subject.Name = Subject.Name;
        Subject.ProfessorMail = Subject.ProfessorMail;
        Subject.Grades = Subject.Grades;

        return new SubjectResponse()
        {
            Id = Subject.Id,
            Name = Subject.Name,
            ProfessorMail = Subject.ProfessorMail,
            Grades = Subject.Grades
        };
    }
    
}