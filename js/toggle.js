/*///////////////*/
/* toggle.js v.1.0
/*///////////////*/
console.log("toggle.js ready")
/*///////////////*/
//toggle events//
/*///////////////*/
//* ==== this toggle ===*//
function toggleThis(element, activeClass) {

  // console.log(element)

  var classArray = element.className.split(" ");

  var elementIndex = classArray.indexOf(activeClass);

  if (classArray.length >= 2){

    classArray.splice(elementIndex);

    element.className = classArray.join();

  }else{

    classArray.push(activeClass);

    element.className = classArray.join(" ");

  }
}
//*==== parent toggle ===*//
function parentToggle(thisElement,activeClass){

  var parentElement = thisElement.parentNode;

  toggleThis(parentElement, activeClass);
}
/*=== next sibling toggle ====*/
function nextSiblingToggle(element,activeClass){
  var thisElement = element.nextElementSibling;
  // console.log(nextElement.nextElementSibling)
  toggleThis(thisElement, activeClass);
}
/*=== previous sibling toggle ====*/
function prevSiblingToggle(prevElement,activeClass){
  var thisElement = prevElement.previousElementSibling;
  // console.log(nextElement.nextElementSibling)
  toggleThis(thisElement, activeClass);
}

/*=== id toggle ===*/
function idToggle(elementId,activeClass){

  var parentElement = document.getElementById(elementId);

  toggleThis(parentElement, activeClass);

}
/*=== tagname toggle ===*/

/*///////////////*/
/* toggle.js v.1.0
/*///////////////*/
console.log("toggle.js ready")
/*///////////////*/
//toggle events//
/*///////////////*/
//* ==== this toggle ===*//
function toggleThis(element, activeClass) {

  var classArray = element.className.split(" ");

  var elementIndex = classArray.indexOf(activeClass);

  if (classArray.length >= 2){

    classArray.splice(elementIndex);

    element.className = classArray.join();

  }else{

    classArray.push(activeClass);

    element.className = classArray.join(" ");

  }
}
/*=== id toggle ===*/
function idToggle(elementId,activeClass){

  var parentElement = document.getElementById(elementId);

  toggleThis(parentElement, activeClass);

}
//*==== parent toggle ===*//
function parentToggle(thisElement,activeClass){

  var parentElement = thisElement.parentNode;

  toggleThis(parentElement, activeClass);
}
/*=== next sibling toggle ====*/
function nextSiblingToggle(element,activeClass){
  var thisElement = element.nextElementSibling;

  toggleThis(thisElement, activeClass);
}
/*=== previous sibling toggle ====*/
function prevSiblingToggle(prevElement,activeClass){
  var thisElement = prevElement.previousElementSibling;

  toggleThis(thisElement, activeClass);
}
/*=== tagname toggle ===*/
function tagNameToggle(tagName,activeClass,tagNameIndex){

  var tagNameCollection = document.getElementsByTagName(tagName);

  for (var i = 0; i < tagNameCollection.length; i++) {
    var parentElement = tagNameCollection[tagNameIndex];
  }
  toggleThis(parentElement, activeClass);

}
/*== tabs toggle ==*/
function tabToggle(targetElement,element){
  console.log("clicked");
  // elIndex = number;
  var parentClass = targetElement.parentNode.className;
  console.log("targetElement");
  var el = document.getElementsByClassName(element);
  // Closes all
  for (var i = 0; i < el.length; i++) {
    el[i].className = element;
  }
  if (parentClass == element) {
     targetElement.parentNode.className = element + ' active';
  }
}
/*======*/
// var $eventListener = (function() {
//   'use strict';
//   if("ontouchstart" in document.documentElement === true){
//     return "touchstart"
//   }else{
//     return "click";
//   }
// }());
// // init
// (function() {
//   'use strict';
//   document.addEventListener($eventListener,function(){
//     outsideToggle(event,"tab");
//   });
// }());
// //
// function outsideToggle(event,elemClass){
//   var elem = document.getElementsByClassName(elemClass)
//   for (var i = 0; i < elem.length; i++) {
//     if(!elem[i].contains(event.target) && !$visible(elem)){
//       elem[i].className = elemClass;
//     }
//   }
// }
// const $visible = function(elem){
//   return !!elem && !!(elem.offsetWidth === 0 || elem.offsetHeight === 0) ;
// }
