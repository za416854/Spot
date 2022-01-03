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
      $.validator.addMethod("myIDCheck",
         function (value, element) {
           return /^[A-Za-z]{1}[0-9]{9}$/.test(value);
         },
         "身分證字號不正確");

      $("#form1").validate({
        rules: {
          myID: {
            myIDCheck: true
          }
        }
      });
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      身分證:
      <input type="text" name="myID" value="" id="myID" />
      <br />
      <asp:Button ID="Button1" runat="server" Text="Button" 
        OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
