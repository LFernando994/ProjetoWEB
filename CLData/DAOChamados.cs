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
    public class DAOChamados<T>
    {
        public List<T> chamados;
        string path = ConfigurationManager.AppSettings["Chamados"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOChamados()
        {
            this.chamados = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona a solicitação de chamado
        /// </summary>
        /// <param name="chamado"></param>
        public void Adicionar(T chamado)
        {
            this.chamados.Add(chamado);
        }

        /// <summary>
        /// Remove determinado chamado 
        /// </summary>
        /// <param name="chamado"></param>
        public void Remover(T chamado)
        {
            try
            {
                this.chamados.Remove(chamado);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, chamados);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista todos os chamados do xml
        /// </summary>
        /// <returns></returns>
        public List<T> ListarTodos()
        {
            return this.chamados;
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
                ser.Serialize(fs, this.chamados);
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
                    this.chamados = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.chamados);
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
