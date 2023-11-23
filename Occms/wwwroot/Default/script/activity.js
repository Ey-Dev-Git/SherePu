

function activity_1() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/1')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic1').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head1').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content1').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg1').href = locationact1.locationTravelPathGoogleMap;

            document.getElementById('act_pic1').src = locationact1.activities[0].activityPicture;
            document.getElementById('act_head1').innerText = locationact1.activities[0].activityName;
            document.getElementById('act_content1').innerText = locationact1.activities[0].activityDetail;

            document.getElementById('act_pic2').src = locationact1.activities[1].activityPicture;
            document.getElementById('act_head2').innerText = locationact1.activities[1].activityName;
            document.getElementById('act_content2').innerText = locationact1.activities[1].activityDetail;

            document.getElementById('act_pic3').src = locationact1.activities[2].activityPicture;
            document.getElementById('act_head3').innerText = locationact1.activities[2].activityName;
            document.getElementById('act_content3').innerText = locationact1.activities[2].activityDetail;



        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}


function activity_2() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/2')
        .then(response => response.json())
        .then(data => {
            
            const locationact1 = data[0];

            document.getElementById('loca_pic2').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head2').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content2').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg2').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}



function activity_3() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/3')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic3').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head3').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content3').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg3').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_4() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/4')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic4').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head4').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content4').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg4').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_5() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/5')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic5').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head5').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content5').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg5').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_6() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/6')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic6').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head6').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content6').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg6').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_7() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/7')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic7').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head7').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content7').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg7').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_8() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/8')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic8').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head8').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content8').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg8').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_9() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/9')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic9').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head9').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content9').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg9').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}

function activity_10() {
    fetch('https://localhost:44300/LocationTravel/FindLocationTravelByID/10')
        .then(response => response.json())
        .then(data => {
            const locationact1 = data[0];

            document.getElementById('loca_pic10').src = locationact1.locationTravelPicture;
            document.getElementById('loca_head10').innerText = locationact1.locationTravelName;
            document.getElementById('loca_content10').innerText = locationact1.locationTravelDetail;
            document.getElementById('gg10').href = locationact1.locationTravelPathGoogleMap;


        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}



activity_1()
activity_2()
activity_3()
activity_4()
activity_5()
activity_6()
activity_7()
activity_8()
activity_9()
activity_10()