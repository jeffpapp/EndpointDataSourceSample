using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointDataSourceSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EndpointDataSource endpointDataSource;

        public IndexModel(ILogger<IndexModel> logger,
            EndpointDataSource endpointDataSource)
        {
            _logger = logger;
            this.endpointDataSource = endpointDataSource;
        }

        public void OnGet()
        {
            var endpoint1 = this.HttpContext.GetEndpoint(); // This one has 15 pieces of metadata, including the RazorPageTestMetadataAttribute

            var endpoint2 = endpointDataSource.Endpoints.Where(x => x.Metadata.GetMetadata<PageRouteMetadata>() != null && x.Metadata.GetMetadata<PageRouteMetadata>().PageRoute == "/Index").FirstOrDefault();  // This one has 4 pieces of metadata.  Does not have the RazorPageTestMetadataAttribute attribute metadata
        }
    }
}