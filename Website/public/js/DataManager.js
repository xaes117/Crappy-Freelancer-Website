class DataManager {
    constructor() {
        this.baseUrl = "https://2c455c97dcd8.ngrok.io";
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
        let requestOptions = {
            method: 'POST',
            redirect: 'follow'
        };

        let query = `/api/Project?jwt=${encodeURIComponent(jwt)}&projectTitle=${projectTitle}&projectDescription=${projectDescription}`;

        this.send_request(requestOptions, query, function () {
            window.location = "profile.html";
        })
    }

}

// Store
sessionStorage.setItem("jwt", "zyRkwsTd+E6zZDMnrGEJYGnJh44yMdjXdJPl+fayy7E=");

// Retrieve
// document.getElementById("result").innerHTML = sessionStorage.getItem("lastname");
