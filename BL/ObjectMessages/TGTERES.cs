using System;
using System.Xml.Serialization;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    public class TGTERES
    {
        [XmlAttribute]
        public string Type;

        public string SBELN;

        public string DSENUM;

        public string RENUM;

        public string ANDAT;

        public string REDAT;

        public string AVBDT;

        public string CANAL;

        public string DDENUM;

        public string DDEDT;

        public string DDESQ;

        public string REANX;

        public int DSESQ;

        public string DOCFAT;

        public string XBLNR;

        public string INCO1;

        public string WAERS;

        public string DDEADT;

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DDEADT. Se o valor da propriedade DDEADT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DDEADT_DateTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.DDEADT) || string.IsNullOrWhiteSpace(this.DDEADT))
                {
                    return null;
                }
                else { return ConfigureDate.convertDateStringForDateTime(this.DDEADT); }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DDEDT. Se o valor da propriedade DDEDT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DDEDT_DateTime
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.DDEDT) || string.IsNullOrEmpty(this.DDEDT))
                {
                    return null;
                }
                else { return ConfigureDate.convertDateStringForDateTime(this.DDEDT); }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string AVBDT. Se o valor da propriedade AVBDT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? AVBDT_DateTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.AVBDT) || string.IsNullOrWhiteSpace(this.AVBDT))
                {
                    return null;
                }
                else { return ConfigureDate.convertDateStringForDateTime(this.AVBDT); }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string REDAT. Se o valor da propriedade REDAT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? REDAT_DateTime
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.REDAT) || string.IsNullOrEmpty(this.REDAT))
                {
                    return null;
                }
                else { return ConfigureDate.convertDateStringForDateTime(this.REDAT); }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ANDAT. Se o valor da propriedade ANDAT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? ANDAT_DateTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.ANDAT) || string.IsNullOrWhiteSpace(this.ANDAT))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.ANDAT);
                }
            }
        }
    }
}
