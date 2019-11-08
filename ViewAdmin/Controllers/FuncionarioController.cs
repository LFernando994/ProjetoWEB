using CLRegras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class FuncionarioController : Controller
    {
        MDFuncionario model = new MDFuncionario();
        // GET: Funcionario
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {
            model.Carregar();
            return View(model.GetListarTodos());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            model.Carregar();
            return View(model.BuscarFuncPorID(id));
        }

        // GET: Funcionario/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            MDAreas modelAreas = new MDAreas();
            modelAreas.Carregar();
            DropDownList();        
            ViewBag.CategoriaId = new SelectList(modelAreas.GetListarTodos(), "id", "nome"); 
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult Create(CLRegras.Funcionario collection)
        {
            try
            {
                model.Carregar();
                collection.id = Convert.ToString(model.ContadorID());
                model.Adicionar(collection);
                model.Salvar();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id)
        {
            model.Carregar();
            return View(model.BuscarFuncPorID(id));
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id, CLRegras.Funcionario collection)
        {
            try
            {
                model.Carregar();
                Funcionario FuncionarioEdit = model.BuscarFuncPorID(id);
                FuncionarioEdit.nome = collection.nome;
                FuncionarioEdit.rg = collection.rg;
                FuncionarioEdit.sexo = collection.sexo;
                FuncionarioEdit.dataDeNascimento = collection.dataDeNascimento;               
                FuncionarioEdit.cpf = collection.cpf;
                FuncionarioEdit.grupoSanguineo = collection.grupoSanguineo;
                FuncionarioEdit.formacao = collection.formacao;
                FuncionarioEdit.grauDeEscolaridade = collection.grauDeEscolaridade;
                FuncionarioEdit.areaDeAtuacao = collection.areaDeAtuacao;
                FuncionarioEdit.quantidadeChamados = collection.quantidadeChamados;
                model.Salvar();
                model.Carregar();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id)
        {
            model.Carregar();           
            return View(model.BuscarFuncPorID(id));
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id, CLRegras.Funcionario collection)
        {
            try
            {
                model.Carregar();
                collection = model.BuscarFuncPorID(id);
                model.Remover(collection);
                model.Salvar();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Dropdown de funcionario
        /// </summary>
        public void DropDownList()
        {
            List<string> sexo = new List<string>();
            List<string> grauEscola = new List<string>();
            List<string> grupoSanguineio = new List<string>();

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

            ViewBag.grupoSanguineio = new SelectList(grupoSanguineio);
            ViewBag.grauEscola = new SelectList(grauEscola);
            ViewBag.Sexo = new SelectList(sexo);
        }
    }
}
