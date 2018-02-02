using BL.InnerUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class KURDIS
    {
        #region only DB
        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDDI")]
        public int DIID { get; set; }

        [XmlIgnore]
        public virtual DI DI { get; set; }

        #endregion

        #region private

        private string _type;
        private string _waers;
        private string _kurdi;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string WAERS { get { return ConverterValue.StringNullToEmpty(this._waers); } set { this._waers = value; } }

        public string KURDI { get { return ConverterValue.StringNullToEmpty(this._kurdi); } set { this._kurdi = value; } }
        
    }
}
