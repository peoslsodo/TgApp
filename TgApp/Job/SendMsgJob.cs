using Castle.Core.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;

namespace TgApp.Job
{
    public class SendMsgJob : IJob
    {
        public TextBox Result;
        private ILogger _logger = WindsorUtil.Resolve<ILogger>();
        private TdExceptionHandle _handle = WindsorUtil.Resolve<TdExceptionHandle>();
        public async Task Execute(IJobExecutionContext context)
        {
            var interval = context.JobDetail.JobDataMap.GetInt("Interval");
            this.Result = (TextBox)context.JobDetail.JobDataMap["Result"];
            var list = context.JobDetail.JobDataMap["List"] as List<AvailableContact>;
            var msgList = context.JobDetail.JobDataMap["MsgList"] as List<MsgModel>;
            var exceptionMsg = string.Empty;

            var random = new Random();
            foreach (var contact in list)
            {
                var msg = msgList[random.Next(0, msgList.Count)];
                try
                {
                   
                }
                catch (Exception ex)
                {
                    exceptionMsg = ex.Message;
                    var delay = this._handle.TooManyRequestHandle(ex);
                    await Task.Delay(delay);
                    this._logger.Error(ex.Message, ex);
                }
               
                finally
                {
                    var result = string.IsNullOrEmpty(exceptionMsg) ?
                        $"Success--{DateTime.Now.ToString(CultureInfo.InvariantCulture)}--[{msg.Title}]send to [{contact.FirstName}-{contact.LastName}]"
                        : $"[Fail--{DateTime.Now.ToString(CultureInfo.InvariantCulture)}--{msg.Title}]send to[{contact.FirstName}-{contact.LastName}]--Error--[{exceptionMsg}]";
                    this.Result.Invoke(new Action(() =>
                    {
                        this.Result.AppendText(result);
                        this.Result.AppendText(Environment.NewLine);
                    }));
                    await Task.Delay(interval * 1000);
                }



            }
        }
    }
}
