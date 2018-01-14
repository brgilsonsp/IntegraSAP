using System;

namespace BL.InnerUtil
{
    public class PathSaveFile
    {
        private string _rootFolder;
        private string _embarque;
        private int _message;

        public PathSaveFile(string _rootFolder, string _embarque, int _message)
        {
            this._rootFolder = _rootFolder;
            this._embarque = _embarque;
            this._message = _message;
        }

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Requisição da Importação
        /// </summary>
        public string PathFileMessageRequestImportation
        {
            get { return $"{DirectoryFileMessageRequest}\\Importacao{_embarque}{ConfigureDate.DateNameFile}.xml"; }
        }                

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Mensage de Resposta da Importação
        /// </summary>
        public string PathFileMessageResponseImportation
        {
            get { return $"{DirectoryFileMessageResponse}\\Importacao{_embarque}{ConfigureDate.DateNameFile}.xml"; }
        }        

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Menssagem de Requisição da Exportação
        /// </summary>
        public string PathFileMessageRequestExportation
        {
            get { return $"{DirectoryFileMessageRequest}\\Exportacao{_embarque}{ConfigureDate.DateNameFile}.xml"; }
        }

        /// <summary>
        /// Retorna o caminho completo do nome do arquivo para a Menssagem de Resposta da Exportação
        /// </summary>
        public string PathFileMessageResponseExportation
        {
            get { return $"{DirectoryFileMessageResponse}\\Exportacao{_embarque}{ConfigureDate.DateNameFile}.xml"; }
        }




        /// <summary>
        /// Retorna o diretório do arquivo para a Menssagem de Requisição da Importação
        /// </summary>
        public string DirectoryFileMessageRequest
        {
            get { return $"{_rootFolder}\\Mensagem\\Mensagem{_message}\\Request"; }
        }


        /// <summary>
        /// Retorna o diretório do arquivo para a Menssagem de Resposta
        /// </summary>
        public string DirectoryFileMessageResponse
        {
            get { return $"{_rootFolder}\\Mensagem\\Mensagem{_message}\\Response"; }
        }
    }
}
