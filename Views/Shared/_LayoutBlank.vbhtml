﻿<!DOCTYPE html>
<html lang="en">
<head>
    @Imports FastReport.Web
    <meta charset="utf-8" />
    <title>@ViewBag.Title - FastReport .NET MVC Application</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    @WebReportGlobals.Scripts()
    @WebReportGlobals.Styles()
</head>
<body>
    @RenderBody()
</body>
</html>
