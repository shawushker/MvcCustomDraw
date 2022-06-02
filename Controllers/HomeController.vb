Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI
Imports System.Text
Imports System.IO
Imports FastReport
Imports FastReport.Web
Imports FastReport.Utils
Imports FastReport.Export.Pdf
Imports System.Web.UI.WebControls
Imports System.Globalization
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim webReport As WebReport = New WebReport()
        Dim report_path As String = GetReportPath()
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
        dataSet.ReadXml(report_path & "nwind.xml")
        webReport.Report.RegisterData(dataSet, "NorthWind")
        webReport.Report.Load(report_path & "Simple List.frx")
        webReport.Width = Unit.Percentage(100)
        webReport.Height = Unit.Percentage(100)
        webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black
        AddHandler webReport.CustomDraw, AddressOf WebReport_CustomDraw
        webReport.SinglePage = True
        ViewBag.WebReport = webReport
        Return View()
    End Function

    Public Sub WebReport_CustomDraw(ByVal sender As Object, ByVal e As FastReport.Export.Html.CustomDrawEventArgs)
        If TypeOf e.reportObject Is TextObject Then
            Dim format As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
            Dim obj As TextObject = TryCast(e.reportObject, TextObject)
            e.html = String.Format("<div style=""position:absolute;left:{0}px;top:{1}px;width:{2}px;height:{3}px;font-size:{4}pt;"">{5}</div>",
                                   (e.left * e.zoom).ToString(format),
                                   (e.top * e.zoom).ToString(format),
                                   (e.width * e.zoom).ToString(format),
                                   (e.height * e.zoom).ToString(format),
                                   (obj.Font.Size * e.zoom).ToString(format),
                                   obj.Text)
            e.done = True

        End If
    End Sub
    Private Function GetReportPath() As String
        Dim report_path As String = Config.ApplicationFolder

        Using xml As XmlDocument = New XmlDocument()
            xml.Load(report_path & "config.xml")

            For Each item As XmlItem In xml.Root.Items

                If item.Name = "Config" Then

                    For Each configitem As XmlItem In item.Items
                        If configitem.Name = "Reports" Then report_path += configitem.GetProp("Path")
                    Next
                End If
            Next
        End Using

        Return report_path
    End Function
End Class


