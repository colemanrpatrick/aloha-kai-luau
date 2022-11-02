console.log("reservations.js");

  let purchaseWindow = document.getElementById("purchase-window");

  let screen1 = document.getElementById("screen-1");
  let screen2 = document.getElementById("screen-2");
  let screen3 = document.getElementById("screen-3");

  let screenHeader = document.getElementsByClassName("screen-header");
  let screenFooter = document.getElementsByClassName("screen-footer");

  let adultPrice = document.getElementById("adult-price");
  let youthPrice = document.getElementById("youth-price");
  let childPrice = document.getElementById("child-price");

  let datePicker = document.getElementById("dateInput");

  var el;
  var element;

  var adultPriceInput = document.getElementById("package-number-input1");
  var youthPriceInput = document.getElementById("package-number-input2");
  var childPriceInput = document.getElementById("package-number-input3");

//============================================================//
  function resetPurchaseUi(){

    idToggle("purchase-window","active");

    screen1.className = "";
    screen2.className = "";
    screen3.className = "";

    datePicker.setAttribute("name","");

    adultPrice.innerHTML = "";
    youthPrice.innerHTML = "";
    childPrice.innerHTML = "";

    adultPriceInput.setAttribute("name","");
    youthPriceInput.setAttribute("name","");
    childPriceInput.setAttribute("name","");

    for (var i = 0; i < screenHeader.length; i++) {
      screenHeader[i].innerHTML = "";
    };
    for (var i = 0; i < screenFooter.length; i++) {
      screenFooter[i].innerHTML = "";
    };
    var numberSpinner = document.getElementsByClassName("numberSpinnerInput");
    for (var i = 0; i < numberSpinner.length; i++) {
      numberSpinner[i].value = "";
    };
    $("#dateInput").attr('value','');
    $("#datepicker").datepicker( "destroy" );

  };
//============================================================//

