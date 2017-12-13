using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Util.InnerUtil;
using System.ServiceModel;
using System.IO;

namespace BL.Business
{
    public class ConfigureService
    {
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Salva a alteração no arquivo de configuração do serviço
        /// </summary>
        /// <param name="objService">ObjServiceTrocaXMLConfig</param>
        public void SaveConfigService(ObjServiceTrocaXMLConfig objService)
        {
            ObjServiceTrocaXMLConfig objServiceBkp = GetConfigService();
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
        public ObjServiceTrocaXMLConfig GetConfigService()
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
        public int GetDelay()
        {
            try
            {
                var settings = config.AppSettings;
                return Int32.Parse(settings.Settings[Option.DELAY_PROCCESS].Value);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Obtém o caminho que será salvo os arquivos de log
        /// </summary>
        /// <returns>string</returns>
        public string GetPathLog()
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
        /// Obtém a flag Salva XML
        /// </summary>
        /// <returns>bool</returns>
        public bool GetSaveXML()
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
    }
}
