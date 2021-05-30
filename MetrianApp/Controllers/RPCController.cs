using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MetrianApp.ActionResults;
using MetrianApp.Core.Services;
using MetrianApp.Core.Models;
using MetrianApp.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace MetrianApp.Controllers
{
  public class RPCController : Controller
  {
    // private readonly UserContext _context;
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public RPCController(ILogger<HomeController> logger, IUserService userService, IMapper mapper)
    {
      // _context = context;
      _logger = logger;
      _userService = userService;
      _mapper = mapper;
    }

    public IActionResult Index()
    {
      var jsonObj = JsonConvert.DeserializeObject<WeatherForecast>("{\"Date\": \"2019-08-01T00:00:00-07:00\",\"TemperatureCelsius\": 25,\"Summary\": \"Hot\"}");
      string jsonStr = JsonConvert.SerializeObject(jsonObj);
      return Json(jsonStr);
    }

    public async Task<IActionResult> FetchUsers()
    {
      var users = await _userService.GetAllUsers();
      var userDTO = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users).ToList();
      var count = userDTO.Count;

      var serializer = new JsonSerializer()
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };

      var response = new JObject(
        new JProperty("response", new JObject(
          new JProperty("status", 0),
          new JProperty("data", JArray.FromObject(users, serializer)),
          new JProperty("startRow", 0),
          new JProperty("endRow", count - 1),
          new JProperty("totalRows", count)
        )));
      return Content(JsonConvert.SerializeObject(response), "application/json");
    }

    public IActionResult FetchView()
    {
      string fileStr = System.IO.File.ReadAllText(@"/Users/swyan/Projects/MetrianApp/MetrianApp/TestData/loadScreen.js");
      return new JavaScriptResult(fileStr);
    }
  }

  public class WeatherForecast
  {
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; }
  }
}