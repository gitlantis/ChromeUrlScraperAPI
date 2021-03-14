'use strict';

let changeColor = document.getElementById('sendUrl');

changeColor.onclick = function (element) {
  chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
    var url = tabs[0].url;
    sendUrl(url);
  });
};

function sendUrl(url) {
    
  var xhttp = new XMLHttpRequest();  
  xhttp.open("POST", "https://localhost:44319/parser", true);

  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status === 200) {
      document.getElementById("content_json").innerHTML =
        this.responseText;     
    }
  };
  
  xhttp.setRequestHeader("Access-Control-Allow-Origin", "*");  
  xhttp.setRequestHeader("Content-Type", "application/json");
  xhttp.send('{ "UrlToParse": "'+url+'"}');

}