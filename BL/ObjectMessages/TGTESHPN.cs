using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    public class TGTESHPN
    {
        [XmlAttribute]
        public string Type;
        
        public string SBELN;

        public int SBELP;

        public int NBELP;

        public string DOCFAT;

        public decimal ITMFAT;

        public string MATNR;

        public string MAKTX;

        [XmlElement("MAKTX_TEXT")]
        public List<MAKTXTEXT> MAKTX_TEXT;

        public decimal QTDITM;

        public decimal NETPR;

        public decimal KPEIN;

        public string MEINS;

        public decimal NETWR;

        public decimal FRTLOC;

        public decimal FRTINT;

        public decimal SEGINT;

        public decimal PRCFOB;

        public decimal PRCEXW;

        public decimal PCTCOM;

        public decimal VLRCOM;

        public string RENUM;

        public int ITMRE;

        public string ENQDM;

        public decimal BRGEW;

        public decimal NTGEW;

        public string GEWEI;

        public decimal VOLUM;

        public string VOLEH;

        public string STEUC;

        public string NALADISH;

        public string FABITM;

        public string ATOCON;

        public string AMCCPTC;

        public string BRCCPTC;

        public string CCROM;

        public string FABRILUF;

        public decimal NETPRORI;

        public decimal KPEINORI;

        public string MEINSORI;

        public decimal NETWRORI;

        public string PROD;

        public string FKDAT;

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string FKDAT. Se o valor da propriedade FKDAT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? FKDAT_DateTime
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.FKDAT) || string.IsNullOrEmpty(this.FKDAT))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.FKDAT);
                }
            }
        }
    }

    public class MAKTXTEXT
    {
        [XmlAttribute]
        public string Type;

        public string TEXT;
    }
}
