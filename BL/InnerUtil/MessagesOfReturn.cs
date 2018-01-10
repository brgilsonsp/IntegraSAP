using BL.ObjectMessages;
using System;
using System.Collections.Generic;

namespace BL.InnerUtil
{
    public static class MessagesOfReturn
    {

        //Mensagens de Erro
        public const string ERROR_CONSULTA_LISTA_EMBARQUE_DB = "Ocorreu erro ao efetuar a Consulta da Lista de Embarque.";
        public const string ERROR_CONSULTA_EMBARQUE_DB = "Ocorreu um erro ao obter os dados para efetuar a consulta de um Embarque.";
        public const string ERROR_OBTEM_ID_EMBARQUE = "Erro ao obter o ID do Embarque no banco de dados.";
        public const string ERROR_UPDATE_LISTA_EMBARQUE_DB = "Ocorreu erro ao salvar a Lista de Embarque no banco de dados.";
        public const string ERROR_UPDATE_PC_EMBARQUE_ATUALIZADO = "Ocorreu erro ao alterar a flag Atualiza Prestação de Contas do Embarque ?.";
        public const string ERRO_ALTERA_FLAG_EMBARQUECONSULTADO = "Erro ao alterar a flag Detalhe Consultado.";
        public const string ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD = "Ocorreu um erro ao salvar o ? do detalhe do embarque no banco de dados.";
        public const string ERROR_UPDATE_DETALHE_EMBARQUE_DB = "Ocorreu um erro ao salvar o detalhe do embarque no banco de dados.";
        public const string ERROR_ATUALIZA_PC = "Ocorreu erro ao atualizar a Consulta da Prestação de Conta do Embarque ? no banco de dados.";
        public const string ERROR_ALTERA_DETALHE_EMBARQUE_ATUALIZADO = "Ocorreu erro ao alterar a flag de Atualiza Detalhe Embarque do Embarque ?.";
        public const string ERROR_SAVE_RESPONSE_ATUALIZACAO_GTE = "Erro ao salvar o status da atualização da Mensagem ?.";
        public const string ERROR_CONSULT_LIST_EMBARQUE_ATUALIZA_DETALHE = "Ocorreu erro ao obter o(s) o identificador do(s) Embarque(s) configurado(s) para atualizar o Detalhe.";
        public const string ERROR_CONSULTA_EMBARQUES_PRESTACAO_CONTA = "Ocorreu erro ao obter os Embarques disponíveis para Prestação de Contas.";
        public const string ERROR_CONSULT_DETALHE_EMBARQUE = "Não foi possível obter o Detalhe do Embarque ?.";
        public const string ERROR_CONSULTA_LISTA_PRESTACAO_CONTA_CONSULTA = "Erro ao obter os dados necessário para efetuar a Consulta da Prestação de Conta.";
        public const string ERROR_CONSULTA_PRESTACA_CONTA = "Ocorreu erro ao obter a Prestação de Conta do Embarque ?.";
        
        public static string ErrorStructureRequest(string message, string idBroker, IList<Status> listDetailError)
        {
            string desc = "";
            foreach (Status error in listDetailError)
                desc += String.Format("* {0}{1}", error.DESC, Environment.NewLine);

            return String.Format("Os dados para a requisição {0} do IDBroker {1} estão incorretos. Segue o detalhe do retorno:{2}{3}{2}",
                message, idBroker, Environment.NewLine, desc);
        }

        public const string ERROR_CONSULTA_PC_ESTRUTURA = "A Consulta da Prestação de Conta do Embarque ? foi efetuado ao GTE com sucesso, porém retornou erro. Verifique os dados do Request.";
        public const string ERROR_ATUALIZA_PC_GTE = "Ocorreu erro ao atualizar a Prestação de Contas para o Embarque ? no GTE. Possivelmente a Prestação de Contas do Embarque esta em branco.";
        public const string ERROR_ATUALIZA_EMBARQUE_GTE = "Ocorreu erro ao atualizar o Embarque ? no GTE. Possivelmente o Detalhe do Embarque esta em branco.";

        

