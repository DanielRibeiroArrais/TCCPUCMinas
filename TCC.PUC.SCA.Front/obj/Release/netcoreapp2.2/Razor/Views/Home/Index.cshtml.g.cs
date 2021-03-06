#pragma checksum "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dd20c862ff1014fa31d42f6d8fd8e3d7afa7a93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\_ViewImports.cshtml"
using TCC.PUC.SCA.Front;

#line default
#line hidden
#line 2 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\_ViewImports.cshtml"
using TCC.PUC.SCA.Front.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dd20c862ff1014fa31d42f6d8fd8e3d7afa7a93", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d0afe29c125f52ee8b3512eab6f35200cad2f76", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TCC.PUC.SCA.Model.SpecificEntities.Common.Map>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/legenda.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutA.cshtml";

#line default
#line hidden
            BeginContext(149, 1423, true);
            WriteLiteral(@"
<title>TCC PUC Minas</title>

<div id=""myMap"" style=""position:relative; width:100%; min-height:575px;margin-top: -17px;""></div>

<div class=""fixed-bottom"" style=""margin-bottom:5px;margin-right:5px;"">
    <div class=""row"">

        <div class=""col-md-12"">
            <div class=""col-md-2 border border-secondary float-right legenda"" style=""background-color:white"">
                <div class=""row legendaTitulo"">
                    <div class=""col-md-12 text-center"">
                        Legenda Status Barragens
                    </div>
                </div>
                <div class=""row legendaConteudo"">
                    <div class=""col-md-6"">
                        <i class=""fas fa-dot-circle"" style=""color:green""></i> Normal
                    </div>
                    <div class=""col-md-6"">
                        <i class=""fas fa-dot-circle"" style=""color:gray""></i> Alerta
                    </div>
                </div>
                <div class=""row legendaConteudo"">");
            WriteLiteral(@"
                    <div class=""col-md-6"">
                        <i class=""fas fa-dot-circle"" style=""color:blue""></i> Perigo
                    </div>
                    <div class=""col-md-6"">
                        <i class=""fas fa-dot-circle"" style=""color:red""></i> Evacuação
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(1572, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2dd20c862ff1014fa31d42f6d8fd8e3d7afa7a935650", async() => {
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
            EndContext();
            BeginContext(1622, 4269, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    var map = null;

    var defaultColor = 'blue';
    var hoverColor = 'red';
    var mouseDownColor = 'purple';

    function LoadMap() {
        map = new Microsoft.Maps.Map('#myMap', {
            credentials: ""AoLdAUWVS63SFgtfFCGVQOWD8t-g4jg2GdZi8F7Cj1Zh9oDgdS8aK50JIHVfWkYF"",
            showLocateMeButton: false,
            showMapTypeSelector: false,
            showZoomButtons: false,
            enableClickableLogo: false,
            disableScrollWheelZoom: true
        });

        var infobox = null;

        function addMarker(latitude, longitude, title, description, pid)
        {
            var pushpin = """";

            if (description == ""Normal"") {
                pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(parseFloat(latitude.replace(',', '.')), parseFloat(longitude.replace(',', '.'))), { color: 'green', draggable: true });
            }
            else if (description == ""Alerta"") {
                pushpi");
            WriteLiteral(@"n = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(parseFloat(latitude.replace(',', '.')), parseFloat(longitude.replace(',', '.'))), { color: 'gray', draggable: true });
            }
            else if (description == ""Perigo"") {
                pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(parseFloat(latitude.replace(',', '.')), parseFloat(longitude.replace(',', '.'))), { color: 'blue', draggable: true });
            }
            else if (description == ""Evacua&#xE7;&#xE3;o"") {
                pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(parseFloat(latitude.replace(',', '.')), parseFloat(longitude.replace(',', '.'))), { color: 'red', draggable: true });
            }
            else {
                pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(parseFloat(latitude.replace(',', '.')), parseFloat(longitude.replace(',', '.'))), { color: 'blue', draggable: true });
            }

            infobox = new Microsoft.Maps.Infobox(p");
            WriteLiteral(@"ushpin.getLocation(), {
                visible : false
            });

            pushpin.metadata = {
                id: pid,
                title: title,
                description: description
            };

            Microsoft.Maps.Events.addHandler(pushpin, 'mouseout', hideInfobox);
            Microsoft.Maps.Events.addHandler(pushpin, 'mouseover', showInfobox);

            infobox.setMap(map);
            map.entities.push(pushpin);
            pushpin.setOptions({ enableHoverStyle: true });
        };

        function showInfobox(e) {

            var description = """";

            if (e.target.metadata.description == ""Normal"") {
                description = ['<table><tr><td>Status Barragem:</td><td><b><span style=""color:green"">', e.target.metadata.description, '</span></b></td></tr>'];
            }
            else if (e.target.metadata.description == ""Alerta"") {
                description = ['<table><tr><td>Status Barragem:</td><td><b><span style=""color:gray"">'");
            WriteLiteral(@", e.target.metadata.description, '</span></b></td></tr>'];
            }
            else if (e.target.metadata.description == ""Perigo"") {
                description = ['<table><tr><td>Status Barragem:</td><td><b><span style=""color:blue "">', e.target.metadata.description, '</span></b></td></tr>'];
            }
            else if (e.target.metadata.description == ""Evacua&#xE7;&#xE3;o"") {
                description = ['<table><tr><td>Status Barragem:</td><td><b><span style=""color:red"">', e.target.metadata.description, '</span></b></td></tr>'];
            }
            else {
                description = ['<table><tr><td>Status Barragem:</td><td><b><span style=""color:blue"">', e.target.metadata.description, '</span></b></td></tr>'];
            }

            if (e.target.metadata) {
                infobox.setOptions({
                    location: e.target.getLocation(),
                    title: e.target.metadata.title,
                    description: description.join(''),
            ");
            WriteLiteral("        visible: true\r\n                });\r\n            }\r\n        }\r\n\r\n        function hideInfobox(e) {\r\n            infobox.setOptions({ visible: false });\r\n        }\r\n\r\n");
            EndContext();
#line 134 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
         if (Model.Count > 0)
        {
            foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(5989, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(6007, 11, true);
            WriteLiteral("addMarker(\'");
            EndContext();
            BeginContext(6019, 13, false);
#line 138 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
                        Write(item.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(6032, 4, true);
            WriteLiteral("\', \'");
            EndContext();
            BeginContext(6037, 14, false);
#line 138 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
                                          Write(item.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(6051, 4, true);
            WriteLiteral("\', \'");
            EndContext();
            BeginContext(6056, 9, false);
#line 138 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
                                                             Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(6065, 4, true);
            WriteLiteral("\', \'");
            EndContext();
            BeginContext(6070, 11, false);
#line 138 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
                                                                           Write(item.Status);

#line default
#line hidden
            EndContext();
            BeginContext(6081, 3, true);
            WriteLiteral("\', ");
            EndContext();
            BeginContext(6085, 7, false);
#line 138 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
                                                                                          Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(6092, 4, true);
            WriteLiteral(");\r\n");
            EndContext();
#line 139 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Home\Index.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(6122, 267, true);
            WriteLiteral(@"
        map.setView({
            zoom: 9,
            center: new Microsoft.Maps.Location(-23.542151, -46.309812)
        });
    }
</script>
<script type=""text/javascript"" src=""https://www.bing.com/api/maps/mapcontrol?callback=LoadMap"" async defer></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TCC.PUC.SCA.Model.SpecificEntities.Common.Map>> Html { get; private set; }
    }
}
#pragma warning restore 1591
