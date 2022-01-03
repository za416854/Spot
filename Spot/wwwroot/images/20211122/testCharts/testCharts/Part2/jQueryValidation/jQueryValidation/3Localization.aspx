<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("Postback!");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/messages_zh_TW.js"></script>
    <script>
        $(function () {
            //https://github.com/jquery-validation/jquery-validation/tree/master/src/localization
            $("#form1").validate();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" name="name1" value="" required="" />
            <br />
            <input type="text" name="name2" value="" min="10" max="50" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
