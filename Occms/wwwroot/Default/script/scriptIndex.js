function open_modal() {
    // เมื่อหน้าเว็บโหลดเสร็จสมบูรณ์
    window.addEventListener("DOMContentLoaded", function () {
        // แสดง Modal
        var modal = document.getElementById("exampleModal");
        var modalInstance = new bootstrap.Modal(modal);
        modalInstance.show();
    });
}


function modal() {
    let text_show = document.getElementById('notification');
    let text_show2 = document.getElementById('threem');

    let day_time = new Date();
/*    console.log(day_time);*/

    let dayOfWeek = day_time.getDay();
    let hour = day_time.getHours();

    //dayOfWeek = 0;
    //hour = 6;

    console.log(dayOfWeek)
    console.log(hour)

    if (
        (dayOfWeek >= 1 && dayOfWeek <= 5 && hour >= 8 && hour <= 17) || // จันทร์ - ศุกร์, 8.00 - 17.00
        (dayOfWeek === 6 && hour >= 7 && hour <= 19) || // เสาร์, 7.00 - 19.00
        (dayOfWeek === 0 && hour >= 7 && hour <= 19) // อาทิตย์, 7.00 - 19.00
    ) {
        text_show.textContent = "เปิดให้บริการตามปกติ !";
        text_show.style.color = '#4AE07C';
        text_show2.textContent = 'ยินดีต้อนรับ เข้าสู่เว็บไซต์'
    } else {
        text_show.textContent = "ปิดให้บริการชั่วคราว !";
        text_show.style.color = 'red';
        text_show2.textContent = 'ขออภัยในความไม่สะดวกมา ณ ที่นี้'
    }
}

modal();




//function LocationTravel() {
//    fetch('https://localhost:44300/LocationTravel/AllLocationTravel')
//        .then(response => response.json())
//        .then(data => {
//            const ft = data[0];
//            const sec = data[1];
//            const th = data[2];
//            const four = data[3];
//            const fift = data[4];
//            const six = data[5];
//            const sev = data[6];
//            const eigh = data[7];
//            const nin = data[8];
//            const ten = data[9];

//            const locationName1 = document.getElementById('locationName1');
//            const locationName2 = document.getElementById('locationName2');
//            const locationName3 = document.getElementById('locationName3');
//            const locationName4 = document.getElementById('locationName4');
//            const locationName5 = document.getElementById('locationName5');
//            const locationName6 = document.getElementById('locationName6');
//            const locationName7 = document.getElementById('locationName7');
//            const locationName8 = document.getElementById('locationName8');
//            const locationName9 = document.getElementById('locationName9');
//            const locationName10 = document.getElementById('locationName10');

//            const picLocation1 = ft.locationTravelPicture;
//            const picLocation2 = sec.locationTravelPicture;
//            const picLocation3 = th.locationTravelPicture;
//            const picLocation4 = four.locationTravelPicture;
//            const picLocation5 = fift.locationTravelPicture;
//            const picLocation6 = six.locationTravelPicture;
//            const picLocation7 = sev.locationTravelPicture;
//            const picLocation8 = eigh.locationTravelPicture;
//            const picLocation9 = nin.locationTravelPicture;
//            const picLocation10 = ten.locationTravelPicture;

//            locationName1.textContent = ft.locationTravelName;
//            locationName2.textContent = sec.locationTravelName;
//            locationName3.textContent = th.locationTravelName;
//            locationName4.textContent = four.locationTravelName;
//            locationName5.textContent = fift.locationTravelName;
//            locationName6.textContent = six.locationTravelName;
//            locationName7.textContent = sev.locationTravelName;
//            locationName8.textContent = eigh.locationTravelName;
//            locationName9.textContent = nin.locationTravelName;
//            locationName10.textContent = ten.locationTravelName;

//            document.getElementById('pic_location1').src = picLocation1;
//            document.getElementById('pic_location2').src = picLocation2;
//            document.getElementById('pic_location3').src = picLocation3;
//            document.getElementById('pic_location4').src = picLocation4;
//            document.getElementById('pic_location5').src = picLocation5;
//            document.getElementById('pic_location6').src = picLocation6;
//            document.getElementById('pic_location7').src = picLocation7;
//            document.getElementById('pic_location8').src = picLocation8;
//            document.getElementById('pic_location9').src = picLocation9;
//            document.getElementById('pic_location10').src = picLocation10;


