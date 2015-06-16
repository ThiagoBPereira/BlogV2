using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using TBP.Blog.Aplicacao.Interfaces;

namespace TBP.Blog.Servicos.WebApi.Controllers
{
    public class ComentariosController : ApiController
    {
        private readonly ITagApp _itagApp;

        public ComentariosController(ITagApp itagApp)
        {
            _itagApp = itagApp;
        }


        // GET api/comentarios
        public IEnumerable<string> Get()
        {
            var todas = _itagApp.ListAllByUser("thiagbpereira").ToList().Select(JsonConvert.SerializeObject);

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
