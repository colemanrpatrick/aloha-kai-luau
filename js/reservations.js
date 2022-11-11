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
  var packageObject;

  let participants = document.getElementById("participants");
//============================================================//
  function setscreen1(arg){
    packageObject = arg;
    var element = arg;
    console.log(arg);

    screen2.className = "";
    screen3.className = "";
    idToggle("screen-1","active");

    var templateTitle = "<header>" + element.title + "</header>";
    screenHeader[0].innerHTML += templateTitle;

    //-- ||||||||||| date picker ||||||||||||| --//
    var dateToday = new Date();
    // list of specific disabled dates //
    disabledDates = element.disabled_date;
    for (var i = 0; i < disabledDates.length; i++) {
      disabledDates[i] = disabledDates[i].replace(/\//g, '-');
    };
    $("#datepicker").datepicker({
      minDate: dateToday,// dates before current day disabled //
      beforeShowDay: function(date){ // disables dates based on disabledDates
      var disabledDatesString = jQuery.datepicker.formatDate('mm-dd-yy', date);
      return [ disabledDates.indexOf(disabledDatesString) == -1 ]
    }
    });

    $("#dateInput").attr("name","" + element.datepicker_id + "");

    if (localStorage.getItem("" + $('#dateInput').attr('name') + "")){
      $("#dateInput").prop('value',localStorage.getItem(element.datepicker_id)).trigger('change');
      $("#datepicker").datepicker('setDate',$("#dateInput").val());
    }else if(element.dateSelected !== "" && element.dateSelected !== " " ){
      var $date = element.dateSelected;
      $("#dateInput").prop('value',$date).trigger('change');
      $("#datepicker").datepicker('setDate',$date);
    }else{

    };
    $("#dateInput").change(function(){
      $("#datepicker").datepicker('setDate',$(this).val()).trigger('change');
    });

    $("#datepicker").change(function(){
      if ($("#dateInput").val() !== disabledDates) {

        $("#dateInput").prop('value',$(this).val());
        localStorage.setItem("" + $('#dateInput').attr('name') + "","" + $('#dateInput').val() + "");
        console.log(localStorage.getItem("" + $('#dateInput').attr('name') + ""));
      };
    });
    //-- ||||||||||| ======= ||||||||||||| --//
    screenFooter[0].innerHTML += '<button type="button" id="screen1btn" class="yellow-button">continue</button>';
    document.getElementById("screen1btn").addEventListener("click",function(){
      setscreen2(element);
    });

    return arg;
  };

//============================================================//
var numberPlus = document.getElementsByClassName("numberPlus"),
    numberMinus = document.getElementsByClassName("numberMinus"),
    numberInput;

// input values are not strings or numbers, they are input
  function numIncrement(numberInput, increase){

    var myInputObject = document.getElementById(numberInput);
    if (increase) {

      myInputObject.value++;

      localStorage.setItem("" + myInputObject.getAttribute("name") + "", "" + myInputObject.value + "");

    }else{

      myInputObject.value--;

      localStorage.setItem("" + myInputObject.getAttribute("name") + "", "" + myInputObject.value + "");

    };
    if (myInputObject.value > 999) {
      myInputObject.value = 999;
    };
    if(myInputObject.value <= 0){
      myInputObject.value = '';
    };
  };
//============================================================//
  function setscreen2(arg){
    packageObject = arg;
    let el = arg;
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

    adultPriceInput.setAttribute("name","" + el.adult_price_id + "");
    youthPriceInput.setAttribute("name","" + el.youth_price_id + "");
    childPriceInput.setAttribute("name","" + el.child_price_id + "");

    var $adultInputName = adultPriceInput.getAttribute("name");
    var $youthInputName = youthPriceInput.getAttribute("name");
    var $childInputName = childPriceInput.getAttribute("name");

    if(el.adult_price_quantity > 0 && el.adult_price_quantity !== 0 && !localStorage.getItem("" + $adultInputName + "")){
      adultPriceInput.value = el.adult_price_quantity;
    }else if(localStorage.getItem("" + $adultInputName + "") ){
      adultPriceInput.value = localStorage.getItem("" + $adultInputName + "");
    }else{
      adultPriceInput.value = '';
    };

    if(el.youth_price_quantity.length > 0 && el.youth_price_quantity !== 0 && !localStorage.getItem("" + $youthInputName + "")){
      youthPriceInput.value = el.youth_price_quantity;
    }else if(localStorage.getItem("" + $youthInputName + "") ){
      youthPriceInput.value = localStorage.getItem("" + $youthInputName + "");
    }else{
      youthPriceInput.value = '';
    };

    if(el.child_price_quantity  > 0 && el.child_price_quantity !== 0 && !localStorage.getItem("" + $childInputName + "")){
      childPriceInput.value = el.child_price_quantity;
    }else if(localStorage.getItem("" + $childInputName + "") ){
      childPriceInput.value = localStorage.getItem("" + $childInputName + "");
    }else{
      childPriceInput.value = '';
    };

    screenFooter[1].innerHTML += '<button type="button" id="screen2back" class="yellow-button">back</button>';
    screenFooter[1].innerHTML += '<button type="button" id="screen2btn" class="yellow-button">continue</button>';

    document.getElementById("screen2back").addEventListener("click",function(){
      setscreen1(el);
    });
    document.getElementById("screen2btn").addEventListener("click",function(){
      setscreen3(el);
    });
  };

  var termsCheck;
  var participantInput
//============================================================//
  function setscreen3(arg){
    packageObject = arg;
    screen1.className = "";
    screen2.className = "";
    idToggle("screen-3","active");
    var templateTitle = "<header>" + arg.title + "</header>";

    let participants = document.getElementById("participants");
    participantInput = document.createElement("input");
    participantInput.setAttribute("class","participant-input");
    participantInput.setAttribute("name",arg.participant_input_name);
    participants.appendChild(participantInput);

    if(arg.participantNamesAges.length > 0 && arg.participantNamesAges.length !== 0 && !localStorage.getItem("" + arg.participant_input_name + "")){

      participantInput.setAttribute("value",arg.participantNamesAges);
      participantInput.innerText = arg.participantNamesAges

    }else if(localStorage.getItem("" + arg.participant_input_name + "")){

      participantInput.value = localStorage.getItem("" + arg.participant_input_name + "");
      participantInput.innerText = localStorage.getItem("" + arg.participant_input_name + "");

    }else{

      participantInput.value = '';

    };

    screenHeader[2].innerHTML += templateTitle;
    screenFooter[2].innerHTML += '<button type="button" class="yellow-button" id="screen3back">back</a>';
    screenFooter[2].innerHTML += '<div id="terms-conditions">' + '<input type="checkbox" id="terms-check">' + '<p>by checking this I acknowledge I have read the <a href="privacy.html" target="_blank">privacy policy</a></p>' + '</div>'
    screenFooter[2].innerHTML += '<button type="button" class="yellow-button" id="checkout" disabled/>checkout</a>';

    document.getElementById("screen3back").addEventListener("click",function(){
      localStorage.setItem("" + arg.participant_input_name + "","" + participantInput.value + "");
      console.log(localStorage.getItem("" + arg.participant_input_name + ""));
      participants.innerHTML = "";
      setscreen2(arg);
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

//============================================================//
  function resetPurchaseUi(){



    console.log(localStorage.getItem(packageObject.participant_name));

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

    localStorage.setItem("" + packageObject.participant_input_name + "","" + participantInput.innerText + "");
    console.log(localStorage.getItem("" + packageObject.participant_input_name + ""));
    participants.innerHTML = "";
  };
//============================================================//
