using System;
using System.ServiceProcess;
using System.Threading;
using BL;
using BL.Infra;

namespace ServiceTrocaXML
{
    public partial class ServiceChangeXml : ServiceBase
    {
        public ServiceChangeXml()
        {
            InitializeComponent();
        }

        private Thread threadApplication;

        protected override void OnStart(string[] args)
        {            
            if (threadApplication == null)
            {
                threadApplication = new Thread(new ThreadStart(InvokeProgramm));
                threadApplication.Start();
            }
        }

        protected override void OnStop()
        {
            if (threadApplication != null)
            {
                threadApplication.Abort();
            }
        }

        private void InvokeProgramm()
        {
            try
            {
                RunMessenger runMessenger = new RunMessenger();
                while (true)
                {                    
                    runMessenger.StartChangeXML();
                    int minute = new ConfigureService().GetDelay;
                    Thread.Sleep(TimeSpan.FromMinutes(minute));
                }
            }
            catch (Exception) { }
        }
    }
}
