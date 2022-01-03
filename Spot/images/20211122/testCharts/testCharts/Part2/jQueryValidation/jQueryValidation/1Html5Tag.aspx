<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

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
      <input type="text" name="name1" value="" required="" />
      <br />
      <input type="text" name="name2" value="" min="10" max="50" />
      <br />
      <asp:Button Text="submit" runat="server" />
    </div>
  </form>
</body>
</html>