//============================================================//
  function setscreen1(el){

    screen2.className = "";
    screen3.className = "";
    idToggle("screen-1","active");

    let element = el;

    var templateTitle = "<header>" + element.title + "</header>";
    screenHeader[0].innerHTML += templateTitle;

    //-- ||||||||||| date picker ||||||||||||| --//
    var dateToday = new Date();
    // list of specific disabled dates //
    disabledDates = el.disabled_date;
    for (var i = 0; i < disabledDates.length; i++) {
      disabledDates[i] = disabledDates[i].replace(/\//g, '-');
    }
    $("#datepicker").datepicker({
      minDate: dateToday,// dates before current day disabled //
      beforeShowDay: function(date){ // disables dates based on disabledDates
      var disabledDatesString = jQuery.datepicker.formatDate('mm-dd-yy', date);
      return [ disabledDates.indexOf(disabledDatesString) == -1 ]
    }
    });

    $("#dateInput").change(function(){
      $("#datepicker").datepicker('setDate',$(this).val());
    });
    $("#datepicker").change(function(){
      if ($("dateInput").val() !== disabledDates) {
        $("#dateInput").attr('value',$(this).val());
        console.log(disabledDates);
      };
    });
    //-- ||||||||||| ======= ||||||||||||| --//

    datePicker.setAttribute("name","" + element.datepicker_id + "");

    screenFooter[0].innerHTML += '<button type="button" id="screen1btn" class="yellow-button">continue</button>';

    document.getElementById("screen1btn").addEventListener("click",function(){
      setscreen2(element);
    });
  };
//============================================================//
  function setscreen2(el){
    screen1.className = "";
    screen3.className = "";
    idToggle("screen-2","active");
    for (var i = 0; i < screenHeader.length; i++) {
      screenHeader[i].innerHTML = "";
    };
    for (var i = 0; i < screenFooter.length; i++) {
      screenFooter[i].innerHTML = "";
    };
    screenHeader[1].innerHTML += "<header>" + el.title + "</header>";
    adultPrice.innerHTML = "<span>" + el.adult_price + "</span>";
    youthPrice.innerHTML = "<span>" + el.youth_price + "</span>";
    childPrice.innerHTML = "<span>" + el.child_price + "</span>";

    console.log(adultPriceInput);

    adultPriceInput.setAttribute("name","" + el.adult_price_id + "");
    youthPriceInput.setAttribute("name","" + el.youth_price_id + "");
    childPriceInput.setAttribute("name","" + el.child_price_id + "");

    screenFooter[1].innerHTML += '<button type="button" id="screen2back" class="yellow-button">back</button>';
    screenFooter[1].innerHTML += '<button type="button" id="screen2btn" class="yellow-button">continue</button>';

    document.getElementById("screen2back").addEventListener("click",function(){
      setscreen1(el);
    });
    document.getElementById("screen2btn").addEventListener("click",function(){
      setscreen3(el);
    });
  };
  //
  var termsCheck;
//============================================================//
  function setscreen3(element){

    screen1.className = "";
    screen2.className = "";
    idToggle("screen-3","active");

    let el = element;
    var templateTitle = "<header>" + el.title + "</header>";

    screenHeader[2].innerHTML += templateTitle;
    screenFooter[2].innerHTML += '<button type="button" class="yellow-button" id="screen3back">back</a>';
    screenFooter[2].innerHTML += '<div id="terms-conditions">' + '<input type="checkbox" id="terms-check">' + '<p>by checking this I acknowledge I have read the <a href="privacy.html" target="_blank">privacy policy</a></p>' + '</div>'
    screenFooter[2].innerHTML += '<button type="button" class="yellow-button" id="checkout" disabled/>checkout</a>';
    document.getElementById("screen3back").addEventListener("click",function(){
      setscreen2(el);
    });
    var $checkout = document.getElementById("checkout");
    document.getElementById("terms-check").addEventListener("change",function(){
      if(this.checked){
        $checkout.disabled = false;
      }else{
        $checkout.disabled = true;
      }
    })
    $checkout.addEventListener("click",function(){
       alert("checkout function goes here!");
    });
  };
//============================================================//
var numberPlus = document.getElementsByClassName("numberPlus"),
    numberMinus = document.getElementsByClassName("numberMinus"),
    numberInput;
// input values are not strings or numbers, they are input
function numIncrement(numberInput, increase){

  var myInputObject = document.getElementById(numberInput);
  if (increase) {
    console.log("increased value", myInputObject.value);
    myInputObject.value++;
  } else {
    console.log("decreased value", myInputObject.value);
    myInputObject.value--;
  }
  if (myInputObject.value > 999) {
    myInputObject.value = 999;
  }
  if(myInputObject.value <= 0){
    myInputObject.value = '';
  }
};
//-- ===================================================== --//
//-- ||||||||||||||||||||||||||||||||||||||||||||||||||||| --//
//-- ||||||||||| A.3 participants script ||||||||||||||||| --//
//-- ||||||||||||||||||||||||||||||||||||||||||||||||||||| --//
//-- ================================= ============ ====== --//

var container = document.getElementById("participants"),
  participant = document.getElementsByClassName("participant"),
  carrier = document.getElementById("carrierInput");

var participantsValue,
  participantsArr,
  num;

function getParticipants() {

'use strict';
var carrier_value = localStorage.getItem("carrierValue");
// console.log("getValue",carrier_value)
participantsValue = carrier_value;

};

function showParticipants(){
getParticipants();
var count;
if(participantsValue !== null){

  container.innerHTML = "";
  participants = participantsValue.split(",");
  participantsArr = [];

  participants.forEach(function(item,index){
    var newItem = item.split('|');
    participantsArr.push(newItem);
    createParticipant();
  })

  var nameInput = document.querySelectorAll(".input-name");
  var ageInput = document.querySelectorAll(".input-age");

  for (var i = 0; i < nameInput.length; i++) {
    nameInput[i].value = "" + participantsArr[i][0] + "";
    ageInput[i].value = "" + participantsArr[i][1] + "";
  }

}else{
  createParticipant();
}
}
function removeParticipant(){
console.log("clicked");
console.log(participantsArr);

var thisClassName = this.className;

var classOfThis = document.getElementsByClassName(thisClassName);

for (var i = 0; i < classOfThis.length; i++) {
  console.log(classOfThis.length,participantsArr[i]);
}

}

var newParticipant;

function createParticipant(){
newParticipant = document.createElement('div');
newParticipant.setAttribute("class","participant");
var inputText = ["name","age"];
inputText.forEach(function(el){
  var labels = document.createElement('label');
  labels.htmlFor = el;
  labels.innerHTML = el;
  newParticipant.appendChild(labels);
})
inputText.forEach(function(el){
  var inputs = document.createElement('input');
  inputs.type = 'text';
  inputs.setAttribute("class","input-" + el +"");
  newParticipant.appendChild(inputs);
})
var removeBtn = document.createElement('button');
removeBtn.type = 'button';
removeBtn.setAttribute("class","removeBtn");
removeBtn.innerHTML = '<span class="material-symbols-outlined">close</span>';
removeBtn.addEventListener('click',removeParticipant,false);
newParticipant.appendChild(removeBtn);
container.appendChild(newParticipant);
}
function addParticipant(){
container.appendChild(newParticipant);
}
function storeParticipants() {

getParticipants();
var participantStr;
var participantArr = [];
var collectionArr = [];
for (var i = 0; i < participant.length; i++) {
  var participantName = participant[i].querySelectorAll(".input-name")[0].value;
  var participantAge = participant[i].querySelectorAll(".input-age")[0].value;
  participantStr = participantName +"|"+ participantAge;
  participantArr.push(participantStr);
}
for (var i = 0; i < participantArr.length; i++) {
  collectionArr.push(participantArr[i]);
}
carrier.value = collectionArr;
localStorage.setItem("carrierValue", carrier.value);
carrier.value = "";
location.reload();
}
function setParticipants(){
}
//
(function() {
'use strict';
showParticipants();
}());
//-- ================================= --//
//-- ||||||||||||||||||||||||||||||||| --//
//-- ||||||||||||||||||||||||||||||||| --//
//-- ================================= --//
function addParticipant(){
var x = document.getElementById("participants");
var participant = document.getElementsByClassName("participant");
for (var i = 0; i < participant.length; i++) {
    var markup = participant[i].innerHTML;
}
var newParticipant = document.createElement('div');
newParticipant.setAttribute("class","participant");
newParticipant.innerHTML = markup;
x.appendChild(newParticipant);
}
