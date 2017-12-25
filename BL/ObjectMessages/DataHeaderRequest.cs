using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ObjectMessages
{
    public class DataHeaderRequest
    {
        private Cabecalho _cabecalho;
        private DadosBroker _dadosBroker;
        public DataHeaderRequest(Cabecalho cabecalho, DadosBroker dadosBroker)
        {
            this._cabecalho = cabecalho;
            this._dadosBroker = dadosBroker;
        }
        public Cabecalho Cabecalho { get { return this._cabecalho; } }
        public DadosBroker DadosBroker { get { return this._dadosBroker; } }
    }
}
