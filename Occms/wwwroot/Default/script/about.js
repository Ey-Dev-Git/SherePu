

function reloadPage() {
    location.reload();
}

async function submit_form() {
    let name = document.getElementById("firstName").value;
    let subject = document.getElementById("subject").value;
    let email = document.getElementById("email").value;
    let text = document.getElementById("message").value;
    /*let file = document.getElementById("file").files[0];*/

    let api_email = 'https://localhost:44300/Email/SendEmail';

    let formData = new FormData();
    formData.append('SenderName', name);
    formData.append('Subject', subject);
    formData.append('SenderEmail', email);
    formData.append('Body', text);
    /*    formData.append('File', file);*/

    await fetch(api_email, {
        method: 'POST',
        body: formData
    })
        .then(responseData => {
            var modal = document.getElementById("successModal");
            var modalInstance = new bootstrap.Modal(modal);
            modalInstance.show();
            /*console.log("ส่งแล้ว")*/
            /*reloadPage()*/
        })
        .catch(error => {
            var modal = document.getElementById("errorModal");
            var modalInstance = new bootstrap.Modal(modal);
            modalInstance.show();
            /*console.log("ผิดพลาด")*/
        });
}



