using Desafio01_aula10.DBContext;
using Desafio01_aula10.Models;
using Desafio01_aula10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio01_aula10.Dao
{
    public class CadastroAnimaisDAO
    {
        public static IEnumerable<AnimaisViewModel> ListarAnimais()
        {
            List<Cachorro> Cachorros = new List<Cachorro>();
            List<Gato> Gatos = new List<Gato>();

            List<AnimaisViewModel> ListaAnimais = new List<AnimaisViewModel>();

            using (var ctx = new CadastroAnimaisContext())
            {
                Cachorros = ctx.Cachorros.ToList();
                Gatos = ctx.Gatos.ToList();
         
                if(Cachorros.Count != 0)
                {
                    foreach (var c in Cachorros)
                    {
                        AnimaisViewModel avm = new AnimaisViewModel();

                        avm.Id = c.Id;
                        avm.nome = c.nome;
                        avm.idade = c.idade;
                        avm.raca = c.raca;
                        avm.porte = c.porte;
                        avm.TipoAnimal = "Cachorro";
                        avm.caracteristica = "Profissão: " + c.profissao;

                        ListaAnimais.Add(avm);
                    }
                }

                if (Gatos.Count != 0)
                {
                    foreach (var g in Gatos)
                    {
                        AnimaisViewModel avm = new AnimaisViewModel();

                        avm.Id = g.Id;
                        avm.nome = g.nome;
                        avm.idade = g.idade;
                        avm.raca = g.raca;
                        avm.porte = g.porte;
                        avm.TipoAnimal = "Gato";
                        avm.caracteristica = "Tipo de Miado: " + g.tipoDeMiado;

                        ListaAnimais.Add(avm);
                    }
                }

                return ListaAnimais;
            }
        }

        public static IEnumerable<AnimaisViewModel> ListarAnimais(int id, string nome, string tipo)
        {
            List<Cachorro> Cachorros = new List<Cachorro>();
            List<Gato> Gatos = new List<Gato>();

            List<AnimaisViewModel> ListaAnimais = new List<AnimaisViewModel>();
            AnimaisViewModel a;
            using (var ctx = new CadastroAnimaisContext())
            {
                dynamic animal = null;
                if (tipo.Equals("Cachorro"))
                {
                    animal = ctx.Cachorros.FirstOrDefault(p => p.nome.Equals(nome) && p.Id == id);
                    if (animal != null)
                    {
                        a = new AnimaisViewModel
                        {
                            Id = animal.Id,
                            nome = animal.nome,
                            idade = animal.idade,
                            raca = animal.raca,
                            porte = animal.porte,
                            TipoAnimal = "Cachorro",
                            caracteristica = "Profissão: " + animal.profissao
                        };
                        ListaAnimais.Add(a);
                    }
                }
                else
                {
                    animal = ctx.Gatos.FirstOrDefault(p => p.nome.Equals(nome) && p.Id == id);
                    if (animal != null)
                    {
                        a = new AnimaisViewModel
                        {
                            Id = animal.Id,
                            nome = animal.nome,
                            idade = animal.idade,
                            raca = animal.raca,
                            porte = animal.porte,
                            TipoAnimal = "Gato",
                            caracteristica = "Tipo de Miado: "+ animal.tipoDeMiado
                        };
                        ListaAnimais.Add(a);
                    }

                }
            }
            return ListaAnimais;
        }

        public static StatusCadastro IncluirAnimal(Cachorro cachorro)
        {
            using (var ctx = new CadastroAnimaisContext())
            {
                var animal = ctx.Cachorros.FirstOrDefault(p => p.nome.Equals(cachorro.nome));
                if (animal != null)
                {
                    return StatusCadastro.NOME_JA_CADASTRADO;
                }

                ctx.Cachorros.Add(cachorro);
                ctx.SaveChanges();

                return StatusCadastro.CADASTRO_OK;
            }
        }

        public static StatusCadastro UpdateAnimal(Cachorro cachorro, int idantigo, string nomeantigo)
        {
            using (var ctx = new CadastroAnimaisContext())
            {
                var animal = ctx.Cachorros.FirstOrDefault(p => p.nome.Equals(nomeantigo) && p.Id == idantigo);
                if (animal != null)
                {
                    animal.nome = cachorro.nome;
                    animal.idade = cachorro.idade;
                    animal.raca = cachorro.raca;
                    animal.porte = cachorro.porte;
                    animal.profissao = cachorro.profissao;

                    ctx.Cachorros.Add(cachorro);
                    ctx.SaveChanges();

                    return StatusCadastro.UPDATE_OK;
                }
                else
                {
                    return StatusCadastro.ANIMAL_NÃO_ENCONTRADO;
                }
            }
        }

        public static StatusCadastro IncluirAnimal(Gato gato)
        {
            using (var ctx = new CadastroAnimaisContext())
            {
                var animal = ctx.Gatos.FirstOrDefault(p => p.nome.Equals(gato.nome));
                if (animal != null)
                {
                    return StatusCadastro.NOME_JA_CADASTRADO;
                }

                ctx.Gatos.Add(gato);
                ctx.SaveChanges();

                return StatusCadastro.CADASTRO_OK;
            }
        }

        public static StatusCadastro UpdateAnimal(Gato gato, int idantigo, string nomeantigo)
        {
            using (var ctx = new CadastroAnimaisContext())
            {
                var animal = ctx.Gatos.FirstOrDefault(p => p.nome.Equals(nomeantigo) && p.Id == idantigo);
                if (animal != null)
                {
                    animal.nome = gato.nome;
                    animal.idade = gato.idade;
                    animal.raca = gato.raca;
                    animal.porte = gato.porte;
                    animal.tipoDeMiado = gato.tipoDeMiado;

                    ctx.Gatos.Add(gato);
                    ctx.SaveChanges();

                    return StatusCadastro.UPDATE_OK;
                }
                else
                {
                    return StatusCadastro.ANIMAL_NÃO_ENCONTRADO;
                }
            }
        }

        public static StatusCadastro DeleteAnimal(int Id, string nome, string tipo)
        {
            using (var ctx = new CadastroAnimaisContext())
            {
                if (tipo.Equals("Cachorro"))
                {
                    var animal = ctx.Cachorros.FirstOrDefault(p => p.nome.Equals(nome) && p.Id == Id);
                    if (animal == null)
                    {
                        return StatusCadastro.ANIMAL_NÃO_ENCONTRADO;
                    }

                    ctx.Cachorros.Remove(animal);
                    ctx.SaveChanges();
                    return StatusCadastro.DELETADO_OK;
                }
                else
                {
                    var animal = ctx.Gatos.FirstOrDefault(p => p.nome.Equals(nome) && p.Id == Id);
                    if (animal == null)
                    {
                        return StatusCadastro.ANIMAL_NÃO_ENCONTRADO;
                    }

                    ctx.Gatos.Remove(animal);
                    ctx.SaveChanges();
                    return StatusCadastro.DELETADO_OK;
                }              
            }
        }
    }
}