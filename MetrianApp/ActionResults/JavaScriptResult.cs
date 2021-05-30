using Microsoft.AspNetCore.Mvc;

namespace MetrianApp.ActionResults
{
  public class JavaScriptResult : ContentResult
  {
    public JavaScriptResult(string script)
    {
      this.Content = script;
      this.ContentType = "application/javascript";
    }
  }
}