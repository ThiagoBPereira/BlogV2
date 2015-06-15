using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Apresentacao.Mvc
{
    public class TagsEnumModelBinder : DefaultModelBinder
    {
        //Fazer a transformação do TextBox para uma listagem de TagViewModel
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(IEnumerable<TagViewModel>))
                return base.BindModel(controllerContext, bindingContext);

            var ahaha = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            // Pegar o valor do textbox;
            var valorDoTextBox = ((string[])ahaha.RawValue)[0];

            //Separar o valor de acordo com o separador
            var valorSplitado = valorDoTextBox.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            //Criar nova instancia doobjeto
            var instance = new List<TagViewModel>();
            var user = controllerContext.RequestContext.HttpContext.User.Identity.GetUserName();
            //Arrumar uma maneira de inserir o Id por Aqui
            instance.AddRange(valorSplitado.Select(tag => new TagViewModel { Nome = tag, UserId = user }));

            return instance;
        }
    }
}
