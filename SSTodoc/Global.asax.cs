using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using RestTodoc.ServiceInterface;
using ServiceStack;

namespace SSTodoc
{
    public class Global : System.Web.HttpApplication
    {

        public class AppHost : AppHostBase
        {
            public AppHost() : base("Todoc API", typeof(TodocService).Assembly) { }


            public override void Configure(Funq.Container container)
            {
                //Custom global uncaught exception handling strategy
                this.UncaughtExceptionHandlers.Add((req, res, operationName, ex) =>
                {
                    res.StatusCode = 400;
                    res.Write(string.Format("Exception {0}", ex.GetType().Name));
                    res.EndRequest(skipHeaders: true);
                });
            }
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            (new AppHost()).Init();
        }
    }
}