        public const string ERROR_ALTERA_FLAG_CONSULTA_PREST_CONTA = "Erro ao alterar a flag Consulta Prestaçã de Conta do Embarque ?.";
        public const string ERROR_OBTER_ID_PRESTACAO_CONTA = "Erro ao obter o ID da Prestação de Conta.";
        public const string ERROR_OBTER_ID_PC_EMPTY = "Não foi possível obter o ID da Prestação de Conta, Embarque informado é nulo";
        public const string ERROR_SAVE_PC_TXPNS = "Erro ao salvar a Consulta Prestação de Contas, tabela TXPNS.";
        /// <summary>
        /// Retorna mensagem que será utilizada no Log quando o campo PC recebido estiver fora do padrão, (AD/PC)
        /// </summary>
        /// <param name="embarque">Embarque</param>
        /// <param name="cnpjBroker">CNPJ do requerente</param>
        /// <returns></returns>
        public static string ErroFieldPC(string embarque, string cnpjBroker)
        {
            return String.Format(
                "O retorno da Consulta da Prestação de Conta do Embarque {0} requerida pelo CNPJ {1} foi recebido com sucesso, porém o valor do campo PCTYP esta diferente do padrão (AD ou PC).",
                embarque, cnpjBroker);
        }
        public const string ERROR_CONFIG_SERVICE = "Ocorreu erro ao serializar o arquivo de configuração do serviço.";
        public const string ERROR_CREATE_LOG_USER = "Não foi possível criar o arquivo de log do usuário.";
        public const string ERRORCREATELOGSUPORT = "Não foi possível criar o arquivo de log do suporte.";
        public const string ERROR_CREATE_LOG_EXCEPTION = "Exception:";
        public const string ERROR_OPEN_FILE_CONFIG = "Não foi possível abrir o Configurador.";
        public const string ERROR_SAVE_CONFIG = "As configurações não foram alteradas.";
        public const string ERROR_SAVE_CONFIG_COMPL = "Verifique se você possui acesso ao diretório de configuração do serviço TrocaXML.";


        public static string ErrorSerializeConsulting(string nameClass)
        {
            return String.Format("Ocorreu erro ao serilizar os dados do objeto {0} para efetuar a consulta no Web Service.",
                nameClass);
        }
        
        public static string ErrorDeserializeResponse(string nameClass)
        {
            return String.Format("Ocorreu erro ao desserializar o(a) {0} recebida do Web Service.", nameClass);
        }


        public const string ERROR_FIELD = "Os campos não podem ser em branco. Verique o(s) campo(s) abaixo: ";
        public const string ERROR_PC_INCORRECT = "A atualização da Prestação de Contado Embarque ? foi recebido com sucesso, porém não foi salvo no banco dados, possivelmente os dados estão incorretos.";


        public static string ErrorSaveXml(string nameXml, Exception ex)
        {
            return String.Format(
                "Ocorreu erro ao salvar o XML {0}. Verifique se o diretório existe ou se possui permissão de escrita.{1}{2}{1}",
                    nameXml, Environment.NewLine, ex.Message);
        }
        
        //Fim Mensages de erro

        

        //Message success

        public static string ProcessMessageOneSuccess(string message, int idBroker)
        {
            return $"{message} requirida pelo Broker ID {idBroker} atualizado.{Environment.NewLine}";
        }
        
        //public static string SucessConsultaPrestacaoConta(string embarque, string cnpjRequerente)
        //{
        //    return String.Format("A tabela TPCK da Prestação de Conta do Embarque {0} requerida pelo CNPJ {1} foi atualizado com sucesso.",
        //        embarque, cnpjRequerente);
        //}
        //public static string SucessoRetornoDetalheEmbarque(string embarque)
        //{
        //    return String.Format("O Detalhe do Embarque {0} salvo com sucesso.{1}", embarque, Environment.NewLine);
        //}
        //public const string SUCCESS_ATUALIZA_PRESTACAO_CONTA = "A Prestação de Contas do Embarque ? foi enviada com sucesso ao GTE.";
        //public const string SUCCESS_SALVA_PRESTACAO_CONTA_TXPNS = "A Prestação de Conta, tabela TXPNS, do Embarque ? foi salva com sucesso.";

