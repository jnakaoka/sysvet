using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysVet.Web.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Idade { get; set; }
        public int Flg_Adotado { get; set; }
        public int? Id_Pessoa { get; set; }
        public DateTime? Dt_Adocao { get; set; }

    }
}