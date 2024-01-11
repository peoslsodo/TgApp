using System;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace TgApp.Util
{

    public class LoggingInterceptor : IInterceptor
    {
        public ILogger Logger;

        public void Intercept(IInvocation invocation)
        {
            Logger.Info(invocation.Method.Name);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Logger.Error(ex + ex.Message);
            }

        }
    }
}