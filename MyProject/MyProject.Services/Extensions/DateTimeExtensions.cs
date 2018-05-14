using System;

namespace MyProject.Services.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// ����ʱ���
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static long GenerateTimeStamp(this DateTime now)
        {
            TimeSpan ts = now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds) + Environment.TickCount;
        }
        
    }
}