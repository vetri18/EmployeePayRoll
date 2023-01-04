#pragma checksum "C:\Users\91888\Desktop\MVC\EmployeePayrollMVC\EmployeePayrollMVC\Views\Employee\Index1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44bfaefb89eace94c4664cec7a4add3b12e10a7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index1), @"mvc.1.0.view", @"/Views/Employee/Index1.cshtml")]
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
#line 1 "C:\Users\91888\Desktop\MVC\EmployeePayrollMVC\EmployeePayrollMVC\Views\_ViewImports.cshtml"
using EmployeePayrollMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\91888\Desktop\MVC\EmployeePayrollMVC\EmployeePayrollMVC\Views\_ViewImports.cshtml"
using EmployeePayrollMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44bfaefb89eace94c4664cec7a4add3b12e10a7e", @"/Views/Employee/Index1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d73f3435e67e8cf4278931b56a96269ce86d340", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Employee_Index1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.13.1/css/jquery.dataTables.css\">\r\n<h1>Index</h1>\r\n<a href=\"#\" onclick=\"createnew(); return false;\" class=\"btn-primary\">Add New</a>\r\n");
#nullable restore
#line 4 "C:\Users\91888\Desktop\MVC\EmployeePayrollMVC\EmployeePayrollMVC\Views\Employee\Index1.cshtml"
Write(Html.Partial("~/Views/Shared/_employee.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table id=""tblemployee"" class=""table table-bordered"">
    <thead>
        <tr>
            <th>emp_id</th>
            <th>NAME</th>
            <th>GENDER</th>
            <th>DEPARTMENT</th>
            <th>SALARY</th>
            <th>START_DATE</th>
            <th>NOTES</th>
            <th>IMG</th>
        </tr>
    </thead>
    <tbody id=""table-data"">
    </tbody>

</table>

<script type=""text/javascript"" src=""https://code.jquery.com/jquery-3.6.3.min.js""></script>
<script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.13.1/js/jquery.dataTables.js""></script>

<script type=""text/javascript"">
    var js=jQuery.noConflict(true);
    js(document).ready(function () {
        //alert();
        Loademployee();
    });
    function createnew()  {
        clearall();
        $('#btnmodel').trigger('click');
    }
    function clearall(){
        $('#txtemp_id').val('');
        $('#txtNAME').val('');
        $('#txtGENDER').val('');
        $('#txtDEP");
            WriteLiteral(@"ARTMENT').val('');
        $('#txtSALARY').val('');
        $('#txtSTART_DATE').val('');
        $('#txtNOTES').val('');
        $('#txtIMG').val('');
    }
 
    function create(){
        //debugger
        var isproceed=true; 
      var emp_id=  $('#txtemp_id').val();
      var NAME=  $('#txtNAME').val();
        var GENDER = $('#txtGENDER').val();
        var DEPARTMENT = $('#txtDEPARTMENT').val();
        var SALARY = $('#txtSALARY').val();
        var START_DATE = $('#txtSTART_DATE').val();
        var NOTES= $('#txtNOTES').val();
        var IMG = $('#txtIMG').val();
        if (NAME==''){
            isproceed=false;
            $('#txtNAME').css('border-color','red');
        }
        else{
            $('#txtNAME').css('border-color', '#ccc');
        }
            if(isproceed){
                var empdata=new Object();
                empdata.emp_id=emp_id;
                empdata.NAME=NAME;
                empdata.GENDER = GENDER;
                empdata.DEPARTMENT ");
            WriteLiteral(@"= DEPARTMENT;
                empdata.SALARY = SALARY;
                empdata.START_DATE = START_DATE;
                empdata.NOTES = NOTES;
                empdata.IMG = IMG;
                $.ajax({
                    type:'post',
                    url:'Createjson',
                    data:empdata,
                    success(data){
                        if(data!=null)
                        {
                            alert('saved sucessfuly')
                        }
                        else{
                            alert('failed')
                        }
                        
                    }
                });
            }   
    }
    function Loademployee() 
    {
        var empdata = [];
        $.ajax({
            type: 'post',
            url: 'GetAll',
            data: {},
            async:false,
            success(data){
                if (data != null) {
                 $.each(data, function (key, value) {
                  ");
            WriteLiteral(@"   empdata.push([
                            value.emp_id, value.NAME, value.GENDER, value.DEPARTMENT, value.SALARY,
                            value.START_DATE, value.NOTES, value.IMG]);
                 });
                }
            },
            error()
            {
            }
        });
        
                 js('#tblemployee').dataTable({
                 destroy:true,
                 data:empdata
                 });            
    }
    
</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
