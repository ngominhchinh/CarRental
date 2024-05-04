using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;
public class BaseController : Controller{
    SiteProvider provider = null!;
    protected SiteProvider Provider => provider ??= new SiteProvider();
}