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
            required: function (element) {
              return $("#txt2").val() == "";
            }
          },
          name2: {
            email: {
              depends: function () {
                return $("#EDM").is(":checked");
              }
            }
          }
        }
      });
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      帳號:
      <input type="text" name="name1" value="" id="txt1" />
      <br />
      <input type="checkbox" name="EDM" id="EDM" />
      <label for="EDM">訂閱電子報</label>
      <br />
      Email:
            <input type="text" name="name2" value="" id="txt2" />
      <br />
      <asp:Button ID="Button1" runat="server" Text="Button"
        OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
