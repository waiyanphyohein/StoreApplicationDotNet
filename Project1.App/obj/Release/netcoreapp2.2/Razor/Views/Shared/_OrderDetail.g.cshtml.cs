#pragma checksum "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "385a175df096c72ca4891400b3a7edec1fa9605b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__OrderDetail), @"mvc.1.0.view", @"/Views/Shared/_OrderDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_OrderDetail.cshtml", typeof(AspNetCore.Views_Shared__OrderDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"385a175df096c72ca4891400b3a7edec1fa9605b", @"/Views/Shared/_OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92c1ea347ad83f1afeca418273d95fb183aa6e78", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project1.App.Models.OrderDetailViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(108, 72, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Review</h4>\r\n    <hr />\r\n    \r\n    ");
            EndContext();
            BeginContext(180, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "385a175df096c72ca4891400b3a7edec1fa9605b3869", async() => {
                BeginContext(240, 14, true);
                WriteLiteral("Back to Detail");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 13 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
                            WriteLiteral(TempData["CustomerID"]);

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
            BeginContext(258, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
            BeginContext(300, 73, true);
            WriteLiteral("    <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(374, 46, false);
#line 18 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
           Write(Html.DisplayNameFor(model => item.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(420, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(494, 42, false);
#line 21 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
           Write(Html.DisplayFor(model => item.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(536, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(609, 40, false);
#line 24 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
           Write(Html.DisplayNameFor(model => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(649, 75, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                $ ");
            EndContext();
            BeginContext(725, 36, false);
#line 27 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
             Write(Html.DisplayFor(model => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(761, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(834, 43, false);
#line 30 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
           Write(Html.DisplayNameFor(model => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(877, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(951, 39, false);
#line 33 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
           Write(Html.DisplayFor(model => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(990, 36, true);
            WriteLiteral("\r\n            </dd>\r\n    </dl>\r\n    ");
            EndContext();
            BeginContext(1026, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "385a175df096c72ca4891400b3a7edec1fa9605b9077", async() => {
                BeginContext(1086, 14, true);
                WriteLiteral("Back to Detail");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
                            WriteLiteral(TempData["CustomerID"]);

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
            BeginContext(1104, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 37 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Shared/_OrderDetail.cshtml"
        }

#line default
#line hidden
            BeginContext(1117, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project1.App.Models.OrderDetailViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
