class DataManager {
    constructor() {
        this.baseUrl = "https://458a9b6a0e9e.ngrok.io";
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
