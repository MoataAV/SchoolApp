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
            test => new TestResponse
            {
                Id = test.Id,
                Subject = test.Subject,
                TestDate = test.TestDate
            }).ToList();
    }
    
    [HttpGet("{id}")]
    public TestResponse Get([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return null;
        }
        return new TestResponse
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }
    
    [HttpDelete]
    
    public TestResponse Delete([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);

        if (test is null)
        {
            return null;
        }
        
        _mockDb.Remove(test);
        
        return new TestResponse
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }
    
    [HttpPatch("{id}")]
    public TestResponse Update([FromRoute] string id,[FromBody] TestRequest request)
    {
        var test = _mockDb.FirstOrDefault(user => user.Id == id);
        if (test is null)
        {
            return null;
            
        }

        test.Updated = DateTime.UtcNow;
        test.Subject = request.Subject;
        test.TestDate = request.TestDate;

        return new TestResponse
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }
    
}