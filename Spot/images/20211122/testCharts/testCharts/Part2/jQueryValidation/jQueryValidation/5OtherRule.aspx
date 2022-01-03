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
          name1: {
            email: true,
          },
          name2: {
            min: 20,
            max: 80,
          },
          name3: {
            minlength: 5,
            maxlength: 10
          },
          name4: {
            equalTo: "#txt3"
          },
          name5: {
            minlength: 5,
            digits: true
          }
        }
      });
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      Email:<input type="text" name="name1" value="" id="txt1" />
      <br />
      Age<input type="text" name="name2" value="" id="txt2" />
      <br />
      Password<input type="text" name="name3" value="" id="txt3" />
      <br />
      ConfirmPassword<input type="text" name="name4" value="" id="txt4" />
      <br />
      PhoneNumber<input type="text" name="name5" value="" id="txt5" />
      <br />
      <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
