using AccountLedger.Core.ProjectAggregate;
using System.Collections.Generic;

namespace AccountLedger.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
