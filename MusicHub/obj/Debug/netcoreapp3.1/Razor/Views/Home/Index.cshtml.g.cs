#pragma checksum "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bf2281012923747dc915bbb323a31df2def772c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "D:\PU Programming\MusicHub\MusicHub\Views\_ViewImports.cshtml"
using MusicHubMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PU Programming\MusicHub\MusicHub\Views\_ViewImports.cshtml"
using MusicHubMaster.Infrastructures;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bf2281012923747dc915bbb323a31df2def772c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e668ce2b75530f4f54a08532d1a7adcd530144a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/home.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml"
  

    ViewData["Title"] = "Index";
    var stats = (MusicHubMaster.Data.StatisticsModel)ViewData["Stats"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2bf2281012923747dc915bbb323a31df2def772c4039", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<section class=""counter_feature"">
    <div class=""container"">
        <div class=""row text-center"">

            <div class=""col-lg-3 col-sm-6 col-xs-12 no-padding wow fadeInUp"" data-wow-duration=""1s"" data-wow-delay=""0.1s"" data-wow-offset=""0"">
                <div class=""single-project"">
                    <span class=""ti-user""></span>
                    <h2 class=""counter-num"">");
#nullable restore
#line 18 "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml"
                                       Write(stats.SongsCount.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <h4>Songs</h4>
                </div>

            </div>

            <div class=""col-lg-3 col-sm-6 col-xs-12 no-padding wow fadeInUp"" data-wow-duration=""1s"" data-wow-delay=""0.2s"" data-wow-offset=""0"">
                <div class=""single-project"">
                    <span class=""ti-star""></span>
                    <h2 class=""counter-num"">");
#nullable restore
#line 27 "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml"
                                       Write(stats.AlbumsCount.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <h4>Albums</h4>
                </div>
            </div><!-- END COL -->

            <div class=""col-lg-3 col-sm-6 col-xs-12 no-padding wow fadeInUp"" data-wow-duration=""1s"" data-wow-delay=""0.3s"" data-wow-offset=""0"">
                <div class=""single-project"">
                    <span class=""ti-pencil-alt""></span>
                    <h2 class=""counter-num"">");
#nullable restore
#line 35 "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml"
                                       Write(stats.PerformersCount.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <h4>Performers</h4>
                </div>
            </div><!-- END COL -->

            <div class=""col-lg-3 col-sm-6 col-xs-12 no-padding wow fadeInUp"" data-wow-duration=""1s"" data-wow-delay=""0.4s"" data-wow-offset=""0"">
                <div class=""single-project"">
                    <span class=""ti-star""></span>
                    <h2 class=""counter-num"">");
#nullable restore
#line 43 "D:\PU Programming\MusicHub\MusicHub\Views\Home\Index.cshtml"
                                       Write(stats.WritersCount.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h4>Writers</h4>\r\n                </div>\r\n            </div><!-- END COL -->\r\n        </div><!--- END ROW -->\r\n        <div class=\"row text-center\">\r\n\r\n        </div>\r\n    </div><!--- END ROW -->\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591