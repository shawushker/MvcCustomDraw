Imports System.Web.Optimization

Public Module BundleConfig
    ' Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)



        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))
    End Sub
End Module

