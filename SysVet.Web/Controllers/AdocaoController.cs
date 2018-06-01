using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SysVet.Web.Data;
using SysVet.Web.Models;
using SysVet.Web.Service;

namespace SysVet.Web.Controllers
{
    public class AdocaoController : Controller
    {
        private SysvetContext db = new SysvetContext();
        private Adocao adocao = new Adocao();
        private string  petNome;
        private List<Pet> petList = new List<Pet>();
        

        // GET: Adocao
        public ActionResult Index()
        {
            var pessoa = db.Pessoa.ToList();
            ViewBag.PessoaList = new SelectList(pessoa, "Id", "Nome","Login","Senha","Flg_Ativo");

            var pet = db.Pet.ToList();
            ViewBag.PetList = new SelectList(pet, "Id", "Nome","Flg_Adotado","Id_pessoa","Dt_Adocao");

            return View();
        }

        public ActionResult Create()
        {
            var pessoa = db.Pessoa.ToList();
            ViewBag.Pessoa = new SelectList(pessoa, "Id", "Nome");

            var pet = db.Pet.ToList();
            ViewBag.Pet = new SelectList(pet, "Id", "Nome");
            petList = ViewBag.Pet.Items;

            return View();
        }

        public ActionResult GetAllPessoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        public ActionResult GetAllPet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pet = db.Pet.Where(x => x.Flg_Adotado == 0);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        public ActionResult Adotar(Adocao model)
        {
            if (ModelState.IsValid)
            {
                Pet pet = new Pet();

                pet.Id = model.Pet.Id;
                pet.Nome = "cachorro";
                pet.Tipo = "cachorro";
                pet.Idade = 1;
                pet.Id_Pessoa = model.Pessoa.Id;
                pet.Dt_Adocao = DateTime.Now;
                pet.Flg_Adotado = 1;
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}