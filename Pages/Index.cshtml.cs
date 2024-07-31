using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace dotnetcoresample.Pages;

public class IndexModel : PageModel
{

    public string OSVersion { get { return RuntimeInformation.OSDescription; }  }
    public string Dmz { get; set; }
    public string Internal { get; set; }
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        try
        {

        
        Dmz = await new HttpClient().GetStringAsync(
            "https://testapp.redbeach-90483548.westeurope.azurecontainerapps.io");
        }
        catch (Exception e)
        {
            Dmz = e.ToString();
        }
        
        try
        {

        
            DmzInternal = await new HttpClient().GetStringAsync(
                "https://testapp.internal.redbeach-90483548.westeurope.azurecontainerapps.io");
        }
        catch (Exception e)
        {
            DmzInternal = e.ToString();
        }

        try
        {
            Internal= await new HttpClient().GetStringAsync(
                "https://testapp1.blackgrass-bff0087b.westeurope.azurecontainerapps.io");
        }
        catch (Exception e)
        {
            Internal = e.ToString();
        }

        try
        {
            ExternalIp = await new HttpClient().GetStringAsync("https://ifconfig.me/ip");
        }
        catch (Exception e)
        {
            this.ExternalIp= e.ToString();
            
        }
       
        
    }

    public string DmzInternal { get; set; }

    public string ExternalIp { get; set; }
}
