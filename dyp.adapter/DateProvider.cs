using System;

namespace dyp.adapter
{
    public static class DateProvider
    {
        public static DateTime Get_current_date()
        {
            return DateTime.Now.Date;
        }
    }
}
