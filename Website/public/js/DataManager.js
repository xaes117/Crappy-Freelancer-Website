class DataManager {
    constructor() {
        this.baseUrl = "https://259506afa260.ngrok.io";

        this.postTemplate = {
            method: 'POST',
            redirect: 'follow'
        };

        this.getTemplate = {
            method: 'GET',
            redirect: 'follow'
        };
    }

    send_request(requestOptions, query, callback) {
        fetch(this.baseUrl + query, requestOptions)
            .then(response => response.text())
            .then(function (response) {
                callback(response)
            })
            .catch(error => console.log('error', error));
    }

    create_project(jwt, projectTitle, projectDescription) {
        let requestOptions = this.postTemplate
        let query = `/api/Project?jwt=${encodeURIComponent(jwt)}&projectTitle=${projectTitle}&projectDescription=${projectDescription}`;
        this.send_request(requestOptions, query, function () {
            window.location = "profile.html";
        })
    }

    create_user(email, username, password, isStudent) {
        let query = `/api/Login?email=${email}&username=${username}&passHash=${password}&isStudent=${isStudent}&isRegistration=true`
        this.send_request(this.postTemplate, query, function (response) {
            if (!response.includes("exception")) {
                sessionStorage.setItem('jwt', response.replace(/['"]+/g, ''))
                window.location = "home.html"
            }
        })
    }

    login_user(email, username, password) {
        let query = `/api/Login?email=${email}&username=${username}&passHash=${password}&isStudent=false&isRegistration=false`
        this.send_request(this.postTemplate, query, function (response) {
            if (!response.includes("exception")) {
                sessionStorage.setItem('jwt', response.replace(/['"]+/g, ''))
                window.location = "home.html"
            }
        })
    }
}

function loadPage(pageType, id) {
    if (pageType === 'projectPage') {
        sessionStorage.setItem('projectViewId', id)
        window.location.href = `viewProject.html`;
    }
}

function round(value, precision) {
    let multiplier = Math.pow(10, precision || 0);
    return Math.round(value * multiplier) / multiplier;
}

// Storehttps://2c455c97dcd8.ngrok.io/api/Project/1
sessionStorage.setItem("jwt", "zyRkwsTd+E6zZDMnrGEJYGnJh44yMdjXdJPl+fayy7E=");
