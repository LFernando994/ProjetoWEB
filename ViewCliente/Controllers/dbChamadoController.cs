using CLRegras;
using InfraWeb.Repository;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using ViewCliente.Models;

namespace ViewCliente.Controllers
{
    public class dbChamadoController : Controller
    {
        
        ChamadoRepository db = new ChamadoRepository();

        [Authorize(Roles = "Cliente")]
        // GET: dbChamado
        public ActionResult Index()
        {
            return View(db.ObterTodos());
        }


        /// <summary>
        /// Pega os chamados que esta responsavel pelo atendimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Funcionario")]
        public ActionResult IndexChamados(string id)
        {
            if(User.Identity.Name == "adm@email.com") //Se for o administrador do sistema visualiza todos os chamados em aberto, se não pega chamados especificos de cada funcionario logado
            {
                return View(db.ObterTodos());
            }
            else return View(db.ObterChamadosExpecificos(id)); 
           
        }

        // GET: dbChamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.ObterPorId(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        [Authorize(Roles ="Cliente")]
        // GET: dbChamado/Details/5
        public ActionResult DetailsAcomp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.ObterPorId(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            ClienteRepository cliente = new ClienteRepository();
            FuncionarioRepository funcionario = new FuncionarioRepository();
            var client = cliente.ObterPorId(chamado.idCliente);
            var func = funcionario.ObterPorId(chamado.idFuncionario);
            ViewBag.NomeCli = client.nome;
            ViewBag.NomeFunc = func.nome;

            return View(chamado);
        }

        [Authorize(Roles = "Cliente")]
        // GET: dbChamado/Create
        public ActionResult Create()
        {
            DropDownList();
            return View();
        }

        // POST: dbChamado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Cliente")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChamadoViewModel chamado, string area)
        {
            try
            {
                CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);
                if(response.Success)
                {
                    DropDownList();

                    Chamado solicitacao = new Chamado();
                    FuncionarioRepository funcresponsavel = new FuncionarioRepository();

                    solicitacao.idFuncionario = funcresponsavel.SolicitacaoDeChamado(area); //Busca o Funcionario responsavel pelo chamado
                    solicitacao.dataDeSolicitacao = DateTime.Now;
                    solicitacao.descricao = chamado.descricao;
                    solicitacao.idCliente = User.Identity.GetUserId(); //Pega id no Cliente Logado no sistema
                    var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
                    if (chamado.ImageUpload == null || chamado.ImageUpload.ContentLength == 0)
                    {
                        ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
                    }
                    else if (!imageTypes.Contains(chamado.ImageUpload.ContentType))
                    {
                        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
                    }


                    if (solicitacao.idCliente != null) //Verifica se tem alguma pessoa logada no Sistema
                    {
                        if (ModelState.IsValid) // Verifica as informações do campo 
                        {

                            var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                            var extensao = System.IO.Path.GetExtension(chamado.ImageUpload.FileName).ToLower();
                            using (var img = System.Drawing.Image.FromStream(chamado.ImageUpload.InputStream))
                            {
                                solicitacao.Imagem = String.Format("/imgs/{0}{1}", imagemNome, extensao);
                                SalvarNaPasta(img, solicitacao.Imagem);
                            }
                            db.Salvar(solicitacao);
                            var func = funcresponsavel.ObterPorId(solicitacao.idFuncionario); //Busca para ver qual nome do funcionario responsavel pelo chamado
                            func.quantidadeChamados += 1;
                            funcresponsavel.Atualizar(func); //Atualiza a quantidade de chamados existentes                        
                            return RedirectToAction("Index", "Home").Mensagem("Funcionário responsável pelo chamado " + func.nome + ".");
                        }

                        return View(chamado);

                    }
                    else return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.ErroCaptcha = "Verifique o Google reCaptcha !";
                    return View();

                }

                

            }
            catch (Exception)
            {
                return RedirectToAction("Create").Mensagem("Área de atuação sem funcionários disponiveis");
            }
            

        }

        /// <summary>
        /// Metodo para verificar reCaptcha se esta valido
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());

        }

        // GET: dbChamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.ObterPorId(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: dbChamado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,dataDeSolicitacao")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Atualizar(chamado);
                return RedirectToAction("Index");
            }
            return View(chamado);
        }

        // GET: dbChamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.ObterPorId(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: dbChamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remover(id);          
            return RedirectToAction("Index","Home").Mensagem("Chamado finalizado com sucesso");
        }

        /// <summary>
        /// Preenche DropDownList de Area de Atuação
        /// </summary>
        public void DropDownList()
        {
            AreaDeAtuacaoRepository areas = new AreaDeAtuacaoRepository();
            List<string> viewchamados = new List<string>();

            foreach (var item in areas.ObterTodos())
            {
                viewchamados.Add(item.nome);
            }

            ViewBag.Areas = new SelectList(viewchamados);
        }

        private void SalvarNaPasta(Image img, string caminho)
        {
            using (System.Drawing.Image novaImagem = new Bitmap(img))
            {
                novaImagem.Save(Server.MapPath(caminho), img.RawFormat);
            }
        }
    }
}
