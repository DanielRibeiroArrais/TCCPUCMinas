#pragma checksum "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57856284c588431326dbaf7fefc7eb3dd913742a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pessoa_List), @"mvc.1.0.view", @"/Views/Pessoa/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pessoa/List.cshtml", typeof(AspNetCore.Views_Pessoa_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57856284c588431326dbaf7fefc7eb3dd913742a", @"/Views/Pessoa/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d0afe29c125f52ee8b3512eab6f35200cad2f76", @"/Views/_ViewImports.cshtml")]
    public class Views_Pessoa_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TCC.PUC.SCA.Model.DBEntities.Pessoa>>
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
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

    var lBarragens = (List<TCC.PUC.SCA.Model.DBEntities.Barragem>)ViewBag.Barragens;

#line default
#line hidden
            BeginContext(234, 129, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <h5>Lista Pessoas</h5>\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(363, 163, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57856284c588431326dbaf7fefc7eb3dd913742a4423", async() => {
                BeginContext(422, 100, true);
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
            BeginContext(526, 211, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th class=\"\">\r\n                        ");
            EndContext();
            BeginContext(738, 40, false);
#line 28 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(778, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(878, 46, false);
#line 31 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.BarragemId));

#line default
#line hidden
            EndContext();
            BeginContext(924, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(1024, 44, false);
#line 34 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.Situacao));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(1168, 48, false);
#line 37 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(1216, 99, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\">\r\n                        ");
            EndContext();
            BeginContext(1316, 49, false);
#line 40 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1365, 188, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"text-center\" style=\"min-width:162px;width:162px;\">Ações</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 46 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1618, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1703, 39, false);
#line 50 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1742, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(1854, 82, false);
#line 53 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                       Write(Html.DisplayFor(modelItem => lBarragens.Find(x => x.Id == (item.BarragemId)).Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1936, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(2048, 43, false);
#line 56 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Situacao));

#line default
#line hidden
            EndContext();
            BeginContext(2091, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(2203, 47, false);
#line 59 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(2250, 111, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
            EndContext();
            BeginContext(2362, 48, false);
#line 62 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(2410, 113, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2523, "\"", 2571, 1);
#line 65 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
WriteAttributeValue("", 2530, Url.Action("Edit", new { id = item.Id }), 2530, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2572, 269, true);
            WriteLiteral(@" class=""btn btn-sm btn-light"" title=""Editar"">
                                <i class=""fas fa-edit""></i>
                                <span class=""bold"">Editar</span>
                            </a>
                            |
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2841, "\"", 2891, 1);
#line 70 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
WriteAttributeValue("", 2848, Url.Action("Delete", new { id = item.Id }), 2848, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2892, 273, true);
            WriteLiteral(@" class=""btn btn-sm btn-light"" title=""Excluir"">
                                <i class=""fas fa-trash-alt""></i>
                                <span class=""bold"">Excluir</span>
                            </a>
                        </td>
                    </tr>
");
            EndContext();
#line 76 "C:\Projetos\Pessoal\TCC.PUC.SCA\TCC.PUC.SCA.Front\Views\Pessoa\List.cshtml"
                }

#line default
#line hidden
            BeginContext(3184, 58, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TCC.PUC.SCA.Model.DBEntities.Pessoa>> Html { get; private set; }
    }
}
#pragma warning restore 1591
