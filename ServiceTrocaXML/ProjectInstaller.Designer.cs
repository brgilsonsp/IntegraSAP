namespace ServiceTrocaXML
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceChangeXML = new System.ServiceProcess.ServiceProcessInstaller();
            this.TrocaXML = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceChangeXML
            // 
            this.serviceChangeXML.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceChangeXML.Password = null;
            this.serviceChangeXML.Username = null;
            // 
            // TrocaXML
            // 
            this.TrocaXML.Description = "Efetua troca de XML com Web Service GTE";
            this.TrocaXML.DisplayName = "TrocaXML";
            this.TrocaXML.ServiceName = "TrocaXML";
            this.TrocaXML.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceChangeXML,
            this.TrocaXML});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceChangeXML;
        private System.ServiceProcess.ServiceInstaller TrocaXML;
    }
}