using BL.Business;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.InnerUtil;
using BL.Infra;

namespace ApenasTeste
{
    public partial class Configuration : Form
    {
        private string startDataSource = "Server=";
        private string endDataSource = ";Database=";
        private string startUser = ";User Id=";
        private string startPwd = ";Password=";

        public Configuration()
        {
            InitializeComponent();
            ShowValues();
        }

        private void ShowValues()
        {
            try
            {
                ObjServiceTrocaXMLConfig objSalvo = new ConfigureService().GetConfigService;
                txtDelayProcess.Text = GetAppSetting(objSalvo.appSettings, Option.DELAY_PROCCESS);
                txtPathDB.Text = RemovePontoVirgula(GetPathDB(objSalvo.connectionStrings.add));
                txtPwdDB.Text = RemovePontoVirgula(GetPwd(objSalvo.connectionStrings.add));
                txtUserDB.Text = RemovePontoVirgula(GetUser(objSalvo.connectionStrings.add));
                txtPathLog.Text = RemovePontoVirgula(GetAppSetting(objSalvo.appSettings, Option.PATH_LOG));
                txtPathWebService.Text = RemovePontoVirgula(objSalvo.systemServiceModel.client.endpoint.address);
                cbSaveXML.Checked = GetSaveXML(objSalvo.appSettings, Option.SAVE_XML);
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}{1}{2}{1}", MessagesOfReturn.ErrorOpenFileConfig, Environment.NewLine,
                    ex.Message);
                MessageBox.Show(this, msg, MessagesOfReturn.ErrorInfo, MessageBoxButtons.OK, MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                this.Dispose();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    new ConfigureService().SaveConfigService(GetObj());
                    MessageBox.Show(this, MessagesOfReturn.SuccessUpdateConfig, MessagesOfReturn.Information, MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}{1}{2}{1}", MessagesOfReturn.NotSaveUpdateTitle, Environment.NewLine,
                    MessagesOfReturn.NotSaveUpdateConfig);
                MessageBox.Show(this, msg + ex.Message, MessagesOfReturn.Information, MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                throw new Exception();
            }
        }

