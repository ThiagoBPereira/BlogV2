using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using TBP.Blog.Aplicacao.Interfaces;

namespace TBP.Blog.Servicos.WebApi.Controllers
{
    [RoutePrefix("api/comentarios")]
    public class ComentariosController : ApiController
    {
        private readonly IComentarioApp _icomentarioApp;

        public ComentariosController(IComentarioApp icomentarioApp)
        {
            _icomentarioApp = icomentarioApp;
        }

        // GET api/comentarios
        [Route("{idPost:guid}")]
        public IEnumerable<string> Get(Guid idPost)
        {
            var todas = _icomentarioApp.ListAllByPost(idPost).ToList().Select(JsonConvert.SerializeObject);

            return todas;
        }

        // GET api/comentarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/comentarios
        public void Post([FromBody]string value)
        {
        }

        // PUT api/comentarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comentarios/5
        public void Delete(int id)
        {
        }
    }
}
