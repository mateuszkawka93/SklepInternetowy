using MvcSiteMapProvider;
using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Models;
using System.Collections.Generic;

namespace SklepInternetowy.Infrastructure
{
    public class DynamicNodeProviderProductDetails : DynamicNodeProviderBase
    {
        private SupplementsContext _db = new SupplementsContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Supplement supplement in _db.Supplements)
            {
                DynamicNode node = new DynamicNode();
                node.Title = supplement.Name;
                node.Key = "Supplement_" + supplement.SupplementId;
                node.ParentKey = "Category_" + supplement.CategoryId;
                node.RouteValues.Add("id", supplement.SupplementId);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}