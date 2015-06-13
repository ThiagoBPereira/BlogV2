using System.Collections.Generic;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Aplicacao.Interfaces
{
    public interface ITagApp
    {
        IEnumerable<TagViewModel> ListAllByUser(string username);
        IEnumerable<TagViewModel> GetByName(string username, string nome);
    }
}