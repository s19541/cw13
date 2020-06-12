using Cwiczenia13.Models;
using Cwiczenia13.Requests;
using Cwiczenia13.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Cwiczenia13.DAL
{
    public class EfDbService : IDbService
    {
        public CukierniaDbContext Context { get; set; }
        public EfDbService(CukierniaDbContext dbContext)
        {
            Context = dbContext;
        }
       
       
        public IActionResult GetOrders(string nazwisko)
        {
            var clientId = Context.Clients.Where(a => a.Nazwisko == nazwisko).Select(a => a.IdKlient).FirstOrDefault();
            if (clientId == 0)
                return new BadRequestObjectResult("Nie ma klienta o podanym nazwisku: "+nazwisko);
            List<ProductResponse> wyroby = new List<ProductResponse>();
            var orderIds = Context.Orders.Where(o => o.IdKlient == clientId).Select(o => o.IdZamowienia).ToList();
            foreach(int orderId in orderIds)
            {
                var productIds = Context.OrdersProducts.Where(o => o.IdZamowienia == orderId).Select(o=>o.IdWyrobuCukierniczego).ToList();
                foreach(int productId in productIds)
                {
                    var wyrob = new ProductResponse()
                    {
                        Nazwa = Context.Products.Where(p => p.IdWyrobuCukierniczego == productId).Select(p => p.Nazwa).FirstOrDefault(),
                        Rodzaj = Context.Products.Where(p => p.IdWyrobuCukierniczego == productId).Select(p => p.Typ).FirstOrDefault(),
                        Ilosc = Context.OrdersProducts.Where(p => p.IdWyrobuCukierniczego == productId && p.IdWyrobuCukierniczego == orderId).Select(p => p.Ilosc).FirstOrDefault()
                    };
                    wyroby.Add(wyrob);
                }
            }
            return new OkObjectResult(wyroby);
        }
        

        public IActionResult AddOrder(OrderRequest request,int id)
        {
            if (request.Wyroby.Count() == 0)
                return new BadRequestObjectResult("Nie podano żadnego wyrobu");
            var zamowienie = new Zamowienie
            {
                
                DataPrzyjecia = request.DataPrzyjecia,
                Uwagi = request.Uwagi,
                IdKlient = id,
                IdPracownik = 1
            };
            Context.Orders.Add(zamowienie);
            foreach (WyrobRequest wyrob in request.Wyroby)
            {
                var productId = Context.Products.Where(k => k.Nazwa == wyrob.Wyrob).Select(k => k.IdWyrobuCukierniczego).FirstOrDefault();
                if (productId == 0)
                    return new BadRequestObjectResult("Jeden z podanych wyrobow nie jest w bazie");
                var zamowienieWyrob = new Zamowienie_WyrobCukierniczy
                {
                    IdWyrobuCukierniczego = productId,
                    IdZamowienia = zamowienie.IdZamowienia,
                    Ilosc = wyrob.Ilosc,
                    Uwagi = wyrob.Uwagi
                };
                Context.OrdersProducts.Add(zamowienieWyrob);
            }
            Context.SaveChanges();

            return new OkResult();
        }

        public IActionResult getAllOrders()
        {
            List<ProductResponse> wyroby = new List<ProductResponse>();
            var orderIds = Context.Orders.Select(o => o.IdZamowienia).ToList();
            foreach (int orderId in orderIds)
            {
                var productIds = Context.OrdersProducts.Where(o => o.IdZamowienia == orderId).Select(o => o.IdWyrobuCukierniczego).ToList();
                foreach (int productId in productIds)
                {
                    var wyrob = new ProductResponse()
                    {
                        Nazwa = Context.Products.Where(p => p.IdWyrobuCukierniczego == productId).Select(p => p.Nazwa).FirstOrDefault(),
                        Rodzaj = Context.Products.Where(p => p.IdWyrobuCukierniczego == productId).Select(p => p.Typ).FirstOrDefault(),
                        Ilosc = Context.OrdersProducts.Where(p => p.IdWyrobuCukierniczego == productId && p.IdWyrobuCukierniczego == orderId).Select(p => p.Ilosc).FirstOrDefault()
                    };
                    wyroby.Add(wyrob);
                }
            }
            return new OkObjectResult(wyroby);
        }
    }
}
