using Microsoft.AspNetCore.Mvc;
using School.Features.Assignments.Models;
using School.Features.Assignments.Views;

namespace School.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>(); //Nu avem baza de date, deci folosim o list pe post de DB de asta avem mockDb

    public AssignmentsController() { }

    [HttpPost] //Tag-ul adauga informatii in baza de date
    public AssignmentsResponse Add(AssignmentsRequest request)
    {
        var assignment = new AssignmentModel
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };
        
        _mockDb.Add(assignment);

        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentsResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentsResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            }).ToList();
    }

    [HttpGet("{id}")]
    public AssignmentsResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);
        if (assignment is null)
        {
            return null;
        }
        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpDelete]
    
    public AssignmentsResponse Delete([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);

        if (assignment is null)
        {
            return null;
        }
        
        _mockDb.Remove(assignment);
        
        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpPatch("{id}")]
    public AssignmentsResponse Update([FromRoute] string id,[FromBody] AssignmentsRequest request)
    {
        var assignment = _mockDb.FirstOrDefault(user => user.Id == id);
        if (assignment is null)
        {
            return null;
            
        }

        assignment.Updated = DateTime.UtcNow;
        assignment.Subject = request.Subject;
        assignment.Description = request.Description;
        assignment.Deadline = request.Deadline;

        return new AssignmentsResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }
}