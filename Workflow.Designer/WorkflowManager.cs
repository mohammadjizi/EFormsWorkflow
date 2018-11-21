using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Configuration;
using System.Threading;

namespace Workflow.Designer
{
    internal class WorkflowManager
    {
        private AutoResetEvent WFEvent { get; set; }

        public WorkflowApplication WFApplication { get; set; }

        public WorkflowManager(Activity wfDefinition, Version vrsn)
        {
            SqlWorkflowInstanceStore wfInstanceStore = InitializeInstanceStore();

            WorkflowIdentity wfIdentity = InitializeIdentity(wfDefinition, vrsn);

            this.WFApplication = InitializeApplication(wfDefinition, wfIdentity, wfInstanceStore);
        }

        private SqlWorkflowInstanceStore InitializeInstanceStore()
        {
            SqlWorkflowInstanceStore wfInstanceStore =
                new SqlWorkflowInstanceStore(ConfigurationManager.AppSettings["DBConnectionString"]);
            wfInstanceStore.InstanceCompletionAction = InstanceCompletionAction.DeleteNothing;
            wfInstanceStore.HostLockRenewalPeriod = TimeSpan.FromMinutes(5);

            return wfInstanceStore;
        }

        private WorkflowIdentity InitializeIdentity(Activity wfDefinition, Version vrsn)
        {
            WorkflowIdentity identity = new WorkflowIdentity();
            identity.Name = wfDefinition.DisplayName;
            identity.Version = vrsn;

            return identity;
        }

        private WorkflowApplication InitializeApplication(Activity definition, WorkflowIdentity identity,
            SqlWorkflowInstanceStore instanceStore)
        {
            this.WFEvent = new AutoResetEvent(false);

            //----------------------------
            //Initialize WF inputs
            //----------------------------
            //Dictionary<string, object> inputList = new Dictionary<string, object>();
            //inputList.Add("argAction", "Initiated");

            //----------------------------
            //Initialize WF host
            //----------------------------
            //WorkflowApplication wfApp = new WorkflowApplication(wfInfo, inputList, wfID);
            WorkflowApplication wfApp = new WorkflowApplication(definition, identity);
            wfApp.InstanceStore = instanceStore;

            wfApp.OnUnhandledException = (param) => { return UnhandledExceptionAction.Terminate; };

            //returning IdleAction.Unload instructs the WorkflowApplication to persists application state and remove it from memory
            wfApp.PersistableIdle = (param) => { return PersistableIdleAction.Unload; };

            wfApp.Completed = (param) => { };

            wfApp.Idle = (param) => { };

            wfApp.Unloaded = (param) =>
            {
                // Workflow lifecycle events omitted except unloaded.
                //i think this removes the block of the main thread and signal it to proceed
                this.WFEvent.Set();

            };

            return wfApp;
        }

        public void Run()
        {
            this.WFApplication.Run();

            // Wait for the workflow to go unloaded before gathering the user's input.
            //i think this is blocking the main thread inorder to wait for the workflow 
            //to get unloaded before proceed since the worfklowapplication
            //executes the workflow in a different thread .
            this.WFEvent.WaitOne();

        }

        private void Load(Guid instandId)
        {
            this.WFApplication.Load(instandId);
        }

        public void Resume(Guid instandId,string bookmarkName, object info)
        {
            this.WFApplication.Load(instandId);

            BookmarkResumptionResult result = this.WFApplication.ResumeBookmark(bookmarkName, info);
        }
    }
}
