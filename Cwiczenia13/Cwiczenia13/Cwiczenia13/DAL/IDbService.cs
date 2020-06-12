using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia13.DAL
{
    public interface IDbService
    {
        IActionResult GetOrders(string nazwisko);
        IActionResult AddOrder(Requests.OrderRequest request,int id);
        IActionResult getAllOrders();
    }
}
