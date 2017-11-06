using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisMVC.Repositorio;
using AvisMVC.Models;

namespace AvisMVC.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterCliente()
        {
            _repositorio = new ClienteRepositorio();
            ModelState.Clear();
            return View(_repositorio.ObterCliente(0));
        }

        [HttpGet]
        public ActionResult IncluirTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncluirTime(Cliente clienteObj)
        {
           try
            {
                if(ModelState.IsValid )
                {
                    _repositorio = new ClienteRepositorio();
                    if (_repositorio.AdicionarCliente(clienteObj))
                    {
                        ViewBag.Mensagem = "Cliente Cadastrado com Sucesso.";
                    }
                }
                return RedirectToAction("ObterCliente");
            }
            catch(Exception)
            {
                return View("ObterCliente");
            }

         }

        [HttpGet]
        public ActionResult EditarTime( int id)
        {
            _repositorio = new ClienteRepositorio();
            return View(_repositorio.ObterCliente(0).Find(t => t.ClienteID == id));
        }

        [HttpPost]
        public ActionResult EditarTime(int id, Cliente clienteObj)
        {
            try
             {
                _repositorio = new ClienteRepositorio();
                _repositorio.AtualizarCliente(clienteObj);
                return RedirectToAction("ObterCliente");
             }
            catch
            {
                return View("ObterCliente");
            }
        }

        [HttpGet]
        public ActionResult ExcluirCliente(int id)
        {
            try
            {
                _repositorio = new ClienteRepositorio();

                if(_repositorio.ExcluirCliente(id))
                {
                    ViewBag.mensagem = "Cliente Excluido com Sucesso";

                }

                return RedirectToAction("ObterCliente");
            }
            catch
            {
                return View("ObterCliente");
            }
        }


    }
}