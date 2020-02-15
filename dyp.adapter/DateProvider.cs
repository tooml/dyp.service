using System;

namespace dyp.adapter
{
    public class DateProvider : IDateProvider
    {
        public DateTime Get_current_date()
        {
            return DateTime.Now.Date;
        }
    }
}
