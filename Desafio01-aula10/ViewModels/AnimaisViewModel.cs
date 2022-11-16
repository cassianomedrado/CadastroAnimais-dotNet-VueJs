using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio01_aula10.ViewModels
{
    public class AnimaisViewModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string raca { get; set; }
        public string porte { get; set; }
        public string TipoAnimal { get; set; }
        public string caracteristica { get; set; }
    }
}