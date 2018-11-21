using System;

namespace Workflow.Designer
{
    public class WorkflowGenerator
    {
        public void CreateAccountMaintenance(Version vrsn)
        {
            WorkflowManager wfManager = new WorkflowManager(new AccountMaintenance(), vrsn);
            wfManager.Run();

        }
    }
}
