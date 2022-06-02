<!DOCTYPE html>
<html lang="en">
<head>
    @Imports FastReport.Web
    <meta charset="utf-8" />
    <title>@ViewBag.Title- FastReport .NET MVC Application</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    @Styles.Render("~/Content/css")


    @WebReportGlobals.Scripts()
    @WebReportGlobals.Styles()

</head>
<body>
        <header>
        <div class="content-wrapper">
            <div class="float-left">
                <p class="site-title">@Html.ActionLink("FastReport .NET", "Index", "Home")</p>
            </div>
        </div>
    </header>
    <div id="body">
        @RenderSection("featured", False)
        <section class="content-wrapper main-content clear-fix">
            @RenderBody()
        </section>
    </div>
    <footer>
        <div class="content-wrapper">
            <div class="float-left">
                <p>&copy; @DateTime.Now.Year - Fast Reports</p>
            </div>
        </div>
    </footer>

    
    @RenderSection("scripts", False)
    
</body>
</html>
