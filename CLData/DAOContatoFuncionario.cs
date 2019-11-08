using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CLData
{
    public class DAOContatoFuncionario<T>
    {
        public List<T> contatos;
        string path = ConfigurationManager.AppSettings["ContatosFuncionario"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOContatoFuncionario()
        {
            this.contatos = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado acesso
        /// </summary>
        /// <param name="contato"></param>
        public void Adicionar(T contato)
        {
            this.contatos.Add(contato);
        }

        /// <summary>
        /// Remove determinado acesso
        /// </summary>
        /// <param name="contato"></param>
        public void Remover(T contato)
        {
            try
            {
                this.contatos.Remove(contato);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, contatos);
                fs.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        /// <summary>
        /// Lista todos os clientes do xml
        /// </summary>
        /// <returns></returns>
        public List<T> ListarTodos()
        {
            return this.contatos;
        }

        /// <summary>
        /// Salva no arquivo xml as informações 
        /// </summary>
        public void Salvar()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                ser.Serialize(fs, this.contatos);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Carregar arquivo xml
        /// </summary>
        public void Carregar()
        {
            if (Directory.Exists(diretorio))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                try
                {
                    this.contatos = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.contatos);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                DirectoryInfo dic = new DirectoryInfo(diretorio);
                dic.Create();
                Carregar();
            }
        }
        #endregion
      
    }
}
