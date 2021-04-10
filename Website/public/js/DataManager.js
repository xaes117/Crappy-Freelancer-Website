class DataManager {
    constructor() {
        this.baseUrl = "https://8445b6e1ad7e.ngrok.io";
    }

    send_request(requestOptions, query, callback) {
        fetch(this.baseUrl + query, requestOptions)
            .then(response => response.text())
            .then(function (response) {
                callback(response)
            })
            .catch(error => console.log('error', error));
    }

}

// Store
sessionStorage.setItem("jwt", "cCWG1VPbJru4vKBsrdAnOwoAuEtKSCBUMh07VT4jPUw=");

// Retrieve
// document.getElementById("result").innerHTML = sessionStorage.getItem("lastname");
