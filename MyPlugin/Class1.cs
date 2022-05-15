
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MyPlugin
{
    public class Class1 : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference which you will need for
            // web service calls.
            IOrganizationServiceFactory serviceFactory =
            (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService svc = serviceFactory.CreateOrganizationService(context.UserId);

          //  ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // The InputParameters collection contains all the data passed in the message request.  
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {

                // Obtain the target entity from the input parameters.  
                Entity contactRecord = (Entity)context.InputParameters["Target"];

                //From here you can add your custom code
                string lastname = contactRecord.Attributes["lastname"].ToString();
               
                if (lastname.Length<=20)
                {
                    throw new InvalidPluginExecutionException("Lastname lenght should be less than 20 char");
                }

            }
            }
        }
}
