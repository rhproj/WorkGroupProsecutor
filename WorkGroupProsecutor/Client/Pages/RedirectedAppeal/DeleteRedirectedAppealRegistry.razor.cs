using Microsoft.AspNetCore.Components;
using WorkGroupProsecutor.Client.Services;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Pages.RedirectedAppeal
{
    public partial class DeleteRedirectedAppealRegistry
    {
        [Inject]
        public IRedirectedAppealDataService RedirectedAppealDataService { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string DistrictName { get; set; }

        private RedirectedAppealModelDTO appeal = new();

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                appeal = await RedirectedAppealDataService.GetRedirectedAppealById(Id);
            }
        }

        private async Task DeleteAppeal() //turns out we can't have method with PageName
        {
            if (appeal != null)
            {
                await RedirectedAppealDataService.DeleteRedirectedAppeal(Id); //httpClient.DeleteAsync($"api//{Id}");
                GotBack();
            }
        }

        private void GotBack()
        {
            navManager.NavigateTo($"/redirectedappealregistry/{DistrictName}/{appeal.PeriodInfo}/{appeal.YearInfo}");
        }
    }
}
