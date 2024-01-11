using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TgApp.Util
{
    public class TdExceptionHandle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="inteval"></param>
        /// <returns></returns>
        public int TooManyRequestHandle(Exception exception, int inteval = 10)
        {
            var msg = exception.Message;
            if (msg.Contains("Too Many Request"))
            {
                var matches = Regex.Matches(msg, @"\d+");
                foreach (var item in matches)
                {
                    return (Convert.ToInt32(item) + inteval) * 1000;
                }
            }
            return 0;
        }
    }
}
