using Microsoft.AspNetCore.Components;
namespace PersonaFit.Core.Components
{
    public partial class AI : ComponentBase
    {
        private string? _text { get; set; } = "Welcome to PersonaFit!";

        public string? DisplayedText { get; set; } = string.Empty;

        public AI() { }

        protected override async Task OnInitializedAsync()
        {
            await TypeSpeechAsync(_text);
        }

        private async Task TypeSpeechAsync(string? text = null)
        {
            if (string.IsNullOrEmpty(text)) return;

            DisplayedText = string.Empty;

            foreach(var letter in text)
            {
                DisplayedText += letter;
                StateHasChanged();
                await Task.Delay(30);
            }
        }
    }
}