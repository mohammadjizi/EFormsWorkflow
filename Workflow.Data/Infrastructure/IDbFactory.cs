using Microsoft.Extensions.Configuration;
using System;

namespace Workflow.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        WorkflowEntities Init(IConfiguration configuration);
    }
}
