function ModalShow(id) {
    const modalElement = document.getElementById(id);
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
}
function ModalClose(id) {
    const modalElement = document.getElementById(id);
    const modal = bootstrap.Modal.getInstance(modalElement);
    if (modal) {
        modal.hide();
    }
}
function startCarousel(id) {
    var myCarousel = document.getElementById(id);
    var carousel = new bootstrap.Carousel(myCarousel);
    carousel.cycle();
}
