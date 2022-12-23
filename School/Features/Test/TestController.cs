using Microsoft.AspNetCore.Mvc;
using School.Features.Test.ModelsT;
using School.Features.Test.ViewsT;

namespace School.Features.Test;

[ApiController]
[Route("test")]
public class TestController
{
    private static List<TestModel> _mockDb = new List<TestModel>();

    [HttpPost]
    public TestResponse Add(TestRequest request)
    {
        var test = new TestModel()
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            TestDate = request.TestDate
        };

        _mockDb.Add(test);

        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }
    
    [HttpGet]
    public IEnumerable<TestResponse> Get()
    {
        return _mockDb.Select(
            assignment => new TestResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                TestDate = assignment.TestDate
            }).ToList();
    }
    
    [HttpGet("{id}")]
    public TestResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);
        if (assignment is null)
        {
            return null;
        }
        return new TestResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            TestDate = assignment.TestDate
        };
    }
    
    [HttpDelete]
    
    public TestResponse Delete([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);

        if (assignment is null)
        {
            return null;
        }
        
        _mockDb.Remove(assignment);
        
        return new TestResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            TestDate = assignment.TestDate
        };
    }
    
    [HttpPatch("{id}")]
    public TestResponse Update([FromRoute] string id,[FromBody] TestRequest request)
    {
        var assignment = _mockDb.FirstOrDefault(user => user.Id == id);
        if (assignment is null)
        {
            return null;
            
        }

        assignment.Updated = DateTime.UtcNow;
        assignment.Subject = request.Subject;
        assignment.TestDate = request.TestDate

        return new TestResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            TestDate = assignment.TestDate
        };
    }
    
}