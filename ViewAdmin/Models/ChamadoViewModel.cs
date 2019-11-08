using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewAdmin.Models
{
    public class ChamadoViewModel
    {
        [Required]
        public string descricao { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageUpload { get; set; } //Inserir imagem no projeto web
    }
}