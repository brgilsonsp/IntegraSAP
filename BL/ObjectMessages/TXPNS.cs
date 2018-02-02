using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    /// <summary>
    /// Essa classe possui propriedades redundantes. 
    /// Quando a propriedade possui a anotação NotMapped, ela será utilizada apenas para o XML, sendo assim ela mantem
    /// o nome que foi definida na documentação (fornecida pela E-IT), porém quando a propriedade
    /// utiliza as anotações XmlIgnore e Column("NomeColuna") ela é utilizada apenas pelo banco de dados e foi inserido
    /// um sufixo DB. Foi criado também uma variável privada afim de tratar o retorno para o XML,
    /// pois a E-IT necessita de todos campos no arquivo XML, mesmo null, sendo assim, se o valor no banco de dados for null
    /// ele retornará uma string vazia, afim de gerar a tag no XML
    /// </summary>
    public class TXPNS
    {

        #region only db
        [XmlIgnore]
        public int ID { get; set; }

        [Column("IDTPCK")][XmlIgnore]
        public int TPCKID { get; set; }

        [XmlIgnore]
        public virtual TPCK TPCK { get; set; }

        [XmlIgnore]
        [Column("NETWR")]
        public decimal? NETWRDB { get { return this._netwr; } set { this._netwr = value; } }

        #endregion

        #region private
        
        private decimal? _netwr;
        private string _kschl;
        private string _unrealized;

        #endregion

        [XmlAttribute]
        [Column("TypeTXPNS")]
        public string Type { get; set; }

        public string KSCHL { get { return ConverterValue.StringNullToEmpty(this._kschl); } set { this._kschl = value; } }

        [NotMapped]
        public string NETWR { get { return ConverterValue.DecimalNullableToString(this._netwr); } set { this._netwr = ConverterValue.StringToDecimalNullable(value); } }

        public string UNREALIZED { get { return ConverterValue.StringNullToEmpty(_unrealized); } set { _unrealized = value; } }


    }
}
