#pragma checksum "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4beafdb4d0964580ca2c1f2f4630062d65fe75ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RespostasCompleFrases_Delete), @"mvc.1.0.view", @"/Views/RespostasCompleFrases/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RespostasCompleFrases/Delete.cshtml", typeof(AspNetCore.Views_RespostasCompleFrases_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4beafdb4d0964580ca2c1f2f4630062d65fe75ec", @"/Views/RespostasCompleFrases/Delete.cshtml")]
    public class Views_RespostasCompleFrases_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HelloFriendsAPI.Model.RespostasCompleFrase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(95, 190, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>RespostasCompleFrase</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(286, 45, false);
#line 15 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Resultado));

#line default
#line hidden
            EndContext();
            BeginContext(331, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(395, 41, false);
#line 18 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Resultado));

#line default
#line hidden
            EndContext();
            BeginContext(436, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(499, 44, false);
#line 21 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Resposta));

#line default
#line hidden
            EndContext();
            BeginContext(543, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(607, 40, false);
#line 24 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Resposta));

#line default
#line hidden
            EndContext();
            BeginContext(647, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(710, 41, false);
#line 27 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Aluno));

#line default
#line hidden
            EndContext();
            BeginContext(751, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(815, 40, false);
#line 30 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Aluno.Id));

#line default
#line hidden
            EndContext();
            BeginContext(855, 68, true);
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(924, 49, false);
#line 33 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CompletaFrase));

#line default
#line hidden
            EndContext();
            BeginContext(973, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1037, 48, false);
#line 36 "C:\Users\Nataniel\plf-es-2022-1-ti4-0658100-hello-friends\Codigo\BackEnd\HelloFriends\src\HelloFriendsAPI\Views\RespostasCompleFrases\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CompletaFrase.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1085, 260, true);
            WriteLiteral(@"
        </dd class>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""Id"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HelloFriendsAPI.Model.RespostasCompleFrase> Html { get; private set; }
    }
}
#pragma warning restore 1591