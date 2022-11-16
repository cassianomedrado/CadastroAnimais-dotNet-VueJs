using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio01_aula10.Models
{
        public enum StatusCadastro
        {
            CADASTRO_OK,
            NOME_JA_CADASTRADO,
            ANIMAL_NÃO_ENCONTRADO,
            DELETADO_OK, 
            UPDATE_OK
        }
}