<%@ Application Language="C#" %>

<script runat="server">
    protected void Session_Start(Object sender, EventArgs e) 
    {
        Session["init"] = 0;
    }
</script>