        public static string ProcessMessageSuccess(string message, string embarque)
        {
            return $"{message} para o embarque {embarque} foi executada com sucesso.{Environment.NewLine}";
        }

        
        public const string SUCCESS_UPDATE_CONFIG = "Configurações alterada com sucesso.";
        //Fim mensagens de sucesso




        //Mensagens de Alerta
        public const string ALERT_RETORNO_ATUALIZA_DETALHE_EMBARQUE_EMPTY = "Não possui nenhum Detalhe de Embarque para atualizar no GTE.";
        //public const string ALERT_RETORNO_DETALHE_EMBARQUE_EMPTY = "Não há Detalhe disponível para o Embarque ?.";

        //checado
        public static string AlertRequestMessage2ExportationEmpty = $"Não existe embarque disponível para consulta de Detalhes.{Environment.NewLine}";


        public const string ALERT_ATUALIZA_PRESTACAO_CONTA_EMPTY = "Não há Embarque disponível para efetuar a Prestação de Contas.";
        public const string ALERT_CONSULTA_PRESTACAO_CONTA_EMPTY = "Não há Embarque disponível para efetuar a Consulta da Prestação de Conta.";
        public const string ALERT_EMBARQUE_PRESTACAO_CONTA_EMPTY = "O Embarque selecionado para Consulta da Prestação de Contas esta em branco.";
        public const string ALERT_EMBARQUE_EMPTY = "Não foi possível recuperar o ID do Embarque pois não foi informado o código do embarque.";
        //public const string ALERT_ATUALIZA_PRESTACAO_CONTA_ERROR = "A Prestação de Contas do Embarque ? foi enviada com sucesso ao GTE, porém retornou erro.";

        public static string AlertResponseWebServiceError(string message, string embarque)
        {
            return $"O Embarque \"{embarque}\" para o processo \"{message}\" foi enviada com sucesso, porém retornou erro, consulta a tabela StatusError. {Environment.NewLine}";
        }

        public static string AlertAtualizaDetalheEmbarqueEmpty(string embarque)
        {
            return $"O Embarque {embarque} esta marcado para enviar a Atualização ao GTE, porém não há dados do Detalhe de Embarque para esse embarque no banco dados.{Environment.NewLine}";
        }

        public const string ALERT_ATUALIZA_PC_EMBARQUE_REG_EMPTY = "O Embarque ? esta marcado para enviar a Prestação de Contas ao GTE, porém não há dados do Prestação de Contas de Embarque do embarque ? no banco dados.";
        public const string ALERT_EMBARQUE_EMPTY_OR_NULL = "O Embarque selecionado esta nulo ou em branco. Consulta Detalhe Embarque abortado.";
        public const string ALERT_ATUALIZA_PC_EMPTY = "O GTE não retornou os dados da Consulta da Prestação de Contas do Embarque ?.";
        public const string ALERT_CONSULTA_PC_EMPTY = "A Consulta da Prestação de Conta do Embarque ? foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado.";

        /// <summary>
        /// Retorna a mensagem abaixo concatenando o SBELN do parâmetro
        /// A Consulta do Detalhe do Embarque {0} foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado
        /// </summary>
        /// <param name="sbeln">SBELN</param>
        /// <returns>Uma string A Consulta do Detalhe do Embarque {0} foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado</returns>
        public static string AlertResponseConsultaDetalheEmbarqueEmpty(string sbeln)
        {
            return String.Format("A Consulta do Detalhe do Embarque {0} foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado.{1}",
                sbeln, Environment.NewLine);
        }

        /// <summary>
        /// Retorna mensagem que será utilizada no Log, quando o WebService não retornou os dados esperados de uma requisição
        /// </summary>
        /// <param name="message">Tipo da mensagem que esta sendo processada</param>
        /// <param name="embarque">Embarque que esta sendo efetuado o processo</param>
        /// <returns></returns>
        public static string AlertResponseEmptyOrError(string message, string embarque)
        {
            return String.Format("A {0}, para o embarque {1} foi efetuado ao Webservice com sucesso, porém a resposta esta em branco ou com erro, consulte a tabela StatusRetorno, se não localizou o erro na tabela StatusRetorno verifique se os dados do Broker e do Cabeçalho estão corretos.{2}",
                message, embarque, Environment.NewLine);
        }

