namespace Website.Pages.landing.Components;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Website.Localization;
using Website.Localization.Api;
using Website.Pages.landing.Dialogs;

public partial class ScreenshotCard
{
    [Parameter]
    public required string Title { get; set; }

    [Parameter]
    public required string ImageUrl { get; set; }

    [Parameter]
    public required string AltText { get; set; }

    [Inject]
    public required Localizer<SharedResource> Localizer { get; set; }

    [Inject]
    public required IDialogService DialogService { get; set; }

    private Task HandleShowImageModal()
    {
        return DialogService.ShowAsync<ImageDialog>(
            null,
            new DialogParameters<ImageDialog>
            {
                { x => x.Title, Title },
                { x => x.Image, ImageUrl },
                { x => x.AltText, AltText },
            },
            new DialogOptions()
            {
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
            }
        );
        // MudDialog.Show<Dialogs.ImageDialog>(Localizer["Asset Manager"], image, Localizer["Asset Manager"]);
    }
}
