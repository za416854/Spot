<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
      string[] nameAry = { "Tony", "Bob", "Vivid", "Jerry" };
      var user = Request.Params["username"];
      if (nameAry.SingleOrDefault(name => name.ToUpper() == user.ToUpper()) != null)
      {
        Response.Write("false");
      }
      else
      {
        Response.Write("true");
      }
    }
</script>
