using EncyclopediaGalactica.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using UIWasm.Services;

namespace UIWasm.Components.Modules.Documents.RelationGrid;

public partial class EGRelationGrid
{
    [Inject]
    private ILogger<EGRelationGrid> Logger { get; set; }

    [Inject]
    private IRelationService RelationService { get; set; }

    private FluentDataGrid<RelationResult> Grid;
    private GridItemsProvider<RelationResult> GridItemsProvider;

    protected async override Task OnInitializedAsync()
    {
        GridItemsProvider = async request =>
        {
            ICollection<RelationResult> r = await RelationService.GetAllAsync().ConfigureAwait(false);
            return GridItemsProviderResult.From<RelationResult>(r, r.Count);
        };
    }
}