        private bool IsValid()
        {
            string msg = "";
            if (IsNullOrEmpty(txtPathDB.Text.Trim())) { msg += string.Format("{0} {1}", "Caminho banco de dados",Environment.NewLine); }

            if (!IsLoginDataBaseCurrentUser())
            {
                if (IsNullOrEmpty(txtUserDB.Text.Trim())) { msg += string.Format("{0} {1}", "Usuário banco de dados", Environment.NewLine); }
                if (IsNullOrEmpty(txtPwdDB.Text.Trim())) { msg += string.Format("{0} {1}", "Senha banco de dados", Environment.NewLine); }
            }

            if (IsNullOrEmpty(txtPathWebService.Text.Trim())) { msg += string.Format("{0} {1}", "Caminho Web Service", Environment.NewLine); }
            if (IsNullOrEmpty(txtDelayProcess.Text.Trim())) { msg += string.Format("{0} {1}", "Delay processo", Environment.NewLine); }
            if (IsNullOrEmpty(txtPathLog.Text.Trim())) { msg += string.Format("{0} {1}", "Caminho Log", Environment.NewLine); }
            
            if ("".Equals(msg))
                return true;
            else
            {
                string msgError = string.Format("{0} {1}", MessagesOfReturn.FieldEmpty, Environment.NewLine);
                msgError += string.Format("{0} {1}", msg, Environment.NewLine);
                MessageBox.Show(this, msgError, "Campos incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1);
                return false;
            }

        }

        private bool IsLoginDataBaseCurrentUser()
        {
            return (string.IsNullOrEmpty(txtUserDB.Text.Trim()) && string.IsNullOrEmpty(txtPwdDB.Text.Trim()));
        }

        private bool IsConnectionStringTrusted(string connectionString)
        {
            return connectionString.Contains("Trusted_Connection=True");
        }

        private bool IsNullOrEmpty(string word)
        {
            if(string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
            {
                return true;
            }else
            {
                return false;
            }
        }

        private string RemovePontoVirgula(string word)
        {
            int intWord = word.IndexOf(";");
            if (intWord > 0)
            {
                return word.Remove(intWord);
            }
            else { return word; }
        }

        private string GetAppSetting(AppSetting appSett, string key)
        {
            string valueReturn = "";
            foreach (AddAppSetting cadaAppSett in appSett.add)
            {
                if (key.Equals(cadaAppSett.key))
                {
                    valueReturn = cadaAppSett.value;
                }
            }
            return valueReturn;
        }

        private bool GetSaveXML(AppSetting appSett, string key)
        {
            bool valueReturn = false;
            foreach(AddAppSetting cadaAppSet in appSett.add)
            {
                if (key.Equals(cadaAppSet.key))
                {
                    valueReturn = (cadaAppSet.value.Equals("1") ? true : false);
                }
            }
            return valueReturn;
        }

        private string GetPathDB(AddConnectionString addConnecString)
        {
            string connectionString = addConnecString.connectionString;
            int start = connectionString.IndexOf(startDataSource);
            int meta = connectionString.IndexOf(endDataSource);
            int final = (meta - (start + startDataSource.Length));
            start = start + startDataSource.Length;
            return connectionString.Substring(start, final);
        }

        private string GetPwd(AddConnectionString addConnecString)
        {
            string connectionString = addConnecString.connectionString;
            if (IsConnectionStringTrusted(connectionString))
                return "";

            int start = connectionString.IndexOf(startPwd);
            int meta = connectionString.Length - 1;
            int final = (meta - (start + startPwd.Length));
            start = start + startPwd.Length;
            return connectionString.Substring(start, final);
        }

        private string GetUser(AddConnectionString addConnecString)
        {
            string connectionString = addConnecString.connectionString;
            if (IsConnectionStringTrusted(connectionString))
                return "";

            int start = connectionString.IndexOf(startUser);
            int meta = connectionString.IndexOf(startPwd);
            int final = (meta - (start + startUser.Length));
            start = start + startUser.Length;
            return connectionString.Substring(start, final);
        }

        private ObjServiceTrocaXMLConfig GetObj()
        {
            ConnectionString conString = new ConnectionString();
            AddConnectionString addConnectionString = new AddConnectionString();
            addConnectionString.connectionString = GetStringConnection();
            conString.add = addConnectionString;

            SystemServiceModel systemServiceModel = new SystemServiceModel();
            ClientServiceModel client = new ClientServiceModel();
            EndpontClient endpointClient = new EndpontClient();
            endpointClient.address = txtPathWebService.Text;
            client.endpoint = endpointClient;
            systemServiceModel.client = client;

            AppSetting appSettings = new AppSetting();
            AddAppSetting saveXML = new AddAppSetting();
            AddAppSetting log = new AddAppSetting();
            AddAppSetting delay = new AddAppSetting();
            saveXML.key = Option.SAVE_XML;
            saveXML.value = (cbSaveXML.Checked ? "1" : "0");
            log.key = Option.PATH_LOG;
            log.value = txtPathLog.Text;
            delay.key = Option.DELAY_PROCCESS;
            delay.value = txtDelayProcess.Text;
            List<AddAppSetting> listaApp = new List<AddAppSetting>();
            listaApp.Add(saveXML);
            listaApp.Add(log);
            listaApp.Add(delay);
            appSettings.add = listaApp;

            ObjServiceTrocaXMLConfig objSalve = new ObjServiceTrocaXMLConfig();
            objSalve.connectionStrings = conString;
            objSalve.systemServiceModel = systemServiceModel;
            objSalve.appSettings = appSettings;

            return objSalve;
        }

        private string GetStringConnection()
        {
            if (IsLoginDataBaseCurrentUser())
                return $"Server={txtPathDB.Text};Database=BrokerMessage;Trusted_Connection=True;";
            else
                return $"Server={txtPathDB.Text};Database=BrokerMessage;User Id={txtUserDB.Text};Password={txtPwdDB.Text};";
        }
    }
}
