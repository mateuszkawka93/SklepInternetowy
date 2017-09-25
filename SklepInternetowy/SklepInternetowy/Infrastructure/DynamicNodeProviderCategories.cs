using MvcSiteMapProvider;
using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Models;
using System.Collections.Generic;

namespace SklepInternetowy.Infrastructure
{
    public class DynamicNodeProviderCategories: DynamicNodeProviderBase
    {
        private SupplementsContext _db = new SupplementsContext();


        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
        var returnValue = new List<DynamicNode>();

        foreach (Category category in _db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.CategoryName;
                node.Key = "Category_" + category.CategoryId;
                node.RouteValues.Add("categoryname", category.CategoryName);
                returnValue.Add(node);
             }

        return returnValue;
        }
    }
   
}