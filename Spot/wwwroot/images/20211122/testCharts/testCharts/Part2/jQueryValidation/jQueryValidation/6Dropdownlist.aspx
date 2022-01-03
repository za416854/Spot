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
      color: red;
    }
  </style>
  <script src="Scripts/jquery-3.1.1.min.js"></script>
  <script src="Scripts/jquery.validate.min.js"></script>
  <script src="Scripts/messages_zh_TW.js"></script>
  <script>
    $(function () {
      $("#form1").validate({
        rules: {
          ddlNationality: "required",
          gender: "required",
          color: {
            minlength: 2,                     
          }
        },
        messages: {
          ddlNationality: {
            required: "不可為'未選擇'",
          },
          color: {
            minlength: "至少選兩個"
          }
        }
      });
    });
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <label for="ddlNationality" id="lblNationality">居住地</label>
      <select name="ddlNationality" id="ddlNationality">
        <option value="">未選擇 </option>
        <option value="北部">北部</option>
        <option value="中部">中部</option>
        <option value="南部">南部</option>
      </select>
      <br />
      <label for="gender_male">
        <input type="radio" id="gender_male" 
          value="m" name="gender" />
        Male
      </label>
      <label for="gender_female">
        <input type="radio" id="gender_female" 
          value="f" name="gender" />
        Female
      </label>
      <label for="gender" class="error"></label>
      <br />
      <div id="tex">Color:</div>
      <input type="checkbox" name="color" 
        id="color1" />
      <label for="color1">red</label>
      <input type="checkbox" name="color" 
        id="color2" />
      <label for="color2">blue</label>
      <input type="checkbox" name="color" 
        id="color3" />
      <label for="color3">green</label>
      <label for="color" class="error"></label>
      <br />
      <asp:Button ID="Button1" runat="server" 
        Text="Button" OnClick="Button1_Click" />
    </div>
  </form>
</body>
</html>
