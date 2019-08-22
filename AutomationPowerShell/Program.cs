using AutomationPowerShell.Entities;
using System;

namespace AutomationPowerShell
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string scriptText = "Stop-WebAppPool -Name \"Portal_BackEnd2\"";
                RunPowerShell ps = new RunPowerShell(scriptText);
                ps.ExecutePowerShell();
                Console.WriteLine(ps.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
