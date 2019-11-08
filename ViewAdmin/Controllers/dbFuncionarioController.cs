using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLRegras;
using InfraWeb.Context;
using InfraWeb.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class dbFuncionarioController : Controller
    {
        FuncionarioRepository db = new FuncionarioRepository();

        // GET: dbFuncionario
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {
            return View(db.ObterTodos());
        }

        // GET: dbFuncionario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.ObterPorId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: dbFuncionario/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            DropDownList();
            return View();
        }

        // POST: dbFuncionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Create")]
        public ActionResult Create([Bind(Include = "id,formacao,grauDeEscolaridade,areaDeAtuacao,quantidadeChamados,nome,sexo,cpf,rg,dataDeNascimento,grupoSanguineo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Salvar(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        /// <summary>
        /// Chmadado do metodo para registrar no Controler Account para dividir cliente de funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreateRegister(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Salvar(funcionario);
            }
        }

        // GET: dbFuncionario/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.ObterPorId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: dbFuncionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit([Bind(Include = "id,formacao,grauDeEscolaridade,areaDeAtuacao,quantidadeChamados,nome,sexo,cpf,rg,dataDeNascimento,grupoSanguineo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Atualizar(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: dbFuncionario/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.ObterPorId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: dbFuncionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            db.Remover(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Adiciona as visualização de acordo o Perfil de usuario
        /// </summary>
        /// <param name="db"></param>
        public void AddPermissaoDeVisualizacao(ApplicationDbContext db, string perfil, string email)
        {
            PerfilUserRepository consultaPerfil = new PerfilUserRepository();
            var permissoes = consultaPerfil.ObterPorNome(perfil);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(email);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (permissoes.view.Equals(true))
            {
                userManager.AddToRole(user.Id, "View");
            }
            if (permissoes.edit.Equals(true))
            {
                userManager.AddToRole(user.Id, "Edit");
            }
            if (permissoes.create.Equals(true))
            {
                userManager.AddToRole(user.Id, "Create");
            }
            if (permissoes.delete.Equals(true))
            {
                userManager.AddToRole(user.Id, "Delete");
            }

        }

        /// <summary>
        /// Preenche a dropdown de Funcionario
        /// </summary>
        public void DropDownList()
        {
            AreaDeAtuacaoRepository getArea = new AreaDeAtuacaoRepository();
            PerfilUserRepository getPerfis = new PerfilUserRepository();
            List<string> sexo = new List<string>();
            List<string> grupoSanguineio = new List<string>();
            List<string> areaAtuacao = new List<string>();
            List<string> grauEscola = new List<string>();
            List<string> perfilUser = new List<string>();

            foreach (var item in getArea.ObterTodos())
            {
                areaAtuacao.Add(item.nome);
            }
            foreach (var item in getPerfis.ObterTodos())
            {
                perfilUser.Add(item.nome);
            }

            sexo.Add("M");
            sexo.Add("F");

            grauEscola.Add("Analfabeto");
            grauEscola.Add("Ensino fundamental incompleto");
            grauEscola.Add("Ensino fundamental completo");
            grauEscola.Add("Ensino médio incompleto");
            grauEscola.Add("Ensino médio completo");
            grauEscola.Add("Superior completo (ou graduação)");
            grauEscola.Add("Pós-graduação");
            grauEscola.Add("Mestrado");
            grauEscola.Add("Doutorado");
            grauEscola.Add("Pós-Doutorado");

            grupoSanguineio.Add("A+");
            grupoSanguineio.Add("A-");
            grupoSanguineio.Add("B+");
            grupoSanguineio.Add("B-");
            grupoSanguineio.Add("AB+");
            grupoSanguineio.Add("AB-");
            grupoSanguineio.Add("O+");
            grupoSanguineio.Add("O-");

            ///Adicionando na viewbag as listas
            ViewBag.grauEscola = new SelectList(grauEscola);
            ViewBag.areaAtuacao = new SelectList(areaAtuacao);
            ViewBag.grupoSanguineio = new SelectList(grupoSanguineio);
            ViewBag.sexo = new SelectList(sexo);
            ViewBag.perfil = new SelectList(perfilUser);
        }
    }
}
