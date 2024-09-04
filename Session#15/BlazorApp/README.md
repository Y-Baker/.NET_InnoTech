## First Component: Accordion

![image](https://github.com/user-attachments/assets/9c2e2254-19eb-4d28-8f2f-148684a1f863)

* [sln](BlazorApp.sln)
* [razor](./Components/Accordion.razor)
* [src](./Components/Accordion.razor.cs)
* [js-Function](./wwwroot/js/app.js)
* [Implementation-in-Rout](./Pages/AccordionPage.razor)

---

<br />

### How To Use
- Use Accordion Component (Default)

![image](https://github.com/user-attachments/assets/593deb3c-bb14-4ef6-82ce-0e9d7f91ef88)

```razor
<Accordion />
```

- To Use Your Custom Data
```razor
<Accordion accordionData=@accordion1/>
```
- The Model Used To create data
```cs
public class AccordionData
{
    public string Id { get; set; }  // unique Id to get the correct element when use document.getElementById
    public List<AccordionItem> Items { get; set; } // Items in Accordion
    public bool AlwaysOpen { get; set; } // determine if accodion can open alot of items in same time

    public AccordionData(List<AccordionItem> items, bool alwaysOpen = false) 
    {
        this.Id = $"accordion-{Guid.NewGuid().ToString()}";
        this.Items = items;
        this.AlwaysOpen = alwaysOpen;
    }
}
```
---
```cs
public class AccordionItem
{
    public int Id { get; set; }  // Id for each item should be unique in same Accodion
    public string? Title { get; set; } // Head of the accordion item
    public string? Description { get; set; } // Body of the accordion item

    public AccordionItem(int id, string? title = null, string? description = null)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
    }
}
```
* example
```cs
List<AccordionItem> items = new()
{
    new AccordionItem(1, "Introduction", "Welcome to the first section of the accordion."),
    new AccordionItem(2, "Features", "<strong>Features:</strong> This section describes the features."),
    new AccordionItem(3, "Installation", "Instructions on how to install the application."),
    new AccordionItem(4, "Usage", "<em>Usage:</em> Details on how to use the application effectively."),
    new AccordionItem(5, "Support", "Information on how to get support and assistance.")
};
accordion1 = new(items, alwaysOpen: true);
```
* Json Example
```json
{
  "Id": "accordion-a1b2c3d4-e5f6-7890-ab12-cd34ef567890",
  "Items": [
    {
      "Id": 1,
      "Title": "Introduction",
      "Description": "Welcome to the first section of the accordion."
    },
    {
      "Id": 2,
      "Title": "Features",
      "Description": "<strong>Features:</strong> This section describes the features."
    },
    {
      "Id": 3,
      "Title": "Installation",
      "Description": "Instructions on how to install the application."
    },
    {
      "Id": 4,
      "Title": "Usage",
      "Description": "<em>Usage:</em> Details on how to use the application effectively."
    },
    {
      "Id": 5,
      "Title": "Support",
      "Description": "Information on how to get support and assistance."
    }
  ],
  "AlwaysOpen": true
}
```

<br />

#### Create new Instance for Accordion
```js
function startAccordion(accordionId) {
    const myaccordion = document.getElementById(accordionId);
    const accordionItems = myaccordion.querySelectorAll('.accordion-collapse');

    accordionItems.forEach(item => {
        new bootstrap.Collapse(item, {
            toggle: false
        });
    });
}
```

---

<br />

## Second Component: Card

![image](https://github.com/user-attachments/assets/2bbccfc1-a03a-4714-ab6e-98bf8d69ded9)

* [sln](BlazorApp.sln)
* [razor](./Components/Card.razor)
* [src](./Components/Card.razor.cs)
* [Implementation-in-Rout](./Pages/CardPage.razor)

---

<br />

### How To Use
- Use Card Component (Default)

![image](https://github.com/user-attachments/assets/ba06cf79-fea9-4085-bb69-7dcdf7ae4a8c)

```razor
<Card />
```
- To Use Your Custom Data
```razor
<Card cardData=@cardData />
```
- The Model Used To create data
```cs
public class CardData
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? LinkRout {  get; set; }  // the rout which used when button clicked
    public string? LinkText { get; set; }  // button text
    public string? ImgSrc { get; set; }   // Img Src Path or Url

    public CardData(string title, string? descr = null, string? linkRout = null, string? linkText = null, string? ImgSrc = null)
    {
        this.Id = $"card-{Guid.NewGuid().ToString()}";
        this.Title = title;
        this.Description = descr;
        this.LinkRout = linkRout;
        this.LinkText = linkText;
        this.ImgSrc = ImgSrc;
    }
}
```
- The Default Values For Card:
    - Description: "Some quick example text to build on the card title and make up the bulk of the card's content."
    - LinkRout: "javascript: void(0)"
    - LinkText: "Go somewhere"
    - ImgSrc: "img/default.jpg"

* example
```cs
const string defaultText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem...";
CardData cardData5 = new(title: "Card 5", linkRout: "/", linkText: "Back to Home", descr: defaultText, ImgSrc: "img/default.jpg");
```
* Json Example
```json
{
    "Id": "card-7e55003a-1d7c-4b3b-843d-2b7b832b2cc1",
    "Title": "Card 5",
    "Description": "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem...",
    "LinkRout": "/",
    "LinkText": "Back to Home",
    "ImgSrc": "img/default.jpg"
}
```

---


<br />

## Authors :black_nib:
* [__Repo__](https://github.com/Y-Baker/.NET_InnoTech)
* __Yousef Bakier__ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
 &nbsp;&nbsp;[<img height="" src="https://img.shields.io/static/v1?label=&message=GitHub&color=181717&logo=GitHub&logoColor=f2f2f2&labelColor=2F333A" alt="Github">](https://github.com/Y-Baker)
