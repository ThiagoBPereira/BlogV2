using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Apresentacao.Mvc
{
    public static class Helpers
    {
        public static MvcHtmlString EditorForTagEnum<TModel, TValue>(this HtmlHelper<TModel> helper
            , Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var propertyName = data.PropertyName;
            var textBox = new TagBuilder("input");

            textBox.Attributes.Add("name", propertyName);
            textBox.Attributes.Add("id", propertyName);

            var tagsList = (data.Model ?? new List<TagViewModel>()) as List<TagViewModel>;

            if (tagsList != null && tagsList.Any())
            {
                var valor = tagsList
                    .Select(i => i.Nome)
                    .Aggregate((x, y) => x + ", " + y);

                textBox.Attributes.Add("value", valor);
            }

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                textBox.MergeAttributes(attributes);
            }

            return new MvcHtmlString(textBox.ToString());
        }


        public static MvcHtmlString SpanFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var displayName = data.DisplayName;

            var span = new TagBuilder("span");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            span.MergeAttributes(attributes);

            if (displayName != null)
            {
                span.SetInnerText(displayName);
            }

            return MvcHtmlString.Create(span.ToString());
        }


        public static MvcHtmlString DataTitulo<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var datas = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var data = (DateTime?)datas.Model ?? DateTime.Now;

            //Criando controle
            var divData = new TagBuilder("div");
            divData.Attributes.Add("class", "date");

            //Criando Dia
            var dia = new TagBuilder("span");
            dia.Attributes.Add("class", "day");
            dia.SetInnerText(data.ToString("dd"));
            divData.InnerHtml += dia;

            //Criando Div dateHolder
            var divDateHolder = new TagBuilder("div");
            divDateHolder.Attributes.Add("class", "dateHolder");

            //Criando Mes
            var mes = new TagBuilder("span");
            mes.Attributes.Add("class", "month");
            mes.SetInnerText(data.ToString("MMM"));
            divDateHolder.InnerHtml += mes;

            //Criando Ano
            var ano = new TagBuilder("span");
            ano.Attributes.Add("class", "year");
            ano.SetInnerText(data.Year.ToString());
            divDateHolder.InnerHtml += ano;

            divData.InnerHtml += divDateHolder;

            return MvcHtmlString.Create(divData.ToString());
        }
    }

}