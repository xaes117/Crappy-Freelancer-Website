function login1() {

    let dataManager = new DataManager();

    let email = document.getElementById("login-email").value;
    let username = document.getElementById("login-username").value;
    let password = document.getElementById("login-password").value;

    dataManager.login_user(email, username, password)

}

function register() {

    let dataManager = new DataManager();

    let email = document.getElementById('register-email').value
    let username = document.getElementById('register-username').value
    let pass = document.getElementById('register-password').value
    let passCheck = document.getElementById('passwordCheck').value
    let isStudent = document.getElementById('register-select').value

    //Is the user a student or not
    isStudent = isStudent.value === "Student";

    if (pass !== passCheck) {
        document.getElementById("error").innerHTML = "Passwords don't match";
    } else {
        dataManager.create_user(email, username, pass, isStudent)
    }
}