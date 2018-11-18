using System;

namespace WorkflowDesigner
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