//        })
//        .catch(error => {
//            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
//        });
//}


function LocationTravel() {
    fetch('https://localhost:44300/LocationTravel/AllLocationTravel')
        .then(response => response.json())
        .then(data => {
            data.forEach((location, index) => {
                const locationNameElement = document.getElementById(`locationName${index + 1}`);
                const picLocationElement = document.getElementById(`pic_location${index + 1}`);

                locationNameElement.textContent = location.locationTravelName;
                picLocationElement.src = location.locationTravelPicture;
            });
        })
        .catch(error => {
            console.log('เกิดข้อผิดพลาดในการเรียก API:', error);
        });
}



function check_cond(cond) {
    switch (cond) {
        case "ท้องฟ้าแจ่มใส":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 24 24"><g fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"><path d="M0 0h24v24H0z"/><path fill="#ffe168" d="M12 19a1 1 0 0 1 .993.883L13 20v1a1 1 0 0 1-1.993.117L11 21v-1a1 1 0 0 1 1-1zm6.313-2.09l.094.083l.7.7a1 1 0 0 1-1.32 1.497l-.094-.083l-.7-.7a1 1 0 0 1 1.218-1.567l.102.07zm-11.306.083a1 1 0 0 1 .083 1.32l-.083.094l-.7.7a1 1 0 0 1-1.497-1.32l.083-.094l.7-.7a1 1 0 0 1 1.414 0zM4 11a1 1 0 0 1 .117 1.993L4 13H3a1 1 0 0 1-.117-1.993L3 11h1zm17 0a1 1 0 0 1 .117 1.993L21 13h-1a1 1 0 0 1-.117-1.993L20 11h1zM6.213 4.81l.094.083l.7.7a1 1 0 0 1-1.32 1.497l-.094-.083l-.7-.7A1 1 0 0 1 6.11 4.74l.102.07zm12.894.083a1 1 0 0 1 .083 1.32l-.083.094l-.7.7a1 1 0 0 1-1.497-1.32l.083-.094l.7-.7a1 1 0 0 1 1.414 0zM12 2a1 1 0 0 1 .993.883L13 3v1a1 1 0 0 1-1.993.117L11 4V3a1 1 0 0 1 1-1zm0 5a5 5 0 1 1-4.995 5.217L7 12l.005-.217A5 5 0 0 1 12 7z"/></g></svg> <br />ท้องฟ้าแจ่มใส';
            return cond;
            break;

        case "มีเมฆบางส่วน":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#FFAC33" d="M14 2s0-2 2-2s2 2 2 2v2s0 2-2 2s-2-2-2-2V2zm16 12s2 0 2 2s-2 2-2 2h-2s-2 0-2-2s2-2 2-2h2zM4 14s2 0 2 2s-2 2-2 2H2s-2 0-2-2s2-2 2-2h2zm3.872-7.957s1.414 1.414 0 2.828s-2.828 0-2.828 0L3.629 7.458s-1.414-1.414 0-2.829c1.415-1.414 2.829 0 2.829 0l1.414 1.414zm19.085 2.828s-1.414 1.414-2.828 0s0-2.828 0-2.828l1.414-1.414s1.414-1.414 2.828 0s0 2.828 0 2.828l-1.414 1.414z"/><circle cx="16" cy="16" r="9" fill="#FFAC33"/><path fill="#E1E8ED" d="M28 20c-.825 0-1.62.125-2.369.357A6.498 6.498 0 0 0 19.5 16c-3.044 0-5.592 2.096-6.299 4.921A4.459 4.459 0 0 0 10.5 20A4.5 4.5 0 0 0 6 24.5c0 .604.123 1.178.339 1.704A4.98 4.98 0 0 0 5 26c-2.762 0-5 2.238-5 5s2.238 5 5 5h23a8 8 0 1 0 0-16z"/></svg><br />มีเมฆบางส่วน'
            return cond;
            break;

        case "เมฆเป็นส่วนมาก":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#FFAC33" d="M13 6s0-2 2-2s2 2 2 2v2s0 2-2 2s-2-2-2-2V6zM4 17s2 0 2 2s-2 2-2 2H2s-2 0-2-2s2-2 2-2h2zm3.872-6.957s1.414 1.414 0 2.828s-2.828 0-2.828 0l-1.415-1.414s-1.414-1.414 0-2.829c1.415-1.414 2.829 0 2.829 0l1.414 1.415zm17.085 2.828s-1.414 1.414-2.828 0s0-2.828 0-2.828l1.414-1.414s1.414-1.414 2.828 0s0 2.828 0 2.828l-1.414 1.414z"/><circle cx="15" cy="19" r="8" fill="#FFAC33"/><path fill="#E1E8ED" d="M28.223 16.8c-.803 0-1.575.119-2.304.34c-.862-2.409-3.201-4.14-5.961-4.14c-2.959 0-5.437 1.991-6.123 4.675a4.399 4.399 0 0 0-2.626-.875c-2.417 0-4.375 1.914-4.375 4.275c0 .573.12 1.118.329 1.618a4.949 4.949 0 0 0-1.302-.193C3.176 22.5 1 24.626 1 27.25S3.176 32 5.861 32h22.361C32.518 32 36 28.598 36 24.4s-3.482-7.6-7.777-7.6z"/></svg><br />เมฆเป็นส่วนมาก</svg>'
            return cond;
            break;

        case "มีเมฆมาก":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#CCD6DD" d="M27 8a6.98 6.98 0 0 0-2.015.298c.005-.1.015-.197.015-.298a5.998 5.998 0 0 0-11.785-1.573A5.974 5.974 0 0 0 11 6a6 6 0 1 0 0 12a5.998 5.998 0 0 0 5.785-4.428A5.975 5.975 0 0 0 19 14c.375 0 .74-.039 1.096-.104c-.058.36-.096.727-.096 1.104c0 3.865 3.135 7 7 7s7-3.135 7-7a7 7 0 0 0-7-7z"/><path fill="#E1E8ED" d="M31 22c-.467 0-.91.085-1.339.204c.216-.526.339-1.1.339-1.704a4.5 4.5 0 0 0-4.5-4.5a4.459 4.459 0 0 0-2.701.921A6.497 6.497 0 0 0 16.5 12a6.497 6.497 0 0 0-6.131 4.357A8 8 0 1 0 8 32h23c2.762 0 5-2.238 5-5s-2.238-5-5-5z"/></svg><br />มีเมฆมาก</svg>'
            return cond;
            break;

        case "ฝนตกเล็กน้อย":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#FFAC33" d="M13 2s0-2 2-2s2 2 2 2v2s0 2-2 2s-2-2-2-2V2zM4 13s2 0 2 2s-2 2-2 2H2s-2 0-2-2s2-2 2-2h2zm3.872-6.957s1.414 1.414 0 2.828s-2.828 0-2.828 0L3.629 7.458s-1.414-1.414 0-2.829c1.415-1.414 2.829 0 2.829 0l1.414 1.414zm17.085 2.828s-1.414 1.414-2.828 0s0-2.828 0-2.828l1.414-1.414s1.414-1.414 2.828 0s0 2.828 0 2.828l-1.414 1.414z"/><circle cx="15" cy="15" r="8" fill="#FFAC33"/><path fill="#E1E8ED" d="M28.223 12.8c-.803 0-1.575.119-2.304.34C25.057 10.731 22.718 9 19.958 9c-2.959 0-5.437 1.991-6.123 4.675a4.399 4.399 0 0 0-2.626-.875c-2.417 0-4.375 1.914-4.375 4.275c0 .573.12 1.119.329 1.619a4.949 4.949 0 0 0-1.302-.194C3.176 18.5 1 20.626 1 23.25S3.176 28 5.861 28h22.361C32.518 28 36 24.598 36 20.4s-3.482-7.6-7.777-7.6z"/><path fill="#5DADEC" d="m11.999 33.961l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 10.057 36a1.974 1.974 0 0 0 1.942-2.039zm-6.979-1.54L4.906 29l-2.869 1.708a1.963 1.963 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm14 .54l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 17.078 35a1.974 1.974 0 0 0 1.942-2.039zm5.978 1l-.113-3.421l-2.869 1.708a1.962 1.962 0 0 0-1.035 1.799A2.033 2.033 0 0 0 23.057 36a1.973 1.973 0 0 0 1.941-2.039zm6.021-1.54L30.905 29l-2.869 1.708a1.962 1.962 0 0 0-1.035 1.799a2.032 2.032 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.942-2.039z"/></svg><br />ฝนตกเล็กน้อย</svg>';
            return cond
            break;

        case "ฝนปานกลาง":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#E1E8ED" d="M28 4c-.825 0-1.62.125-2.369.357A6.498 6.498 0 0 0 19.5 0c-3.044 0-5.592 2.096-6.299 4.921A4.459 4.459 0 0 0 10.5 4A4.5 4.5 0 0 0 6 8.5c0 .604.123 1.178.339 1.704A4.98 4.98 0 0 0 5 10c-2.762 0-5 2.238-5 5s2.238 5 5 5h23a8 8 0 1 0 0-16z"/><path fill="#5DADEC" d="m11.999 24.961l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.033 2.033 0 0 0 10.056 27a1.975 1.975 0 0 0 1.943-2.039zm-1.979 7.46L9.907 29l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm-5-4.46l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.034 2.034 0 0 0 3.077 30a1.974 1.974 0 0 0 1.943-2.039zm18-3l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 21.078 27a1.974 1.974 0 0 0 1.942-2.039zm-6.021 4l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 15.057 31a1.974 1.974 0 0 0 1.942-2.039zm5.021 4.46L21.906 30l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm6.979-5.46l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 27.057 30a1.974 1.974 0 0 0 1.942-2.039z"/></svg><br />ฝนปานกลาง</svg>';
            return cond
            break;

        case "ฝนตกหนัก":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#E1E8ED" d="M28 4c-.825 0-1.62.125-2.369.357A6.498 6.498 0 0 0 19.5 0c-3.044 0-5.592 2.096-6.299 4.921A4.459 4.459 0 0 0 10.5 4A4.5 4.5 0 0 0 6 8.5c0 .604.123 1.178.339 1.704A4.98 4.98 0 0 0 5 10c-2.762 0-5 2.238-5 5s2.238 5 5 5h23a8 8 0 1 0 0-16z"/><path fill="#5DADEC" d="m11.999 24.961l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.033 2.033 0 0 0 10.056 27a1.975 1.975 0 0 0 1.943-2.039zm-1.979 7.46L9.907 29l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm-5-4.46l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.034 2.034 0 0 0 3.077 30a1.974 1.974 0 0 0 1.943-2.039zm18-3l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 21.078 27a1.974 1.974 0 0 0 1.942-2.039zm-6.021 4l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 15.057 31a1.974 1.974 0 0 0 1.942-2.039zm5.021 4.46L21.906 30l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm6.979-5.46l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 27.057 30a1.974 1.974 0 0 0 1.942-2.039z"/></svg><br />ฝนตกหนัก</svg>';
            return cond
            break;

        case "ฝนฟ้าคะนอง":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 36 36"><path fill="#F4900C" d="M13.917 36a.417.417 0 0 1-.371-.607L17 29h-5.078c-.174 0-.438-.031-.562-.297c-.114-.243-.057-.474.047-.703L15 19c.078-.067 6.902.393 7 .393a.417.417 0 0 1 .369.608l-3.817 6h5.032c.174 0 .329.108.391.271a.418.418 0 0 1-.119.461l-9.666 9.166a.422.422 0 0 1-.273.101z"/><path fill="#E1E8ED" d="M28 4c-.825 0-1.62.125-2.369.357A6.498 6.498 0 0 0 19.5 0c-3.044 0-5.592 2.096-6.299 4.921A4.459 4.459 0 0 0 10.5 4A4.5 4.5 0 0 0 6 8.5c0 .604.123 1.178.339 1.704A4.98 4.98 0 0 0 5 10c-2.762 0-5 2.238-5 5s2.238 5 5 5h23a8 8 0 1 0 0-16z"/><path fill="#5DADEC" d="m10.999 24.961l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.034 2.034 0 0 0 9.056 27a1.975 1.975 0 0 0 1.943-2.039zm-2 8l-.113-3.421l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799A2.034 2.034 0 0 0 7.056 35a1.974 1.974 0 0 0 1.943-2.039zm-4.979-5.54L3.907 24l-2.87 1.708a1.966 1.966 0 0 0-1.036 1.799a2.033 2.033 0 0 0 2.076 1.953a1.974 1.974 0 0 0 1.943-2.039zm25-2.46l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 27.078 27a1.974 1.974 0 0 0 1.942-2.039zm-2 9l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 25.078 36a1.974 1.974 0 0 0 1.942-2.039zm6-4l-.113-3.421l-2.869 1.708a1.964 1.964 0 0 0-1.036 1.799A2.033 2.033 0 0 0 31.078 32a1.974 1.974 0 0 0 1.942-2.039z"/></svg><br />ฝนฟ้าคะนอง</svg>';
            return cond
            break;

        case "ไม่ทราบสภาพอากาศ":
            cond = '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 24 24"><path fill="#d9d9d9" d="M9 15.5h6.25q1.15 0 1.95-.813t.8-1.937q0-1.125-.763-1.913T15.35 10q-.325-1.125-1.25-1.813T12 7.5q-1.025 0-1.875.537T8.85 9.525q-1.2.05-2.025.913T6 12.5q0 1.25.875 2.125T9 15.5Zm0-2q-.425 0-.713-.288T8 12.5q0-.425.275-.7t.675-.3h1.2l.5-1.125q.2-.425.563-.65T12 9.5q.5 0 .9.288t.525.787l.4 1.425h1.45q.325 0 .525.213t.2.537q0 .3-.212.525t-.538.225H9Zm3 8.5q-2.075 0-3.9-.788t-3.175-2.137q-1.35-1.35-2.137-3.175T2 12q0-2.075.788-3.9t2.137-3.175q1.35-1.35 3.175-2.137T12 2q2.075 0 3.9.788t3.175 2.137q1.35 1.35 2.138 3.175T22 12q0 2.075-.788 3.9t-2.137 3.175q-1.35 1.35-3.175 2.138T12 22Z"/></g><br />ไม่ทราบสภาพอากาศ</svg>';
            return cond
            break;

    }
}




