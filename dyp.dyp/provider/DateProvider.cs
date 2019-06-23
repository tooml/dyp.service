using dyp.contracts;
using System;

namespace dyp.dyp.provider
{
    public class DateProvider : IDateProvider
    {
        public DateTime Get_current_date()
        {
            return DateTime.Now.Date;
        }
    }
}
