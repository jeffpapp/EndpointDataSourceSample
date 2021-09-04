using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
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
        private readonly PageLoader pageLoader;

        public IndexModel(ILogger<IndexModel> logger,
            EndpointDataSource endpointDataSource,
            PageLoader pageLoader)
        {
            _logger = logger;
            this.endpointDataSource = endpointDataSource;
            this.pageLoader = pageLoader;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var endpoint1 = this.HttpContext.GetEndpoint(); // This one has 15 pieces of metadata, including the RazorPageTestMetadataAttribute

            var endpoint2 = endpointDataSource.Endpoints.Where(x => x.Metadata.GetMetadata<PageRouteMetadata>() != null && x.Metadata.GetMetadata<PageRouteMetadata>().PageRoute == "/Privacy").FirstOrDefault();  // This one has 4 pieces of metadata.  Does not have the RazorPageTestMetadataAttribute attribute metadata

            var endpoint3 = await pageLoader.LoadAsync(endpoint2.Metadata.GetMetadata<PageActionDescriptor>());

            return Page();
        }
    }
}