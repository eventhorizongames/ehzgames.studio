namespace Website.Pages.landing;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Website.Pages.landing.Dialogs;

public partial class AvatarStudio
{
    [Inject]
    public required IDialogService DialogService { get; set; }

    public Task HandleShowImageModal(string title, string imageUrl, string altText)
    {
        return DialogService.ShowAsync<ImageDialog>(
            null,
            new DialogParameters<ImageDialog>
            {
                { x => x.Title, title },
                { x => x.Image, imageUrl },
                { x => x.AltText, altText },
            },
            new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large }
        );
    }
}
