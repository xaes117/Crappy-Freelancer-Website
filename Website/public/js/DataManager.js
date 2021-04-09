class DataManager {
    constructor() {
        this.baseUrl = "https://1b07acfef63b.ngrok.io";
    }

    send_request(requestOptions, query, callback) {
        fetch(this.baseUrl + query, requestOptions)
            .then(response => response.text())
            .then(function (response) {
                console.log(response)
                callback(response)
            })
            .catch(error => console.log('error', error));
    }

}

// Store
sessionStorage.setItem("jwt", "cCWG1VPbJru4vKBsrdAnOwoAuEtKSCBUMh07VT4jPUw=");

// Retrieve
// document.getElementById("result").innerHTML = sessionStorage.getItem("lastname");
