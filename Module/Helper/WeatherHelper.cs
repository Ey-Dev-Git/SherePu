using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Helper
{
    public class WeatherHelper
    {
        public static string GetConditionDescription(int cond) 
        {
            string condition = cond switch
            {
                800 => "ท้องฟ้าแจ่มใส",
                801 or 802 => "มีเมฆบางส่วน",
                803 => "เมฆเป็นส่วนมาก",
                804 => "มีเมฆมาก",
                300 or 301 or 302 => "ฝนตกเล็กน้อย",
                500 or 501 => "ฝนปานกลาง",
                502 or 522 => "ฝนตกหนัก",
                200 or 201 or 202 or 230 or 231 or 232 or 233 => "ฝนฟ้าคะนอง",
                900 => "ไม่ทราบสภาพอากาศ",
                _ => "ไม่ทราบสภาพอากาศ",
            };
            return condition;
        }

        public static string GetDayName(string dateAndTime)
        {
            DateTime dateNow = DateTime.Now.Date;
            string dateNowFormattedDate = dateNow.ToString("dd/MM/yyyy HH:mm:ss");


            DateTime dateAndTimeTMDApi = DateTime.ParseExact(dateAndTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string dateNowFormattedDateTMDApi = dateAndTimeTMDApi.ToString("dd/MM/yyyy HH:mm:ss");
            string dayName = dateAndTimeTMDApi.ToString("dddd");

            if (dateNowFormattedDate == dateNowFormattedDateTMDApi)
            {
                dayName = "วันนี้";
                return dayName;
            }
            else 
            {
                return dayName;
            }
        }

        public static double GetWindSpdKmH(double windSpdMS)
        {

            double windSpdKmH = (double)(windSpdMS * 3.6);
            return windSpdKmH;
        }

    }
}
