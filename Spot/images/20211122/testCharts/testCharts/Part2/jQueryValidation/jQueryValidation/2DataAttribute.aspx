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
  <script>
    $(function () {
      $("#form1").validate();
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <input type="text" name="name1" value="" 
        required="" 
        data-msg="該欄位必填" />
      <br />
      <input type="text" name="name2" value="" 
        min="10" max="50" 
        data-msg="請輸入10-50之間的數字" />
      <br />
      <asp:Button ID="Button1" runat="server" 
        Text="Button" OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
