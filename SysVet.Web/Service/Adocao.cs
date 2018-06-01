using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SysVet.Web.Models;

namespace SysVet.Web.Service
{
    public class Adocao
    {
        public IList<Pet> PetList { get; set; }
        public IList<Pessoa> PessoaList { get; set; }

        public Pet Pet { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}