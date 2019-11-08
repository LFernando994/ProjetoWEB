using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;

namespace CLData
{
    public class DAOCliente<T>
    {
        public List<T> clientes;
        string path = ConfigurationManager.AppSettings["Clientes"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOCliente()
        {
            this.clientes = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void Adicionar(T cliente)
        {
            this.clientes.Add(cliente);
        }

        /// <summary>
        /// Remove determinado cliente 
        /// </summary>
        /// <param name="cliente"></param>
        public void Remover(T cliente)
        {
            try
            {
                this.clientes.Remove(cliente);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, clientes);
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
            return this.clientes;
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
                ser.Serialize(fs, this.clientes);
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
                    this.clientes = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.clientes);
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