function temp() {
    fetch('https://localhost:44300/TmdApi/GetDataTMD')
        .then(response => response.json())
        .then(data => {
            console.log(data);

            var day = "";

            data.forEach(daytemp => {

                

                day += '<div class="slide">' + daytemp.dayName + "<br />" + daytemp.time.slice(8, 10) + "<br />" + check_cond(daytemp.cond) + "<br />" + Math.floor(daytemp.maxTemperature) + "°C" + " " + Math.floor(daytemp.minTemperature) + "°C" + "<br />" + '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24"><g fill="none" fill-rule="evenodd"><path d="M24 0v24H0V0h24ZM12.593 23.258l-.011.002l-.071.035l-.02.004l-.014-.004l-.071-.035c-.01-.004-.019-.001-.024.005l-.004.01l-.017.428l.005.02l.01.013l.104.074l.015.004l.012-.004l.104-.074l.012-.016l.004-.017l-.017-.427c-.002-.01-.009-.017-.017-.018Zm.265-.113l-.013.002l-.185.093l-.01.01l-.003.011l.018.43l.005.012l.008.007l.201.093c.012.004.023 0 .029-.008l.004-.014l-.034-.614c-.003-.012-.01-.02-.02-.022Zm-.715.002a.023.023 0 0 0-.027.006l-.006.014l-.034.614c0 .012.007.02.017.024l.015-.002l.201-.093l.01-.008l.004-.011l.017-.43l-.003-.012l-.01-.01l-.184-.092Z"/><path fill="#212121" d="M10.5 4.5a1 1 0 0 0-.917.6a1.5 1.5 0 1 1-2.75-1.2A4 4 0 1 1 10.5 9.5H5a1.5 1.5 0 1 1 0-3h5.5a1 1 0 1 0 0-2Zm8 4a1 1 0 0 0-.917.6a1.5 1.5 0 0 1-2.75-1.2a4 4 0 1 1 3.667 5.6H3a1.5 1.5 0 0 1 0-3h15.5a1 1 0 1 0 0-2Zm-4.917 10.4a1 1 0 1 0 .917-1.4H8a1.5 1.5 0 0 1 0-3h6.5a4 4 0 1 1-3.666 5.6a1.5 1.5 0 1 1 2.749-1.2Z"/></g></svg>' + Math.floor(daytemp.windSpeed) + " กม./ชม" +'</div>'

            })

            document.getElementById('weather').innerHTML = day;

        })
        .catch(error => {
            /*console.log('เกิดข้อผิดพลาดในการเรียก API:', error);*/
            document.getElementById('weather').innerHTML += '<div>' + "เกิดข้อผิดพลาดในการเรียก API" + '</div>';
        });
}






open_modal()

temp();

LocationTravel();






