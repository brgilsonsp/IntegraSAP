using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "configuration")]
    public class ObjServiceTrocaXMLConfig
    {
        public ConfigSection configSections { get; set; }
        public Startup startup { get; set; }
        public ConnectionString connectionStrings { get; set; }
        [XmlElement(ElementName = "system.serviceModel")]
        public SystemServiceModel systemServiceModel { get; set; }
        public AppSetting appSettings { get; set; }

    }

    public class ConfigSection
    {

    }

    public class Startup
    {
        public SupportedRuntime supportedRuntime { get; set; }

    }

    public class SupportedRuntime
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }

        [XmlAttribute(AttributeName = "sku")]
        public string sku { get; set; }
    }

    public class ConnectionString
    {
        [XmlElement(ElementName = "add")]
        public AddConnectionString add { get; set; }
    }
    public class AddConnectionString
    {
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }

        [XmlAttribute(AttributeName = "connectionString")]
        public string connectionString { get; set; }

        [XmlAttribute(AttributeName = "providerName")]
        public string providerName { get; set; }
    }

    public class SystemServiceModel
    {
        [XmlElement(ElementName = "bindings")]
        public BindingsServiceModel bindings { get; set; }

        [XmlElement(ElementName = "client")]
        public ClientServiceModel client { get; set; }
    }
    public class BindingsServiceModel
    {
        [XmlElement(ElementName = "basicHttpBinding")]
        public BasicHttpBinding basicHttpBinding { get; set; }
    }
    public class BasicHttpBinding
    {
        [XmlElement(ElementName = "binding")]
        public List<BindingBasicHttp> binding { get; set; }
    }
    public class BindingBasicHttp
    {
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "security", IsNullable = false)]
        public SecurityBinding security { get; set; }
    }
    public class SecurityBinding
    {
        [XmlAttribute(AttributeName = "mode")]
        public string mode { get; set; }
    }
    public class ClientServiceModel
    {
        [XmlElement(ElementName = "endpoint")]
        public EndpontClient endpoint { get; set; }
    }
    public class EndpontClient
    {
        [XmlAttribute(AttributeName = "address")]
        public string address { get; set; }
        [XmlAttribute(AttributeName = "binding")]
        public string binding { get; set; }
        [XmlAttribute(AttributeName = "bindingConfiguration")]
        public string bindingConfiguration { get; set; }
        [XmlAttribute(AttributeName = "contract")]
        public string contract { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
    }


    public class AppSetting
    {
        [XmlElement(ElementName = "add")]
        public List<AddAppSetting> add { get; set; }
    }
    public class AddAppSetting
    {
        [XmlAttribute(AttributeName = "key")]
        public string key { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string value { get; set; }
    }
}
