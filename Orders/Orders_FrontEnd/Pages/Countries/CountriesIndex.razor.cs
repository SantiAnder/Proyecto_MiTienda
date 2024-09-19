using Microsoft.AspNetCore.Components;
using Orders_FrontEnd.Repositorios;
using Orders_Shared.Entities;

namespace Orders_FrontEnd.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repo { get; set; } = null!;
        public List<Country>? ListaDePaises { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var responseHttp = await Repo.GetAsync<List<Country>>("api/countries");
            ListaDePaises = responseHttp.Response;
        }

    }
}
