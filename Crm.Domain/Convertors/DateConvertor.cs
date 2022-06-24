using System.Globalization;

namespace Crm.Domain.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static string ToShamsiTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00") + " " + value.ToString("HH:mm:ss");
        }  
        public static DateTime AddMonthsPersian(this DateTime value,int month)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();
            var today = value;
            var dateTime = persianCalendar.AddMonths(today, month);

            return dateTime;
        }

        public static List<DateTime> GetInstallment(DateTime dateOfFirstInstallment, int month)
        {
            List<DateTime> dateTimes = new List<DateTime> {dateOfFirstInstallment};

            month -= 1;

            for (int i = 0; i < month; i++)
            {
                var descending = dateTimes.MaxBy(x=> x.Date);
                dateTimes.Add(descending.AddMonths(1));
            }


            return dateTimes;
        }
        public static string GetDay(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    {
                        return "جمعه";
                    }
                case DayOfWeek.Monday:
                    {
                        return "دوشنبه";
                    }
                case DayOfWeek.Saturday:
                    {
                        return "شنبه";
                    }
                case DayOfWeek.Sunday:
                    {
                        return "یکشنبه";
                    }
                case DayOfWeek.Thursday:
                    {
                        return "پنچشنبه";
                    }
                case DayOfWeek.Wednesday:
                    {
                        return "چهارشنبه";
                    }
                case DayOfWeek.Tuesday:
                    {
                        return "سه شنبه";
                    }
                default:
                    {
                        return "هیچ";
                    }
            }

        }



        public static DateTime ToDateTime(this string dateTime)
        {
            PersianCalendar p = new PersianCalendar();
            string[] parts = dateTime.Split('/', '-');
            return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0, 0, 0);
        }
    }

}
