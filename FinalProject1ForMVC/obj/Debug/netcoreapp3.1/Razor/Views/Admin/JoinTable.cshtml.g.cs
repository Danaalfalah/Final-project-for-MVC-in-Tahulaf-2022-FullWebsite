#pragma checksum "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12cc3e9277e4cdbc0a66fd2193a200fe353c0bd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_JoinTable), @"mvc.1.0.view", @"/Views/Admin/JoinTable.cshtml")]
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
#line 1 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\_ViewImports.cshtml"
using FinalProject1ForMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\_ViewImports.cshtml"
using FinalProject1ForMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12cc3e9277e4cdbc0a66fd2193a200fe353c0bd2", @"/Views/Admin/JoinTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c736b0bfe4f540ff251061992f0d1f62a1f18ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_JoinTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FinalProject1ForMVC.Models.JoinTable>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link href=""https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css"" rel=""stylesheet"" />
<link href=""https://cdn.datatables.net/buttons/2.0.0/css/buttons.dataTables.min.css"" rel=""stylesheet"" />

<table class=""table"" id=""T"">
    <thead>
        <tr>
            <th>Customer Name </th>
            <th>Product Name </th>
            <th>Category Name </th>
            <th>Product Price</th>
            <th>Quantity</th>
            <th>Date</th>
            <th>Total Price</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Customer1.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Product1.Productname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Categoryproduct1.Categoryproductname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Product1.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Product1.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Order1.Datefrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
               Write(item.Order1.Totalprice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\JoinTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<script src=""https://code.jquery.com/jquery-3.5.1.js""></script>

<script src=""https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"" defer></script>

<script src=""https://cdn.datatables.net/buttons/2.0.0/js/dataTables.buttons.min.js"" defer></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
<script src=""https://cdn.datatables.net/buttons/2.0.0/js/buttons.html5.min.js"" defer></script>
<script>
    $(document).ready(function () {
        $('#T').DataTable({
            dom: 'Bfrtip',
            buttons: [
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                'pdfHtml5'
            ]
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FinalProject1ForMVC.Models.JoinTable>> Html { get; private set; }
    }
}
#pragma warning restore 1591
