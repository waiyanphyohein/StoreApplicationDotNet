#pragma checksum "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab2f8b74ebd7ad5c63cf77ec3c9aea5e9d8d0437"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_Select), @"mvc.1.0.view", @"/Views/Location/Select.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Location/Select.cshtml", typeof(AspNetCore.Views_Location_Select))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab2f8b74ebd7ad5c63cf77ec3c9aea5e9d8d0437", @"/Views/Location/Select.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92c1ea347ad83f1afeca418273d95fb183aa6e78", @"/Views/_ViewImports.cshtml")]
    public class Views_Location_Select : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project1.App.Models.InventoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ProductID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Price", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
  
    ViewData["Title"] = "Place Order";

#line default
#line hidden
            BeginContext(105, 63, true);
            WriteLiteral("\n<h1>Place Order</h1>\n\n<div>\n    <h4>Inventory</h4>\n    <hr />\n");
            EndContext();
#line 12 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
     using (Html.BeginForm("PlaceOrder", "Location"))
    {
    

#line default
#line hidden
#line 14 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(267, 75, true);
            WriteLiteral("        <dl class=\"col\">\n            <dt class=\"col-sm-2\">\n                ");
            EndContext();
            BeginContext(343, 46, false);
#line 18 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayNameFor(model => item.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(389, 70, true);
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
            EndContext();
            BeginContext(460, 42, false);
#line 21 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayFor(model => item.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(502, 69, true);
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
            EndContext();
            BeginContext(572, 40, false);
#line 24 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayNameFor(model => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(612, 72, true);
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                $ ");
            EndContext();
            BeginContext(685, 36, false);
#line 27 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
             Write(Html.DisplayFor(model => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(721, 69, true);
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
            EndContext();
            BeginContext(791, 51, false);
#line 30 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayNameFor(model => item.RestrictedAmount));

#line default
#line hidden
            EndContext();
            BeginContext(842, 70, true);
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
            EndContext();
            BeginContext(913, 47, false);
#line 33 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayFor(model => item.RestrictedAmount));

#line default
#line hidden
            EndContext();
            BeginContext(960, 69, true);
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
            EndContext();
            BeginContext(1030, 49, false);
#line 36 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayNameFor(model => item.AvailableUnits));

#line default
#line hidden
            EndContext();
            BeginContext(1079, 70, true);
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
            EndContext();
            BeginContext(1150, 45, false);
#line 39 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
           Write(Html.DisplayFor(model => item.AvailableUnits));

#line default
#line hidden
            EndContext();
            BeginContext(1195, 93, true);
            WriteLiteral("\n            </dd>\n        </dl>\n        <label>\n            Amount:\n           \n            ");
            EndContext();
            BeginContext(1288, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ab2f8b74ebd7ad5c63cf77ec3c9aea5e9d8d04378358", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 45 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.ProductID);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
#line 45 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
                                                                          WriteLiteral(item.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1380, 13, true);
            WriteLiteral("\n            ");
            EndContext();
            BeginContext(1393, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ab2f8b74ebd7ad5c63cf77ec3c9aea5e9d8d043710943", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 46 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.Price);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#line 46 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
                                                                 WriteLiteral(item.Price);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1472, 33, true);
            WriteLiteral("\n            <input type=\"number\"");
            EndContext();
            BeginWriteAttribute("asp-for", " asp-for = \"", 1505, "\"", 1535, 1);
#line 47 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 1517, item.SelectAmount, 1517, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1536, 36, true);
            WriteLiteral(" data-val=\"true\" name=\"SelectAmount\"");
            EndContext();
            BeginWriteAttribute("max", " max=", 1572, "", 1667, 1);
#line 47 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 1577, item.RestrictedAmount>item.AvailableUnits ? item.AvailableUnits : item.RestrictedAmount, 1577, 90, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1667, 29, true);
            WriteLiteral(" min=\"0\" />\n        </label>\n");
            EndContext();
            BeginContext(1709, 11, true);
            WriteLiteral("    <hr />\n");
            EndContext();
#line 51 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
    }

#line default
#line hidden
            BeginContext(1755, 134, true);
            WriteLiteral("        <input type =\"submit\" class=\"btn btn-primary float-right\" value=\"Place Order\"/>\n        <input type=\"hidden\" name=\"LocationID\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1889, "\"", 1920, 1);
#line 54 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 1897, TempData["LocationID"], 1897, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1921, 50, true);
            WriteLiteral(" />\n        <input type=\"hidden\" name=\"CustomerID\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1971, "\"", 2002, 1);
#line 55 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 1979, TempData["CustomerID"], 1979, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2003, 4, true);
            WriteLiteral(" />\n");
            EndContext();
#line 56 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
    }

#line default
#line hidden
            BeginContext(2013, 13, true);
            WriteLiteral("</div>\n<div>\n");
            EndContext();
#line 59 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
     using (Html.BeginForm("Index", "Location"))
    {

#line default
#line hidden
            BeginContext(2081, 134, true);
            WriteLiteral("        <input type=\"submit\" class=\"btn btn-outline-primary\" value=\"Back to Location\"/>\n        <input type=\"hidden\" name=\"LocationID\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2215, "\"", 2246, 1);
#line 62 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 2223, TempData["LocationID"], 2223, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2247, 50, true);
            WriteLiteral(" />\n        <input type=\"hidden\" name=\"CustomerID\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2297, "\"", 2328, 1);
#line 63 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
WriteAttributeValue("", 2305, TempData["CustomerID"], 2305, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2329, 4, true);
            WriteLiteral(" />\n");
            EndContext();
#line 64 "/Users/waiyanphyohein/Projects/Project1/Project1.App/Views/Location/Select.cshtml"
    }

#line default
#line hidden
            BeginContext(2339, 16, true);
            WriteLiteral("        \n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project1.App.Models.InventoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
