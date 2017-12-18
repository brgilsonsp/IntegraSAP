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

namespace ApenasTeste
{
    public partial class Configuration : Form
    {
        private string startDataSource = "data source=";
        private string endDataSource = "initial catalog=";
        private string startUser = "user id=";
        private string startPwd = ";password=";
        private string endPwd = ";MultipleActiveResultSets=";
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
                string msg = string.Format("{0}{1}{2}{1}", MessagesOfReturn.ERROR_OPEN_FILE_CONFIG, Environment.NewLine,
                    ex.Message);
                MessageBox.Show(msg, MessagesOfReturn.ERROR_INFO, MessageBoxButtons.OK, MessageBoxIcon.Error, 
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
                    MessageBox.Show(MessagesOfReturn.SUCCESS_UPDATE_CONFIG, MessagesOfReturn.INFORMATION, MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}{1}{2}{1}", MessagesOfReturn.ERROR_SAVE_CONFIG, Environment.NewLine,
                    MessagesOfReturn.ERROR_SAVE_CONFIG_COMPL);
                MessageBox.Show(msg + ex.Message, MessagesOfReturn.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                throw new Exception();
            }
        }

        private bool IsValid()
        {
            string msg = "";
            if (IsNullOrEmpty(txtPathDB.Text)) { msg += string.Format("{0} {1}", "Caminho banco de dados",Environment.NewLine); }
            if(IsNullOrEmpty(txtUserDB.Text)) { msg += string.Format("{0} {1}", "Usuário banco de dados", Environment.NewLine); }
            if (IsNullOrEmpty(txtPwdDB.Text)) { msg += string.Format("{0} {1}", "Senha banco de dados", Environment.NewLine); }
            if (IsNullOrEmpty(txtPathWebService.Text)) { msg += string.Format("{0} {1}", "Caminho Web Service", Environment.NewLine); }
            if (IsNullOrEmpty(txtDelayProcess.Text)) { msg += string.Format("{0} {1}", "Delay processo", Environment.NewLine); }
            if (IsNullOrEmpty(txtPathLog.Text)) { msg += string.Format("{0} {1}", "Caminho Log", Environment.NewLine); }
            
            if ("".Equals(msg))
            {
                return true;
            }else
            {
                string msgError = string.Format("{0} {1}", MessagesOfReturn.ERROR_FIELD, Environment.NewLine);
                msgError += string.Format("{0} {1}", msg, Environment.NewLine);
                MessageBox.Show(msgError, "Campos incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }

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
            string conString = addConnecString.connectionString;
            int start = conString.IndexOf(startDataSource);
            int meta = conString.IndexOf(endDataSource);
            int final = (meta - (start + startDataSource.Length));
            start = start + startDataSource.Length;
            return conString.Substring(start, final);
        }

        private string GetPwd(AddConnectionString addConnecString)
        {
            string conString = addConnecString.connectionString;
            int start = conString.IndexOf(startPwd);
            int meta = conString.IndexOf(endPwd);
            int final = (meta - (start + startPwd.Length));
            start = start + startPwd.Length;
            return conString.Substring(start, final);
        }

        private string GetUser(AddConnectionString addConnecString)
        {
            string conString = addConnecString.connectionString;
            int start = conString.IndexOf(startUser);
            int meta = conString.IndexOf(startPwd);
            int final = (meta - (start + startUser.Length));
            start = start + startUser.Length;
            return conString.Substring(start, final);
        }

        private ObjServiceTrocaXMLConfig GetObj()
        {
            ConnectionString conString = new ConnectionString();
            AddConnectionString addConnectionString = new AddConnectionString();
            addConnectionString.connectionString =
                "metadata=res://*/DataBase.csdl|res://*/DataBase.ssdl|res://*/DataBase.msl;provider=System.Data.SqlClient;" +
                "provider connection string=\";data source=" + txtPathDB.Text + ";initial catalog=BrokerMessage;" +
                "user id=" + txtUserDB.Text + ";password=" + txtPwdDB.Text + ";MultipleActiveResultSets=True;" +
                "App=EntityFramework\";";
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
    }
}
