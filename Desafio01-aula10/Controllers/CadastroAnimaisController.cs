using Desafio01_aula10.Dao;
using Desafio01_aula10.Models;
using Desafio01_aula10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Desafio01_aula10.Controllers
{
    public class CadastroAnimaisController : ApiController
    {
        [HttpGet]
        public IEnumerable<AnimaisViewModel> GetAnimais()
        {
            return CadastroAnimaisDAO.ListarAnimais();
        }

        [HttpGet]
        public IEnumerable<AnimaisViewModel> GetAnimais(int id, string nome, string tipo)
        {
            return CadastroAnimaisDAO.ListarAnimais(id, nome, tipo);
        }

        [HttpPost]
        public HttpResponseMessage PostAnimal ([FromBody] AnimaisViewModel animal)
        {
            if (animal.TipoAnimal.Equals("Cachorro"))
            {
                Cachorro cachorro = new Cachorro();

                cachorro.nome = animal.nome;
                cachorro.idade = animal.idade;
                cachorro.raca = animal.raca;
                cachorro.porte = animal.porte;
                cachorro.profissao = animal.caracteristica;

                StatusCadastro status = CadastroAnimaisDAO.IncluirAnimal(cachorro);
                if (status != StatusCadastro.CADASTRO_OK)
                {
                    string mensagem = "";

                    switch (status)
                    {
                        case StatusCadastro.NOME_JA_CADASTRADO:
                            mensagem = "Esse nome já está cadastrado";
                            break;
                    }

                    var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Erro no Servidor"),
                        ReasonPhrase = mensagem
                    };
                    throw new HttpResponseException(erro);

                }
                else
                {
                    var response = Request.CreateResponse<Cachorro>(HttpStatusCode.Created, cachorro);

                    string uri = Url.Link("DefaultApi", new { id = cachorro.Id });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
            }
            else
            {
                Gato gato = new Gato();

                gato.nome = animal.nome;
                gato.idade = animal.idade;
                gato.raca = animal.raca;
                gato.porte = animal.porte;
                gato.tipoDeMiado = animal.caracteristica;

                StatusCadastro status = CadastroAnimaisDAO.IncluirAnimal(gato);
                if (status != StatusCadastro.CADASTRO_OK)
                {
                    string mensagem = "";

                    switch (status)
                    {
                        case StatusCadastro.NOME_JA_CADASTRADO:
                            mensagem = "Esse nome já está cadastrado";
                            break;
                    }

                    var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Erro no Servidor"),
                        ReasonPhrase = mensagem
                    };
                    throw new HttpResponseException(erro);

                }
                else
                {
                    var response = Request.CreateResponse<Gato>(HttpStatusCode.Created, gato);

                    string uri = Url.Link("DefaultApi", new { id = gato.Id });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage PutAnimal([FromBody] AnimaisViewModelForPut animal)
        {
            if (animal.TipoAnimal.Equals("Cachorro"))
            {
                Cachorro cachorro = new Cachorro();

                cachorro.nome = animal.nome;
                cachorro.idade = animal.idade;
                cachorro.raca = animal.raca;
                cachorro.porte = animal.porte;
                cachorro.profissao = animal.caracteristica;

                StatusCadastro status = CadastroAnimaisDAO.UpdateAnimal(cachorro, animal.idantigo, animal.nomeantigo);
                if (status != StatusCadastro.UPDATE_OK)
                {
                    string mensagem = "";

                    switch (status)
                    {
                        case StatusCadastro.ANIMAL_NÃO_ENCONTRADO:
                            mensagem = "Animal não cadastrado";
                            break;
                    }

                    var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Erro no Servidor"),
                        ReasonPhrase = mensagem
                    };
                    throw new HttpResponseException(erro);

                }
                else
                {
                    var response = Request.CreateResponse<Cachorro>(HttpStatusCode.Created, cachorro);

                    string uri = Url.Link("DefaultApi", new { id = cachorro.Id });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
            }
            else
            {
                Gato gato = new Gato();

                gato.nome = animal.nome;
                gato.idade = animal.idade;
                gato.raca = animal.raca;
                gato.porte = animal.porte;
                gato.tipoDeMiado = animal.caracteristica;

                StatusCadastro status = CadastroAnimaisDAO.UpdateAnimal(gato, animal.idantigo, animal.nomeantigo);
                if (status != StatusCadastro.UPDATE_OK)
                {
                    string mensagem = "";

                    switch (status)
                    {
                        case StatusCadastro.ANIMAL_NÃO_ENCONTRADO:
                            mensagem = "Animal não cadastrado";
                            break;
                    }

                    var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Erro no Servidor"),
                        ReasonPhrase = mensagem
                    };
                    throw new HttpResponseException(erro);

                }
                else
                {
                    var response = Request.CreateResponse<Gato>(HttpStatusCode.Created, gato);

                    string uri = Url.Link("DefaultApi", new { id = gato.Id });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
            }


        }

        [HttpDelete]
        public HttpResponseMessage Delete(DeleteAnimal animal)
        {
            StatusCadastro status = CadastroAnimaisDAO.DeleteAnimal(animal.Id, animal.nome, animal.tipo);
            if (status != StatusCadastro.DELETADO_OK)
            {
                string mensagem = "";

                switch (status)
                {
                    case StatusCadastro.ANIMAL_NÃO_ENCONTRADO:
                        mensagem = "Animal não encontrado";
                        break;
                }

                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = mensagem
                };
                throw new HttpResponseException(erro);

            }
            else
            {
                var response = Request.CreateResponse<string>(HttpStatusCode.OK, animal.nome + " - "+ animal.tipo);

                string uri = Url.Link("DefaultApi", new { id = animal.Id, Nome = animal.nome, Tipo = animal.tipo });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }
    }
}