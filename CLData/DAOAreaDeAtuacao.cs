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
    public class DAOAreaDeAtuacao<T>
    {
        public List<T> areas { get; set; }
        string path = ConfigurationManager.AppSettings["AreasDeAtuacao"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOAreaDeAtuacao()
        {
            this.areas = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado acesso
        /// </summary>
        /// <param name="area"></param>
        public void Adicionar(T area)
        {
            this.areas.Add(area);
        }

        /// <summary>
        /// Remove determinado acesso
        /// </summary>
        /// <param name="area"></param>
        public void Remover(T area)
        {
            try
            {
                this.areas.Remove(area);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, areas);
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
            return this.areas;
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
                ser.Serialize(fs, this.areas);
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
                    this.areas = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.areas);
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
