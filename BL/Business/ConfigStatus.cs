using BL.DAO;
using BL.ObjectMessages;
using BL.InnerUtil;
using System.Collections.Generic;
using System;

namespace BL.Business
{
    public abstract class ConfigStatus
    {
        /// <summary>
        /// Configura o Status com as informações enviadas através dos parâmetros
        /// message, typeMessage e sbeln. Se o Status enviado for null, então cria um Status
        /// com as informações internas
        /// </summary>
        /// <param name="status">Objeto Status que será configurado</param>
        /// <param name="numberOfMessage">Número que a Mensagem se refere</param>
        /// <param name="kindOfMessage">Qual o tipo de Mensagem que se refere</param>
        /// <param name="sbeln">Número do embarque</param>
        public static void ConfigureStatus(Status status, NumberOfMessage numberOfMessage, string kindOfMessage, string sbeln = null)
        {
            if (status == null)
            {
                status = new Status();
                status.CODE = MessagesOfReturn.InternalCode;
                status.DESC = MessagesOfReturn.Description;
            }
            status.SBELN = sbeln;
            status.Mensagem = (byte)numberOfMessage;
            status.DataRetorno = ConfigureDate.ActualDate;
            status.Tipo = kindOfMessage;
        }


        /// <summary>
        /// Se foi informado um Embarque, insere o SBELN no status
        /// Salva o Status no Banco de dados
        /// Se o status possuir uma List de Status, com outros erros, salvará esses erros na tabela DetalheErros
        /// </summary>
        /// <param name="status">Status com o erro</param>
        /// <param name="embarque">Embarque</param>
        public static  void SaveStatus(Status status, Embarque embarque = null)
        {
            if (embarque != null && !string.IsNullOrEmpty(embarque.SBELN))
                status.SBELN = embarque.SBELN;

            new StatusDao().Save(status);

            //Salva no BD os detalhes
            if (status.ERRORS != null && status.ERRORS.Count > 0)
            {
                IList<DetalheError> detalhes = new List<DetalheError>();
                foreach (Status erro in status.ERRORS)
                    detalhes.Add(new DetalheError(erro, status));

                new DetalheErrorDao().SaveAll(detalhes);
            }
        }
    }
}
