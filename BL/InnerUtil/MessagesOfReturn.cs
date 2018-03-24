using System;

namespace BL.InnerUtil
{
    /// <summary>
    /// Mensagens que serão utilizados nos log, tanto em arquivo quanto no bando de dados
    /// </summary>
    public static class MessagesOfReturn
    {
        public static string ExceptionRequestWebService { get { return $"Ocorreu uma exceção ao efetuar a comunicação com o WebService. Verifique as exceções internas:{Environment.NewLine}"; } }
        public static string ExceptionDeserializeXml { get { return $"Ocorreu uma exceção ao desserializar um arquivo Xml. Verifique as exceções internas:{Environment.NewLine}"; } }
        public static string ExceptionSerializeXml { get { return $"Ocorreu uma exceção ao serializar um arquivo Xml. Verifique as exceções internas:{Environment.NewLine}"; } }
        public static string ExceptionGetDatasToRequest { get { return $"Ocorreu uma exceção ao obter os dados para a requisição. Verifique as exceções internas:{Environment.NewLine}"; } }
        public static string InternalCode { get { return "Interno"; } }
        public static string Description { get { return "Não recebeu nenhuma informação do WebService"; } }
        public static string LineDashed { get { return $"---------------------------------------------------------------------------------{Environment.NewLine} "; } }
        public static string ActualDateInfo { get { return $"Data: {DateTime.Now.ToLocalTime()}{Environment.NewLine}"; } }
        public static string ErrorOpenFileConfig { get { return "Não foi possível abrir o arquivo de configuração"; } }
        public static string ErrorInfo { get { return "Error: "; } }
        public static string Information { get { return "Informação: "; } }
        public static string SuccessUpdateConfig { get { return "Configurações alteradas com sucesso"; } }
        public static string NotSaveUpdateTitle { get { return "As configurações não foram alteradas"; } }
        public static string NotSaveUpdateConfig { get { return "Verifique se você possui acesso ao diretório de configuração do serviço TrocaXML"; } }
        public static string FieldEmpty { get { return "Os campos não podem ser em branco. Verique o(s)campo(s) abaixo: "; } }
        public static string NewLine { get { return $"{Environment.NewLine}"; } }
        public static string CodeErrorInfo(int code) { return $"* Código: {code} *{Environment.NewLine}"; }
        
        public static string ExceptionSaveXml(string nameXml)
        {
            return $"Ocorreu erro ao salvar o XML {nameXml}. Verifique se o diretório existe ou se possui permissão de escrita.{Environment.NewLine}";
        }

        public static string ExceptionMessageLogSupport(string message, string sbeln, NumberOfMessage numberOfMessage)
        {
            if(numberOfMessage == NumberOfMessage.One || string.IsNullOrEmpty(sbeln))
                return $"O processo da {message} falhou.{Environment.NewLine}Mensagem:{Environment.NewLine}";
            else
                return $"O processo da {message} para o embarque {sbeln} falhou.{Environment.NewLine}Mensagem:{Environment.NewLine}";
        }
        public static string ExceptionMessageLogUser(int code, string messageError)
        {
            return $"Erro no processamento. Código: {code}. Consulte o log do suporte para maiores detalhes.{Environment.NewLine}";
        }
        public static string ErrorAccessPath(string fileName, string filePath)
        {
            fileName = fileName.Remove(0, 1);
            return $"Não foi possível gravar o log {fileName} no diretório {filePath}. Verifique as permissões no diretório.{Environment.NewLine}";
        }
        public static string ProcessMessageOneSuccess(string message, int idBroker)
        {
            return $"A {message} requirida pelo Broker ID {idBroker} foi executada com sucesso.{Environment.NewLine}";
        }
        public static string ProcessMessageSuccess(string message, string embarque)
        {
            return $"A {message} para o embarque {embarque} foi executada com sucesso.{Environment.NewLine}";
        }
        public static string DatasToRequestEmpty(string message, string sbeln)
        {
            return $"A {message} para o embarque {sbeln} esta configurada para requisição, porém os dados necessários para efetuar a requisição não foram encontrados.{Environment.NewLine}";
        }
        public static string DatasToRequestEmpty(string message)
        {
            return $"A {message} esta configurada para requisição, porém os dados necessários não foram encontrados.{Environment.NewLine}";
        }
        public static string NotRequest(string message)
        {
            return $"A requisição da {message} não foi solicitada.{Environment.NewLine}";
        }
        public static string AlertResponseWebServiceError(string message, string identifier, NumberOfMessage numberOfMessage)
        {
            if(numberOfMessage == NumberOfMessage.One)
                return $"O processo da {message} requisitado pelo IdBroker {identifier} foi enviada com sucesso, porém retornou erro, consulte as tabelas StatusRetorno e DetalheError para maiores informações. {Environment.NewLine}";
            else
                return $"O Embarque \"{identifier}\" para o processo \"{message}\" foi enviada com sucesso, porém retornou erro, consulte as tabelas StatusRetorno e DetalheError para maiores informações. {Environment.NewLine}";
        } 
        public static string TotalTime(TimeSpan total)
        {
            return $"Tempo total: {total}{Environment.NewLine}";
        }
        public static string TitleLogUser(NumberOfMessage message)
        {
            return $"Mensagem: {(byte)message}{Environment.NewLine}";
        }
        public static string Message(NumberOfMessage message, string tipo)
        {
            return $"Mensagem: {(byte)message} - Tipo: {tipo}";
        }
        public static string DescriptionUpdateXblnrSuccess(string xblnr, string originalDesc)
        {
            return $"{originalDesc} - STATU do XBLNR {xblnr} atualizado com sucesso.";
        }
        public static string DescriptionUpdateXblnrNotFound(string xblnr, string originalDesc)
        {
            return $"{originalDesc} - STATU do XBLNR {xblnr} enviado pelo Webservice, porém não localizado no banco de dados.";
        }
        public static string DetailProcessWithIdBroker(string message, string idBroker)
        {
            return $"{message} - ID Broker {idBroker}";
        }
        public static string DetailProcessWithSblen(string message, string sblen)
        {
            return $"{message} - Embarque {sblen}";
        }
    }
}
