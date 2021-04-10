 var password = getElementById('password').innerHTML;
 var confirmPass = getElementById('passwordCheck').innerHTML;

 function login() {
  var url = "https://d4344ea68526.ngrok.io/api/Login?";
  var xhr = new XMLHttpRequest();
  var email = document.getElemenyById("login");
  var password = document.getElementById("password");
  xhr.withCredentials = true;
  
  xhr.addEventListener("readystatechange", function() {
    if(this.readyState === 4) {
      console.log(this.responseText);
    }
  });
  
  xhr.open("POST", url + "email=" + email + "&password=" + password);
  
  xhr.send();

 }
function register() {
  var x = document.getElementById("loginForm");
  var text = "";
  var email = x.elements[0].value;
  var pass = x.elements[1].value;
  var passCheck = x.elements[2].value;
  var isStudent = x.elements[3].value;
  var url = "https://d4344ea68526.ngrok.io/api/Login?";
  //Is the user a student or not
  if (isStudent.value == "Student") {
    isStudent = true;
  } else {
    isStudent = false;
  };
  //Generating the token
  var settings = {
    "url": url + "email=" + email + "&username=sojgdfjg&passHash=" + pass + "&isRegistration=false&isStudent=" + isStudent,
    "method": "POST",
    "timeout": 0,
  };
  // Set-cookie; jwtCookie = jsonToken;

  var xhr = new XMLHttpRequest();
  // xhr.withCredentials = true;

  xhr.addEventListener("readystatechange", function () {
    if (this.readyState === 4) {
      console.log(this.responseText);
      // this.responseText = jsonToken;
    }
  });

  xhr.open("POST", url + "email=" + email + "&username=sojgdfjg&passHash=" + pass + "&isRegistration=true&isStudent=" + isStudent);

  xhr.send();
  //STORE JWT IN BROWSER SESSION
  // Set-cookie("jwtCookie", settings.token, {
  //   httpOnly: true,
  //   sameSite: "strict",
  // });
};
//Checking Password against retype password


function validatePass() {
  if ((passwordCheck.value !== '') && (password.value !== passwordCheck.value)) {
    document.getElementById("error").innerHTML = "Passwords don't match";
  } else {
    document.getElementById("error").innerHTML = "";
  }
}
password.onchange = validatePass();
passwordCheck.onkeyup = validatePass();
