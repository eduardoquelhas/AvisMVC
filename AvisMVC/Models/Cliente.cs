using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvisMVC.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Obrigatorio Entrar com o Nome do Cliente") ]
        public string Nome { get; set; }

        [Display(Name = "Logradouro") ]
        [Required(ErrorMessage = "Obrigatório Logradouro")]        
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Obrigatorio Entrar com a CPF")]
        public string Cpf { get; set; }
        
    }
}