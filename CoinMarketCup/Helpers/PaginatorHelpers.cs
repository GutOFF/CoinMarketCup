using CoinMarketCup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CoinMarketCup.Helpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginatorHelpers : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PaginatorHelpers(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PaginatorInfoModel PageModel { get; set; }

        public string PageAction { get; set; }

        public string SortOrder { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination");

            if (PageModel.PagesCount > 1)
            {
                for (int i = 1; i <= PageModel.PagesCount; i++)
                {
                    var tagLi = new TagBuilder("li");
                    tagLi.AddCssClass("page-item");

                    var tagA = new TagBuilder("a");

                    tagA.Attributes["href"] = urlHelper.Action(PageAction, new { page = i, sortOrder = SortOrder });
                    tagA.InnerHtml.Append(i.ToString());
                    tagA.AddCssClass("page-link");

                    if (i == PageModel.CurrentPage)
                    {
                        tagLi.AddCssClass("active");
                    }

                    tagLi.InnerHtml.AppendHtml(tagA);

                    tagUl.InnerHtml.AppendHtml(tagLi);
                }
            }

            output.Content.AppendHtml(tagUl);
        }
    }
}

