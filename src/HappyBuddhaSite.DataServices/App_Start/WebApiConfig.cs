using HappyBuddhaSite.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace HappyBuddhaSite.DataServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			ODataModelBuilder builder = new ODataConventionModelBuilder();

			builder.EntitySet<SelfReview>("SelfReview");

			builder.EntitySet<TeamReview>("TeamReview");

			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: null,
				model: builder.GetEdmModel()
			);
        }
    }
}
