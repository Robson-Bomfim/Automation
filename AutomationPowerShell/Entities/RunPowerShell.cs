using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPowerShell.Entities
{
    class RunPowerShell
    {
        public string Command { private get; set; }
        private Collection<PSObject> Results;

        public RunPowerShell()
        {
        }

        public RunPowerShell(string command)
        {
            Command = command;
        }

        public void ExecutePowerShell()
        {
            RunspaceConfiguration config = RunspaceConfiguration.Create();
            // create Powershell runspace
            using (Runspace runspace = RunspaceFactory.CreateRunspace(config))
            {
                //open it 
                runspace.Open();

                // create a pipeline and feed it the script text
                Pipeline pipeline = runspace.CreatePipeline(Command);
                //pipeline.Commands.AddScript(Command);
                //"Start-Process powershell -Verb runAs"
                //execute the script
                Results = pipeline.Invoke();
            }
        }

        public override string ToString()
        {
            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in Results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
