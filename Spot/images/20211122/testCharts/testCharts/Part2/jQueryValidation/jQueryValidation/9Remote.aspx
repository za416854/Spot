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
  <style>
    .error {
      border-color: red;
    }
  </style>
  <script src="Scripts/jquery-3.1.1.min.js"></script>
  <script src="Scripts/jquery.validate.min.js"></script>
  <script src="Scripts/messages_zh_TW.js"></script>
  <script>
    $(function () {
      $("#form1").validate({
        rules: {
          username: {
            required: true,
            remote: "CheckUserName.aspx"
          }
        },
        messages: {
          username: {
            remote: "此帳號已經被註冊",
          },
        }

      });
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      帳號:
      <input type="text" name="username" 
        value="" 
        id="txt1" />
      <asp:Button ID="Button1" runat="server" 
        Text="Button"
         OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
