#pragma checksum "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac7a84578e2df6f439f0559396b85396f556dc4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Barragem_List), @"mvc.1.0.view", @"/Views/Barragem/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Barragem/List.cshtml", typeof(AspNetCore.Views_Barragem_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac7a84578e2df6f439f0559396b85396f556dc4f", @"/Views/Barragem/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d0afe29c125f52ee8b3512eab6f35200cad2f76", @"/Views/_ViewImports.cshtml")]
    public class Views_Barragem_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TCC.PUC.SCA.Model.DBEntities.Barragem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(148, 131, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <h5>Lista Barragens</h5>\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(279, 163, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac7a84578e2df6f439f0559396b85396f556dc4f4355", async() => {
                BeginContext(338, 100, true);
                WriteLiteral("\r\n            <i class=\"fas fa-user-plus\"></i>\r\n            <span class=\"bold\">Novo</span>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(442, 211, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th class=\"\">\r\n                        ");
            EndContext();
            BeginContext(654, 40, false);
#line 26 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(694, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(794, 44, false);
#line 29 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.Situacao));

#line default
#line hidden
            EndContext();
            BeginContext(838, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(938, 48, false);
#line 32 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(986, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(1086, 49, false);
#line 35 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1135, 188, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\" style=\"min-width:162px;width:162px;\">Ações</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 41 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1388, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1473, 39, false);
#line 45 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1512, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(1624, 43, false);
#line 48 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Situacao));

#line default
#line hidden
            EndContext();
            BeginContext(1667, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(1779, 47, false);
#line 51 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(1826, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(1938, 48, false);
#line 54 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1986, 113, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2099, "\"", 2147, 1);
#line 57 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
WriteAttributeValue("", 2106, Url.Action("Edit", new { id = item.Id }), 2106, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2148, 269, true);
            WriteLiteral(@" class=""btn btn-sm btn-light"" title=""Editar"">
                                <i class=""fas fa-edit""></i>
                                <span class=""bold"">Editar</span>
                            </a>
                            |
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2417, "\"", 2467, 1);
#line 62 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
WriteAttributeValue("", 2424, Url.Action("Delete", new { id = item.Id }), 2424, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2468, 273, true);
            WriteLiteral(@" class=""btn btn-sm btn-light"" title=""Excluir"">
                                <i class=""fas fa-trash-alt""></i>
                                <span class=""bold"">Excluir</span>
                            </a>
                        </td>
                    </tr>
");
            EndContext();
#line 68 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Barragem\List.cshtml"
                }

#line default
#line hidden
            BeginContext(2760, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TCC.PUC.SCA.Model.DBEntities.Barragem>> Html { get; private set; }
    }
}
#pragma warning restore 1591