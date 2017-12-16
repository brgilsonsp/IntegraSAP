using DAL.ObjectMessages;
using System;
using System.Configuration;
using Util.InnerUtil;
using System.IO;

namespace BL.Business
{
    /// <summary>
    /// Manipula o arquivo de configuração do serviço
    /// </summary>
    public class ConfigureService
    {
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Retorna o Caminho raiz definido pelo usuário aonde o arquivo de Log será salvo
        /// </summary>
        public string RootLog { get { return RootForSaveLog(); } }

        /// <summary>
        /// Verifica se o usuário permitiu a gravação do arquivo XML
        /// </summary>
        public bool IsSaveXml { get { return GetSaveXML(); } }

        /// <summary>
        /// Obtém o delay que esta configurado no arquvio de configuração do serviço
        /// </summary>
        public int GetDelay { get { return GetDelayConfigured(); } }

        /// <summary>
        /// Obtem uma instância com os valores da configuração do serviço
        /// </summary>
        public ObjServiceTrocaXMLConfig GetConfigService { get { return GetConfigServiceConfigured(); } }

        #region Métodos que executam leitura no arquivo de configuração app.xml

        /// <summary>
        /// Salva a alteração no arquivo de configuração do serviço
        /// </summary>
        /// <param name="objService">ObjServiceTrocaXMLConfig</param>
        public void SaveConfigService(ObjServiceTrocaXMLConfig objService)
        {
            ObjServiceTrocaXMLConfig objServiceBkp = GetConfigService;
            objServiceBkp.connectionStrings.add.connectionString = objService.connectionStrings.add.connectionString;
            objServiceBkp.systemServiceModel.client.endpoint.address = objService.systemServiceModel.client.endpoint.address;
            objServiceBkp.appSettings.add = objService.appSettings.add;

            XmlForGTE<ObjServiceTrocaXMLConfig> serializa = new XmlForGTE<ObjServiceTrocaXMLConfig>();
            string objSerializado = serializa.serializeXmlForGTE(objServiceBkp);

            using (StreamWriter writer = new StreamWriter("ServiceTrocaXML.exe.config", false))
            {
                writer.WriteLine(objSerializado);

            }
        }

        /// <summary>
        /// Obtem os valores da configuração do serviço e retorna em um objeto
        /// </summary>
        /// <returns>ObjServiceTrocaXMLConfig</returns>
        private ObjServiceTrocaXMLConfig GetConfigServiceConfigured()
        {
            string xmlConfig = File.ReadAllText("ServiceTrocaXML.exe.config");
            ObjectForDB<ObjServiceTrocaXMLConfig> objConfig = new ObjectForDB<ObjServiceTrocaXMLConfig>();
            return objConfig.deserializeXmlForDB(xmlConfig);
        }

        /// <summary>
        /// Obtém o delay que esta configurado no arquvio de configuração
        /// do serviço
        /// </summary>
        /// <returns>int</returns>
        private int GetDelayConfigured()
        {
            try
            {
                var settings = config.AppSettings;
                return Int32.Parse(settings.Settings[Option.DELAY_PROCCESS].Value);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Obtém diretório raiz configurado pelo usuário aonde será salvo os arquivos de log e os arquivos XML
        /// </summary>
        /// <returns>string</returns>
        private string RootForSaveLog()
        {
            try
            {
                var settings = config.AppSettings;
                return settings.Settings[Option.PATH_LOG].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Verifica no App.config se o usuário habilitou a gravação dos arquivos XML Original
        /// </summary>
        /// <returns>bool</returns>
        private bool GetSaveXML()
        {
            try
            {
                bool resultado = false;
                var settings = config.AppSettings;
                string retorno = settings.Settings[Option.SAVE_XML].Value;
                int valor = -1;
                Int32.TryParse(retorno, out valor);
                if(valor != -1)
                {
                    resultado = (valor == 1 ? true : false);
                }
                return resultado;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
