using Castle.Core.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;
using TgLib;

namespace TgApp.Job
{
    [DisallowConcurrentExecution]
    public class BatchSendMsgJob : IJob
    {
        public TextBox Result;
        private readonly ITgClient tgClient = WindsorUtil.Resolve<ITgClient>();
        private ILogger _logger = WindsorUtil.Resolve<ILogger>();
        private TdExceptionHandle _handle = WindsorUtil.Resolve<TdExceptionHandle>();
        public async Task Execute(IJobExecutionContext context)
        {
            var random = new Random();
            var interval = context.JobDetail.JobDataMap.GetInt("Interval");
            this.Result = (TextBox)context.JobDetail.JobDataMap["Result"];
            var groupList = context.JobDetail.JobDataMap["SelectList"] as List<GroupView>;
            var msgList = context.JobDetail.JobDataMap["MsgList"] as List<MsgModel>;
            var exceptionMsg = string.Empty;
            foreach (var group in groupList)
            {
                var msg = msgList[random.Next(0, msgList.Count)];
                try
                {
                    await tgClient.SendMessageAsync(group.Id, msg.Content);
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
                        $"Success--{DateTime.Now.ToString(CultureInfo.InvariantCulture)}--[{msg.Title}] send to the Group[{group.Title}]"
                        : $"Fail--{DateTime.Now.ToString(CultureInfo.InvariantCulture)}--[{msg.Title}] send to Group[{group.Title}]--error-{exceptionMsg}";
                    this.Result.Invoke(new Action(() =>
                    {
                        this.Result.AppendText(result);
                        this.Result.AppendText(Environment.NewLine);
                    }));
                }
            }
        }


     
    }
}
