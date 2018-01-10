using BL.DAO;
using BL.ObjectMessages;
using BL.InnerUtil;
using System.Collections.Generic;
using System;

namespace BL.Command
{
    public abstract class ConfigStatus
    {
        /// <summary>
        /// Configura o Status com as informações enviadas através dos parâmetros
        /// message, typeMessage e sbeln. Se o Status enviado for null, então cria um Status
        /// com as informações internas
        /// </summary>
        /// <param name="status">Objeto Status que será configurado</param>
        /// <param name="message">Qual a Mensagem que o Status pertence</param>
        /// <param name="typeMessage">Qual o tipo de Mensagem que o Status pertence</param>
        /// <param name="sbeln">De qual SBELN que o Status pertence</param>
        protected void ConfigureStatus(Status status, byte message, string typeMessage, string sbeln = null)
        {
            if (status == null)
            {
                status = new Status();
                status.CODE = MessagesOfReturn.INTERN_CODE;
                status.DESC = MessagesOfReturn.DESC_CODE;
            }
            status.SBELN = sbeln;
            status.Mensagem = message;
            status.DataRetorno = ConfigureDate.ActualDate;
            status.Tipo = typeMessage;
        }

        /// <summary>
        /// Se foi informado um Embarque, insere o SBELN no status
        /// Salva o Status no Banco de dados
        /// Se o status possuir uma List de Status, com outros erros, salvará esses erros na tabela DetalheErros
        /// </summary>
        /// <param name="status">Status com o erro</param>
        /// <param name="embarque">Embarque</param>
        protected void SaveStatus(Status status, Embarque embarque = null)
        {
             
            if (embarque != null && !string.IsNullOrEmpty(embarque.SBELN))
                status.SBELN = embarque.SBELN;

            new StatusDao().Save(status);

            //Salva no BD os detalhes
            if (status.ERRORS.Count > 0)
            {
                IList<DetalheError> detalhes = new List<DetalheError>();
                foreach (Status erro in status.ERRORS)
                    detalhes.Add(new DetalheError(erro, status));

                new DetalheErrorDao().SaveAll(detalhes);
            }
        }
    }
}
