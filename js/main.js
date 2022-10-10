let slideIndex = 1;
showSlides(slideIndex);
// Next/previous controls
function plusSlides(n) {
  showSlides(slideIndex += n);
}
// Thumbnail image controls
function currentSlide(n) {
  showSlides(slideIndex = n);
}
function showSlides(n) {
  let i;
  let slides = document.getElementsByClassName("slide");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].className = "slide";
  }
  slides[slideIndex-1].className = "slide active";
}
// Initialize and add the map
function initMap() {
  // The location of Uluru
  const sealifepark = { lat: 21.3137242, lng: -157.6636201 };
  // The map, centered at Uluru
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 16,
    center: sealifepark,
    mapTypeId: 'hybrid'
  });
  // The marker, positioned at Uluru
  const marker = new google.maps.Marker({
    position: sealifepark,
    map: map,
  });
}

window.initMap = initMap;
