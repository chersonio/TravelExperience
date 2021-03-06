using AutoMapper;
using System;
using System.Web;
using System.Web.Http;
using TravelExperience.API.App_Start;
using TravelExperience.API.Configuration;

namespace TravelExperience.API
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Added these to start with the project
            ContainerConfig.RegisterContainerApi();
            GlobalConfiguration.Configure(TravelExperienceAPIConfig.Register);

            // For the Mapping of Dtos to work
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());


            // Formatting
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

        }
    }
}