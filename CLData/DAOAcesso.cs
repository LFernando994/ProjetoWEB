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
    public class DAOAcesso<T>
    {
        public List<T> acessos;
        string path = ConfigurationManager.AppSettings["Acessos"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOAcesso()
        {
            this.acessos = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado acesso
        /// </summary>
        /// <param name="cliente"></param>
        public void Adicionar(T acesso)
        {
            this.acessos.Add(acesso);
        }

        /// <summary>
        /// Remove determinado acesso
        /// </summary>
        /// <param name="acesso"></param>
        public void Remover(T acesso)
        {      
            try
            {
                this.acessos.Remove(acesso);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, acessos);
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
            Carregar();
            return this.acessos;
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
                ser.Serialize(fs, this.acessos);
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
                    this.acessos = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.acessos);
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
