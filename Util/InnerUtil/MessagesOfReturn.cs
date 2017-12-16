namespace Util.InnerUtil
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
        public const string ERROR_CONSULT_LISTA_EMBARQUE_ESTRUTURA = "Foi solicitado a Lista de Embarque ao GTE com sucesso, porém o GTE retornou erro. Verifique os dados da request";
        public const string ERROR_CONSULTA_EMBARQUE_NULL = "Não foi possível desserializar a Lista de Embarque. Verifique se os dados da requisição estão corretos.";
        public const string ERROR_CONSULTA_PC_ESTRUTURA = "A Consulta da Prestação de Conta do Embarque ? foi efetuado ao GTE com sucesso, porém retornou erro. Verifique os dados do Request.";
        public const string ERROR_ATUALIZA_PC_GTE = "Ocorreu erro ao atualizar a Prestação de Contas para o Embarque ? no GTE. Possivelmente a Prestação de Contas do Embarque esta em branco.";
        public const string ERROR_ATUALIZA_EMBARQUE_GTE = "Ocorreu erro ao atualizar o Embarque ? no GTE. Possivelmente o Detalhe do Embarque esta em branco.";
        public const string ERROR_CONSULT_DETALHE_EMBARQUE_ESTRUTURA = "Foi solicitado o Detalhe do Embarque ? ao GTE com sucesso, porém o GTE retornou erro. Verifique os dados da request";
        public const string ERROR_ALTERA_FLAG_CONSULTA_PREST_CONTA = "Erro ao alterar a flag Consulta Prestaçã de Conta do Embarque ?.";
        public const string ERROR_OBTER_ID_PRESTACAO_CONTA = "Erro ao obter o ID da Prestação de Conta.";
        public const string ERROR_OBTER_ID_PC_EMPTY = "Não foi possível obter o ID da Prestação de Conta, Embarque informado é nulo";
        public const string ERROR_SAVE_PC_TXPNS = "Erro ao salvar a Consulta Prestação de Contas, tabela TXPNS.";
        public const string ERROR_PC_NO_INFO = "O retorno da Consulta da Prestação de Conta do Embarque ? foi recebido com sucesso, porém o valor do campo PCTYP esta diferente do padrão (AD ou PC)";
        public const string ERROR_CONFIG_SERVICE = "Ocorreu erro ao serializar o arquivo de configuração do serviço.";
        public const string ERROR_CREATE_LOG_USER = "Não foi possível criar o arquivo de log do usuário.";
        public const string ERRORCREATELOGSUPORT = "Não foi possível criar o arquivo de log do suporte.";
        public const string ERROR_CREATE_LOG_EXCEPTION = "Exception:";
        public const string ERROR_OPEN_FILE_CONFIG = "Não foi possível abrir o Configurador.";
        public const string ERROR_SAVE_CONFIG = "As configurações não foram alteradas.";
        public const string ERROR_SAVE_CONFIG_COMPL = "Verifique se você possui acesso ao diretório de configuração do serviço TrocaXML.";
        public const string ERROR_SERIALIZA_CONSULTA = "Ocorreu erro ao serilizar os dados do objeto ? para efetuar a consulta no Web Service.";
        public const string ERROR_DESERIALIZE_RETORNO = "Ocorreu erro ao desserializar o(a) ? recebida do Web Service.";
        public const string ERROR_COMUNICATE_GTE = "Ocorreu erro ao trocar a Mensagem com o Web Service GTE.";
        public const string ERROR_FIELD = "Os campos não podem ser em branco. Verique o(s) campo(s) abaixo: ";
        public const string ERROR_PC_INCORRECT = "A atualização da Prestação de Contado Embarque ? foi recebido com sucesso, porém não foi salvo no banco dados, possivelmente os dados estão incorretos.";
        public const string ERROR_SAVE_XML = "Ocorreu erro ao salvar o XML ?. Verifique se o diretório existe ou se possui permissão de escrita";
        public const string ERROR_OBJECT_FOR_SERIALIZER_NULL = "O objeto enviado para serializar e string no formato XML esta nulo";
        //Fim Mensages de erro

        //Mensagens de sucesso
        public const string EMBARQUE_ATUALIZADO = "Lista de Embarque atualizado.";
        public const string SUCCESS_CONSULTA_PRESTACAO_CONTA = "A tabela TPCK da Prestação de Conta do Embarque ? foi atualizado com sucesso.";
        public const string SUCCESS_ATUALIZA_PRESTACAO_CONTA = "A Prestação de Contas do Embarque ? foi enviada com sucesso ao GTE.";
        public const string SUCCESS_ATUALIZA_DETALHE_EMBARQUE = "O Detalhe do Embarque ? enviado com sucesso ao GTE.";
        public const string SUCCESS_SALVA_PRESTACAO_CONTA_TXPNS = "A Prestação de Conta, tabela TXPNS, do Embarque ? foi salva com sucesso.";
        public const string SUCCESS_UPDATE_CONFIG = "Configurações alterada com sucesso.";
        //Fim mensagens de sucesso

        //Mensagens de Alerta
        public const string ALERT_RETORNO_ATUALIZA_DETALHE_EMBARQUE_EMPTY = "Não possui nenhum Detalhe de Embarque para atualizar no GTE.";
        public const string ALERT_RETORNO_DETALHE_EMBARQUE_EMPTY = "Não há Detalhe disponível para o Embarque ?.";
        public const string ALERT_CONSULTA_DETALHE_EMBARQUE_EMPTY = "Não existe embarque disponível para consulta de Detalhes.";
        public const string ALERT_RETORNO_DETALHE_EMBARQUE = "O Detalhe do Embarque ? salvo com sucesso.";
        public const string ALERT_ATUALIZA_PRESTACAO_CONTA_EMPTY = "Não há Embarque disponível para efetuar a Prestação de Contas.";
        public const string ALERT_CONSULTA_PRESTACAO_CONTA_EMPTY = "Não há Embarque disponível para efetuar a Consulta da Prestação de Conta.";
        public const string ALERT_EMBARQUE_PRESTACAO_CONTA_EMPTY = "O Embarque selecionado para Consulta da Prestação de Contas esta em branco.";
        public const string ALERT_EMBARQUE_EMPTY = "Não foi possível recuperar o ID do Embarque pois não foi informado o código do embarque.";
        public const string ALERT_ATUALIZA_PRESTACAO_CONTA_ERROR = "A Prestação de Contas do Embarque ? foi enviada com sucesso ao GTE, porém retornou erro.";
        public const string ALERT_ATUALIZA_DETALHE_EMBARQUE_ERROR = "A Atualização do Detalhe do Embarque ? foi enviada com sucesso ao GTE, porém retornou erro.";
        public const string ALERT_ATUALIZA_DETALHE_EMBARQUE_REG_EMPTY = "O Embarque ? esta marcado para enviar a Atualização ao GTE, porém não há dados do Detalhe de Embarque do embarque ? no banco dados.";
        public const string ALERT_ATUALIZA_PC_EMBARQUE_REG_EMPTY = "O Embarque ? esta marcado para enviar a Prestação de Contas ao GTE, porém não há dados do Prestação de Contas de Embarque do embarque ? no banco dados.";
        public const string ALERT_EMBARQUE_EMPTY_OR_NULL = "O Embarque selecionado esta nulo ou em branco. Consulta Detalhe Embarque abortado.";
        public const string ALERT_ATUALIZA_PC_EMPTY = "O GTE não retornou os dados da Consulta da Prestação de Contas do Embarque ?.";
        public const string ALERT_CONSULTA_PC_EMPTY = "A Consulta da Prestação de Conta do Embarque ? foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado.";
        public const string ALERT_RESPONSE_CONSULTA_DETALHE_EMBARQUE_EMPTY = "A Consulta do Detalhe do Embarque ? foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado.";
        public const string ALERT_RESPONSE_CONSULTA_EMBARQUE_EMPTY = "A Consulta de Lista de Embarque foi efetuado ao GTE com sucesso, porém o GTE não retornou nenhuma dado.";
        public const string ALERT_CONFIG_SERVICE_EMPTY = "Não foi informado o conteúdo do arquivo de configuração do serviço.";
        public const string ALERT_DATA_REQUEST_NOT_FOUND = "Não foi localizado os dados necessários para efetuar a Consulta da Lista de Embarques";
        public const string ALERT_STRING_FOR_GTE_NULL = "Não foi informado nenhum valor para ser enviado ao Web Service";
        public const string ALERT_XML_FOR_DB_NULL = "Não foi informado nenhum valor para desserializar";
        public const string ALERT_RETORNO_CONSULTA_LISTA_EMBARQUE = "Nenhum Embarque recebido do GTE.";        
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
    }
}
