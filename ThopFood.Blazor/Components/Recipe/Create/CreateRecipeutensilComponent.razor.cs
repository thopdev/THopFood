using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeUtensilComponent
    {
        [Inject]
        public IUtensilRepository UtensilRepository { get; set; }

        [Parameter] public EventCallback<Utensil> OnAdd { get; set; }

        public List<Utensil> SelectedUtensils { get; set; } = new();

        public List<Utensil> PossibleUtensils { get; set; }

        public MudAutocomplete<Utensil> AutoComplete { get; set; }
        public Utensil Utensil { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PossibleUtensils = await UtensilRepository.GetAllAsync();
        }

        public void OnSubmit()
        {
            if (Utensil is null) return;
            SelectedUtensils.Add(Utensil);
            OnAdd.InvokeAsync(Utensil);
            Utensil = new Utensil();
        }

        private Task<IEnumerable<Utensil>> Search(string value)
        {
            return Task.FromResult((string.IsNullOrEmpty(value) ?
                PossibleUtensils.Where(x => x.Name is not null) :
                PossibleUtensils.Where(x => x.Name is not null && x.Name.Contains(value)))
                .Where(x => !SelectedUtensils.Contains(x)).Distinct());
        }
    }
}