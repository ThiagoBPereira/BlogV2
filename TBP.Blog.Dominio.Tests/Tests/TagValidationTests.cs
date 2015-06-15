using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Tests.Mock;
using TBP.Blog.Dominio.Validation.Tag;

namespace TBP.Blog.Dominio.Tests.Tests
{
    [TestClass]
    public class TagValidationTests
    {
        private readonly Tag _tag = new Tag { Nome = "Teste", IdTag = Guid.NewGuid(), UserId = "userTeste" };

        [TestMethod]
        [TestCategory("Tag - devidamente preenchida")]
        public void tag_devidamente_preenchida()
        {
            Assert.IsTrue(_tag.IsValid());
        }

        [TestMethod]
        [TestCategory("Tag - Apta para cadastro")]
        public void tag_Eh_Unica()
        {
            var repositorio = new TagRepositoryMock();
            var validacao = new TagAptaParaCadastroValidation(repositorio);
            var fiscal = validacao.Validar(_tag);

            Assert.IsFalse(fiscal.IsValid);
        }



    }
}
