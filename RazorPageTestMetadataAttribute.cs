using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointDataSourceSample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RazorPageTestMetadataAttribute : Attribute
    {
        public RazorPageTestMetadataAttribute(string pageKey)
        {
            PageKey = pageKey;
        }

        public string PageKey { get; }
    }
}