﻿using Microsoft.AspNetCore.Mvc;
using School.Features.Test.Models;
using School.Features.Test.Views;

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
}