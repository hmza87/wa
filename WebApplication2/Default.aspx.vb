Imports RedditSharp.Things

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        

        Dim r As New RedditSharp.Reddit()
        Dim sb = r.GetSubreddit("/r/gifs")

        For Each p As Post In sb.[New].Take(100)
            renderPost(p)



        Next

    End Sub
    Function renderPost(p As Post) As Panel
        Dim img As New Image
        Dim title As New Label
        Dim vid As New HtmlVideo
        Dim pnl As New Panel
        pnl.CssClass = "col-xs-12 col-sm-6 col-md-3 col-lg-2"

        If p.Url.AbsoluteUri.Contains(".gifv") Then

        ElseIf p.Url.AbsoluteUri.Contains(".gif") Then
            Dim x As New HyperLink
            x.Text = p.Author.Name & " [" & p.Author.FullName & "]"
            x.NavigateUrl = p.Url.AbsoluteUri

            img.Attributes("x-data") = p.Url.AbsoluteUri
            img.ImageUrl = p.Url.AbsoluteUri
            title.Text = p.Title
            pnl.Controls.Add(title)
            pnl.Style.Add("height", "auto")
            pnl.Controls.Add(x)
            pnl.Controls.Add(img)
            img.Style.Add("width", "100%")

            Panel1.Controls.Add(pnl)
        End If

    End Function
    Sub clk(sender As Object, e As EventArgs)
        Response.Redirect(CType(sender, Image).Attributes("x-data"))
    End Sub
End Class