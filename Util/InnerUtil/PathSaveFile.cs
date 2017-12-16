using System;

namespace Util.InnerUtil
{
    /// <summary>
    /// Classe estática que fornece o caminho completo e o nome que os arquivos de log serão salvos
    /// </summary>
    public static class PathSaveFile
    {
        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Requisição da Importação
        /// </summary>
        /// <param name="rootFolder">diretório root que será salvo o arquivo</param>
        /// <param name="embarque">Ultima parte do nome do arquivo</param>
        /// <param name="message">Define qual subdiretorio que a Mensagem pertence</param>
        /// <returns></returns>
        public static string PathMessageRequestImportation(string rootFolder, string embarque, int message)
        {
            return String.Format("{0}\\Mensagem\\Mensagem{1}\\Request\\Importacao{2}{3}{4}", 
                                rootFolder, message, embarque, ConfigureDate.DateNameFile, ".xml");
        }

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Resposta da Importação
        /// </summary>
        /// <param name="rootFolder">diretório root que será salvo o arquivo</param>
        /// <param name="embarque">Ultima parte do nome do arquivo</param>
        /// <param name="message">Define qual subdiretorio que a Mensagem pertence</param>
        /// <returns></returns>
        public static string PathMessageResponseImportation(string rootFolder, string embarque, int message)
        {
            return String.Format("{0}\\Mensagem\\Mensagem{1}\\Response\\Importacao{2}{3}{4}", 
                                rootFolder, message, embarque, ConfigureDate.DateNameFile, ".xml");
        }
        

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Requisição da Exportação
        /// </summary>
        /// <param name="rootFolder">diretório root que será salvo o arquivo</param>
        /// <param name="embarque">Ultima parte do nome do arquivo</param>
        /// <param name="message">Define qual subdiretorio que a Mensagem pertence</param>
        /// <returns></returns>
        public static string PathMessageRequestExportation(string rootFolder, string embarque, int message)
        {
            return String.Format("{0}\\Mensagem\\Mensagem{1}\\Request\\Exportacao{2}{3}{4}",
                                rootFolder, message, embarque, ConfigureDate.DateNameFile, ".xml");
        }

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Resposta da Exportação
        /// </summary>
        /// <param name="rootFolder">diretório root que será salvo o arquivo</param>
        /// <param name="embarque">Ultima parte do nome do arquivo</param>
        /// <param name="message">Define qual subdiretorio que a Mensagem pertence</param>
        /// <returns></returns>
        public static string PathMessageResponseExportation(string rootFolder, string embarque, int message)
        {
            return String.Format("{0}\\Mensagem\\Mensagem{1}\\Response\\Exportacao{2}{3}{4}",
                                rootFolder, message, embarque, ConfigureDate.DateNameFile, ".xml");
        }
    }
}
