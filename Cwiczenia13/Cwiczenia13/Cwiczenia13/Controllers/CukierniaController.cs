using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class CukierniaController : Controller
    {
        private readonly DAL.IDbService _dbService;
        public CukierniaController(DAL.IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpPost("{id}")]
        public IActionResult addOrder(Requests.OrderRequest request, int id)
        {
            return _dbService.AddOrder(request, id);
        }
        [HttpGet("{nazwisko}")]
        public IActionResult showOrders(String nazwisko)
        {
            return _dbService.GetOrders(nazwisko);
        }
        [HttpGet]
        public IActionResult showAllOrders()
        {
            return _dbService.getAllOrders();
        }
    }
}