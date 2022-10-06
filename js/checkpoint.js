// var documentHeight = document.documentElement.scrollTop || window.scrollY || window.pageYOffset || document.body.scrollTop;



var checkpointFirst = document.getElementById("checkpoint-first");

var checkpoint = document.getElementsByClassName("checkpoint");

window.onload = function () {

  checkpointFirst.classList = "checkpoint-first active";

}

window.onscroll = function(){
  /*=== use first checkpoint if at the very top of the page ===*/

  var checkpointFirstBottom = checkpointFirst.clientHeight;

  if (window.scrollY < checkpointFirstBottom) {

    checkpointFirst.classList = "checkpoint-first active";

  }else{

    checkpointFirst.classList = "checkpoint-first";

  }
  /*=== ===*/
  for (var i = 0; i < checkpoint.length; i++) {

    var checkpointHeight = checkpoint[i].offsetTop - (checkpoint[i].clientHeight);

    var checkpointBottom = checkpoint[i].offsetTop + (checkpoint[i].clientHeight / 2);

    if (window.scrollY > checkpointHeight && window.scrollY < checkpointBottom) {

      checkpoint[i].classList = "checkpoint active";

    }else{

      checkpoint[i].classList = "checkpoint";

    }

  }
}
