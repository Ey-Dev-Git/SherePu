//let rest = new XMLHttpRequest();
//rest.open('GET', 'https://localhost:44300/LocationRest/AllLocationRest');
//rest.onload = function () {
//    if (rest.status === 200) {
//        const rests = JSON.parse(rest.responseText);
//        let cardHTML = '';
//        for (let i = 0; i < rests.length; i++) {
//            const locationrest = rests[i];
//            cardHTML += `<div class="col-lg-4 mx-auto d-flex justify-content-center">
//                        <div class="">
//                            <img src="${locationrest.locationRestPicture}" width="424" height="447" class="card-img-top" alt="rest">
//                            <div class="card-body text-center">
//                                <h5 class="card-title">${locationrest.locationRestName}</h5>
//                            </div>
//                        </div>
//                    </div>`;
//        }
//        document.getElementById('card-container').innerHTML = cardHTML;
//    } else {
//        console.log('เกิดข้อผิดพลาดในการดึงข้อมูล');
//    }
//};
//rest.send();




///*https://localhost:44300/Hostel/FindHostelByID/1*/
///*https://localhost:44300/Hostel/AllHostel*/


//function rest1() {
//    fetch('https://localhost:44300/Hostel/FindHostelByID/1')
//        .then(response => response.json())
//        .then(data => {

//            document.getElementById('hostel_name').innerHTML += data.hostelName;

//            document.getElementById('pichostel').src = data.hostelPicture;
//            document.getElementById('picroom').src = data.hostelRoomPicture;

//            document.getElementById('hostel_details').innerHTML += "ชื่อบ้านพัก : " + data.hostelNameDetail + "<br />" +
//                "โซน : " + data.hostelZone + "<br />" +
//                "สิ่งอำนวยความสะดวก : " + data.hostelFacilities + "<br />" +
//                "จำนวนคน : " + data.hostelNumberOfGuests + "<br />" +
//                "จำนวนห้องนอน : " + data.hostelNumberOfBedrooms + "<br />" +
//                "จำนวนห้องน้ำ : " + data.hostelNumberOfBathrooms + "<br />" +
//                "จองบ้านพัก : " +  data.hostelLinkToBook ;

//        })
//        .catch(error => {
//            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
//        });
//}

//rest1()