        public static string FailedProcessMessageWithIdBroker(string message, string idBoker)
        {
            return $"O processo da {message} requisitado pelo IdBroker {idBoker} falhou, consulte a tabela StatusRetorno para maiores informações. Caso não obtenha " +
                $"informações na tabela StatusRetorno verifique se os dados do Broker e do Cabeçalho estão corretos.{Environment.NewLine}";
        }

        public static string FailedProcessMessageWithSbeln(string message, string sbeln)
        {
            return $"O processo da {message} para o embarque {sbeln} falhou, consulte a tabela StatusRetorno para maiores informações. Caso não obtenha informações " +
                $"na tabela StatusRetorno verifique se os dados do Broker e do Cabeçalho estão corretos.{Environment.NewLine}";
        }

        public const string ALERT_CONFIG_SERVICE_EMPTY = "Não foi informado o conteúdo do arquivo de configuração do serviço.";
        public const string ALERT_DATA_REQUEST_NOT_FOUND = "Não foi localizado os dados necessários para efetuar a Consulta da Lista de Embarques";
        //public const string ALERT_STRING_FOR_GTE_NULL = "Não foi informado nenhum valor para ser enviado ao Web Service";

        //checada
        public const string ALERT_XML_FOR_DB_NULL = "Não foi informado nenhum valor para desserializar";


        /// <summary>
        /// Retorna mensagem O WebService não respondeu a {0} requisitada pelo IdBroker {1}.{2}
        /// </summary>
        /// <param name="message">Mensagem que esta sendo processada</param>
        /// <param name="idBroker">Id do broker que efetuou a requisição</param>
        /// <returns></returns>
        public static string AlertReturnNull(string message, string idBroker)
        {
            return String.Format("O WebService não respondeu a {0} requisitada pelo IdBroker {1}.{2}",
                message, idBroker, Environment.NewLine);
        }
        //Fim Mensagens de Alerta

        public const string COD = "Código: ";
        public const string DESC = "Descrição: ";
        public const string INTERN_CODE = "Interno";
        public const string DESC_CODE = "Não recebeu nenhuma informação do GTE";
        public const string LINE_DASHED = "---------------------------------------------------------------------------------";
        public const string TITLE_MESSAGE = "Mensagem: ";
        public const string DATE_INFO = "Data: ";
        public const string START_ERROR = "******** INÍCIO ERRO ********";
        public const string COD_INFO = "* Código: *";
        public const string MESSAGE_INFO = "* Mensagem: *";
        public const string DETAIL_ARCHIVE = "Para mais detalhes do código de erro, consulte o arquivo ";
        public const string END_ERROR = "******** FIM ERRO ********";
        public const string RESULT_INFO = "Result: ";
        public const string SOURCE_INFO = "Source: ";
        public const string TRACE_INFO = "StackTrace: ";
        public const string TARGET_INFO = "TargetSite";
        public const string EXCPTION_INFO = "Exception";
        public const string MSG_EXCINFO = "Message Exception: ";
        public const string INNER_EXCINFO = "InnerException: ";
        public const string MSG_INNER_EXCP_INFO = "Message InnerException: ";
        public const string TITLE_MSG_EXCP_INFO = "Erro Desconhecido EXCEPTION";
        public const string ERROR_INFO = "Error: ";
        public const string INFORMATION = "Informação";
        public const string CODE_INTERN = "INTERNO";
        public const string DESC_INTER_PC = "Prestação de Conta divergente";

        public const string IMPORTATION_RESPONSE = "Resposta Importação";
        public const string IMPORTATION_REQUEST = "Requisição Importação";
        public const string EXPORTATION_RESPONSE = "Resposta Exportação";
        public const string EXPORTATION_REQUEST = "Requisição Exportação";
        
        public static string ProcessExportation(byte message)
        {
            return String.Format("Mensagem {0} - Exportação", message);
        }
    }
}
