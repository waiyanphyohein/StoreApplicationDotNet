#pragma checksum "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f32087329f514057910fd9b5f2433d78453412d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Order), @"mvc.1.0.view", @"/Views/Shared/_Order.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Order.cshtml", typeof(AspNetCore.Views_Shared__Order))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/_ViewImports.cshtml"
using Project1.App;

#line default
#line hidden
#line 2 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/_ViewImports.cshtml"
using Project1.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f32087329f514057910fd9b5f2433d78453412d", @"/Views/Shared/_Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92c1ea347ad83f1afeca418273d95fb183aa6e78", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project1.App.Models.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(187, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
  
    ViewData["Title"] = "Order";

#line default
#line hidden
            BeginContext(230, 92, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Order</h4>\r\n    <hr />\r\n    <div class=\"card-deck\">\r\n\r\n");
            EndContext();
#line 19 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(371, 232, true);
            WriteLiteral("        <div class=\"card\" style=\"width: 18rem;\">\r\n            <div class=\"card-Title\">\r\n                Featured\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\">");
            EndContext();
            BeginContext(604, 41, false);
#line 26 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                       Write(Html.DisplayNameFor(modelItem => item.ID));

#line default
#line hidden
            EndContext();
            BeginContext(645, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(647, 33, false);
#line 26 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                                                                  Write(Html.DisplayFor(model => item.ID));

#line default
#line hidden
            EndContext();
            BeginContext(680, 51, true);
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
            EndContext();
            BeginContext(732, 47, false);
#line 27 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                       Write(Html.DisplayNameFor(model => item.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(779, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(781, 43, false);
#line 27 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                                                                        Write(Html.DisplayFor(model => item.CustomerName));

#line default
#line hidden
            EndContext();
            BeginContext(824, 51, true);
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">");
            EndContext();
            BeginContext(876, 43, false);
#line 28 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                       Write(Html.DisplayNameFor(model => item.Location));

#line default
#line hidden
            EndContext();
            BeginContext(919, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(921, 39, false);
#line 28 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                                                                    Write(Html.DisplayFor(model => item.Location));

#line default
#line hidden
            EndContext();
            BeginContext(960, 73, true);
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">\r\n                    ");
            EndContext();
            BeginContext(1034, 47, false);
#line 30 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
               Write(Html.DisplayNameFor(model => item.PurchaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(1081, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(1083, 43, false);
#line 30 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                                                Write(Html.DisplayFor(model => item.PurchaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 56, true);
            WriteLiteral("\r\n                </li>\r\n            </ul>\r\n            ");
            EndContext();
            BeginContext(1182, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f32087329f514057910fd9b5f2433d78453412d8508", async() => {
                BeginContext(1282, 12, true);
                WriteLiteral("Order Detail");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 33 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
                                                                                           WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1298, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 35 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_Order.cshtml"
        }

#line default
#line hidden
            BeginContext(1327, 40, true);
            WriteLiteral("       </div>\r\n    </div>\r\n<div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project1.App.Models.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
