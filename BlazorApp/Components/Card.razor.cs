using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components;

public partial class Card
{
    [Parameter] public CardData? cardData { get; set; }

    internal string? cardId;
    internal string? cardTitle;
    internal string? cardDescription;
    internal string? cardLinkRout;
    internal string? cardLinkText;
    internal string? cardImgSrc;

    protected override void OnParametersSet()
    {
        if (cardData != null)
        {
            cardId = cardData.Id;
            cardTitle = cardData.Title;
            cardDescription = string.IsNullOrEmpty(cardData.Description)
                ? "Some quick example text to build on the card title and make up the bulk of the card's content."
                : cardData.Description;
            cardLinkRout = cardData.LinkRout ?? "javascript: void(0)";
            cardLinkText = cardData.LinkText ?? "Go somewhere";
            cardImgSrc = cardData.ImgSrc ?? "img/default.jpg";
        }
        else
        {
            cardId = $"card-{Guid.NewGuid().ToString()}";
            cardTitle = "One Day";
            cardDescription = "Some quick example text to build on the card title and make up the bulk of the card's content.";
            cardLinkRout = "javascript: void(0)";
            cardLinkText = "Go somewhere";
            cardImgSrc = "img/default.jpg";
        }
    }
}