function startAccordion(accordionId) {
    const myaccordion = document.getElementById(accordionId);
    const accordionItems = myaccordion.querySelectorAll('.accordion-collapse');

    accordionItems.forEach(item => {
        new bootstrap.Collapse(item, {
            toggle: false
        });
    });
}