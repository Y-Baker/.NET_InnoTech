namespace BlazorApp.Components;

public partial class CardPage
{
    List<CardData> data = new();
    const string defaultText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem...";
    protected override async Task OnInitializedAsync()
    {
        CardData cardData1 = new(title: "Card 1", linkRout: "home", linkText: "Go Home");
        data.Add(cardData1);
        CardData cardData2 = new(title: "Card 2", linkRout: "Counter", linkText: "Go To Counter");
        data.Add(cardData2);
        CardData cardData3 = new(title: "Card 3", linkRout: "weather", linkText: "Go To Weather");
        data.Add(cardData3);
        CardData cardData4 = new(title: "Card 4");
        data.Add(cardData4);
        CardData cardData5 = new(title: "Card 5", linkRout: "/", linkText: "Back to Home", descr: defaultText);
        data.Add(cardData5);

        await Task.CompletedTask;
    }
}
