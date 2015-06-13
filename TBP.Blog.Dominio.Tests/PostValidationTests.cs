﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Specification.Post;

namespace TBP.Blog.Dominio.Tests
{
    [TestClass]
    public class PostValidationTests
    {
        private readonly Post _post = new Post { Corpo = "Meu primeiro teste", DataPostagem = DateTime.Now, Titulo = "Meu primeiro teste", UserId = Guid.NewGuid().ToString() };

        [TestMethod]
        [TestCategory("Post - Apto para cadastro")]
        public void Post_esta_com_corpo_valido()
        {
            var kk = new PostComCorpoValido();
            Assert.IsTrue(kk.IsSatisfiedBy(_post));
        }

        [TestMethod]
        [TestCategory("Post - Apto para cadastro")]
        public void Post_esta_com_titulo_valido()
        {
            var kk = new PostComTituloValido();
            Assert.IsTrue(kk.IsSatisfiedBy(_post));
        }

        [TestMethod]
        [TestCategory("Post - Apto para cadastro")]
        public void Post_esta_com_dataPostagem_valida()
        {
            var kk = new PostComDataValida();
            Assert.IsTrue(kk.IsSatisfiedBy(_post));
        }

        [TestMethod]
        [TestCategory("Post - Apto para cadastro")]
        public void Post_esta_com_UserId_valido()
        {
            var kk = new PostComUsuarioValido();
            Assert.IsTrue(kk.IsSatisfiedBy(_post));
        }

        [TestMethod]
        [TestCategory("Post - Apto para cadastro")]
        public void Post_esta_Apto_para_cadastro()
        {
            Assert.IsTrue(_post.IsValid());
        }

    }
}
