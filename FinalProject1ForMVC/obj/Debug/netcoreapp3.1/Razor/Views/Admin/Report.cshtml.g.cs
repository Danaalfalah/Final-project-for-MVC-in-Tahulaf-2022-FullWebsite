#pragma checksum "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73c1a0aac24c67cc2cec65b94d7eac826fbe4370"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Report), @"mvc.1.0.view", @"/Views/Admin/Report.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73c1a0aac24c67cc2cec65b94d7eac826fbe4370", @"/Views/Admin/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c736b0bfe4f540ff251061992f0d1f62a1f18ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<IEnumerable<FinalProject1ForMVC.Models.JoinTable>, IEnumerable<FinalProject1ForMVC.Models.Order1>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link href=""https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css"" rel=""stylesheet"" />
<link href=""https://cdn.datatables.net/buttons/2.0.0/css/buttons.dataTables.min.css"" rel=""stylesheet"" />

<div class=""p-3 mb-2 bg-secondary text-white"">Search</div>
<br />

");
            WriteLiteral(@"

<table class=""T table"">
    <thead>
        <tr>

            <th>
                Product Name
            </th>
            <th>
                Quantity
            </th>
            <th>
                Price
            </th>
            <th>
                Total price
            </th>
            <th>date</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 39 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
         foreach (var item in Model.Item2)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(Html.DisplayFor(modelItem => item.Orderitem.Product.Productname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(Html.DisplayFor(modelItem => item.Orderitem.Product.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(Html.DisplayFor(modelItem => item.Orderitem.Quantityitem));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n");
            WriteLiteral("                ");
#nullable restore
#line 57 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(ViewBag.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td> ");
#nullable restore
#line 59 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
            Write(Html.DisplayFor(modelItem => item.Datefrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 62 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td>Total Quantity</td>\r\n            <td>");
#nullable restore
#line 67 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(ViewBag.TotalQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Total Price</td>\r\n            <td>");
#nullable restore
#line 74 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
           Write(ViewBag.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </tfoot>
</table>




<br />
<div class=""p-3 mb-2 bg-secondary text-white"">Join Tables</div>
<br />

<table class=""T table"">
    <thead>
        <tr>
            <th>Customer Name </th>
            <th>Product Name </th>
            <th>Category Name </th>
            <th>Product Price</th>
            <th>Quantity</th>
            <th>Date</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 101 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
         foreach (var item in Model.Item1)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 105 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Customer1.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 106 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Product1.Productname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 107 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Categorystore1.Categoryname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 108 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Product1.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 109 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Orderitem1.Quantityitem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 110 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
               Write(item.Order1.Datefrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 112 "C:\Users\DANA\source\repos\FinalProject1ForMVC\FinalProject1ForMVC\Views\Admin\Report.cshtml"
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
        $('.T').DataTable({
            dom: 'Bfrtip',
            buttons: [
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                'pdfHtml5'
            ]
        });
    });
</script>

<script>
    $(document).ready(function () {
        $('.T').D");
            WriteLiteral("ataTable({\r\n            dom: \'Bfrtip\',\r\n            buttons: [\r\n                \'copyHtml5\',\r\n                \'excelHtml5\',\r\n                \'csvHtml5\',\r\n                \'pdfHtml5\'\r\n            ]\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<IEnumerable<FinalProject1ForMVC.Models.JoinTable>, IEnumerable<FinalProject1ForMVC.Models.Order1>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
