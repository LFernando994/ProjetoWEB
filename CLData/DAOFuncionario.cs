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
    public class DAOFuncionario<T>
    {
        public List<T> funcionarios;
        string path = ConfigurationManager.AppSettings["Funcionarios"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOFuncionario()
        {
            this.funcionarios = new List<T>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado acesso
        /// </summary>
        /// <param name="funcionario"></param>
        public void Adicionar(T funcionario)
        {
            this.funcionarios.Add(funcionario);
        }

        /// <summary>
        /// Remove determinado acesso
        /// </summary>
        /// <param name="funcionario"></param>
        public void Remover(T funcionario)
        {
            try
            {
                this.funcionarios.Remove(funcionario);
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, funcionarios);
                fs.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }          
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
                ser.Serialize(fs, this.funcionarios);
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
                    this.funcionarios = ser.Deserialize(fs) as List<T>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.funcionarios);
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

        /// <summary>
        /// Lista todos os clientes do xml
        /// </summary>
        /// <returns></returns>
        public List<T> ListarTodos()
        {
            Carregar();
            return this.funcionarios;
        }
        #endregion

  
     
    }
}
