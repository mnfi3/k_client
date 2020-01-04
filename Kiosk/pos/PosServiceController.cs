using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.pos
{
    class PosServiceController
    {


        public enum PosServiceCustomCommands
        { StopWorker = 128, RestartWorker, CheckWorker };

        private string application_name;
        private string service_name;

        public PosServiceController()
        {
            application_name = PosConf.APPLICATION_NAME;
            service_name = PosConf.SERVICE_NAME;
        }


        public async Task restart()
        {

            //ServiceController[] scServices;
            //scServices = ServiceController.GetServices();


            await Task.Run(() =>
            {

                using (ServiceController service = new ServiceController(service_name))
                {
                    try
                    {
                        if (
                            (service.Status.Equals(ServiceControllerStatus.Running)) ||
                            (service.Status.Equals(ServiceControllerStatus.StartPending)) ||
                            (service.Status.Equals(ServiceControllerStatus.Paused)) ||
                            (service.Status.Equals(ServiceControllerStatus.PausePending))
                            )
                        {
                            service.Stop();
                        }

                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception($"Can not restart the Windows Service {serviceName}", ex);
                    }
                    //catch (InvalidOperationException ex2)
                    //{

                    //}

                }
            });

            return;






            //foreach (ServiceController scTemp in scServices)
            //{
            //    if (scTemp.ServiceName == service_name)
            //    {


            //        ServiceController serviceController = new ServiceController(service_name);
            //        try
            //        {
            //            //if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
            //            //{
            //                serviceController.Stop();
            //            //}
            //            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            //            serviceController.Start();
            //            serviceController.WaitForStatus(ServiceControllerStatus.Running);
            //        }
            //        catch
            //        {
            //            //ShowMsg(AppTexts.Information, AppTexts.SystematicError, MessageBox.Icon.WARNING);
            //        }

            //        return;





            //        ////info
            //        //Console.WriteLine("MachineName = " + scTemp.MachineName);
            //        //Console.WriteLine("DisplayName = " + scTemp.DisplayName);
            //        //Console.WriteLine("machine name = " + scTemp.ServiceName);
            //        //// Display properties for the Simple Service sample
            //        //// from the ServiceBase example.
            //        //ServiceController sc = new ServiceController(service_name);
                    
            //        //Console.WriteLine("Status = " + sc.Status);
            //        //Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
            //        //Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
            //        //Console.WriteLine("Can Stop = " + sc.CanStop);
            //        //if (sc.Status == ServiceControllerStatus.Stopped)
            //        //{
            //        //    try
            //        //    {
            //        //        sc.Start();
            //        //        while (sc.Status == ServiceControllerStatus.Stopped)
            //        //        {
            //        //            Thread.Sleep(1000);
            //        //            sc.Refresh();
            //        //        }
            //        //    }
            //        //    catch { }
            //        //}


            //        //if (sc.Status == ServiceControllerStatus.Paused)
            //        //{
            //        //    try
            //        //    {
            //        //        sc.Start();
            //        //        while (sc.Status == ServiceControllerStatus.Stopped)
            //        //        {
            //        //            Thread.Sleep(1000);
            //        //            sc.Refresh();
            //        //        }
            //        //    }
            //        //    catch { }
            //        //}














            //        // Issue custom commands to the service
            //        // enum SimpleServiceCustomCommands 
            //        //    { StopWorker = 128, RestartWorker, CheckWorker };
            //        //sc.ExecuteCommand((int)PosServiceCustomCommands.StopWorker);
            //        //sc.ExecuteCommand((int)PosServiceCustomCommands.RestartWorker);
            //        //sc.Pause();
            //        //while (sc.Status != ServiceControllerStatus.Paused)
            //        //{
            //        //    Thread.Sleep(1000);
            //        //    sc.Refresh();
            //        //}
            //        //Console.WriteLine("Status = " + sc.Status);
            //        //sc.Continue();
            //        //while (sc.Status == ServiceControllerStatus.Paused)
            //        //{
            //        //    Thread.Sleep(1000);
            //        //    sc.Refresh();
            //        //}
            //        //Console.WriteLine("Status = " + sc.Status);
            //        //sc.Stop();
            //        //while (sc.Status != ServiceControllerStatus.Stopped)
            //        //{
            //        //    Thread.Sleep(1000);
            //        //    sc.Refresh();
            //        //}
            //        //Console.WriteLine("Status = " + sc.Status);
            //        //String[] argArray = new string[] { "ServiceController arg1", "ServiceController arg2" };
            //        //sc.Start(argArray);
            //        //while (sc.Status == ServiceControllerStatus.Stopped)
            //        //{
            //        //    Thread.Sleep(1000);
            //        //    sc.Refresh();
            //        //}
            //        //Console.WriteLine("Status = " + sc.Status);
            //        //// Display the event log entries for the custom commands
            //        //// and the start arguments.
            //        //EventLog el = new EventLog(application_name);
            //        //EventLogEntryCollection elec = el.Entries;
            //        //foreach (EventLogEntry ele in elec)
            //        //{
            //        //    if (ele.Source.IndexOf(service_name + ".OnCustomCommand") >= 0 |
            //        //        ele.Source.IndexOf(service_name + ".Arguments") >= 0)
            //        //        Console.WriteLine(ele.Message);
            //        //}
            //    }
            //}




        }
       
        
    }
}
