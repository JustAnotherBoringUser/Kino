using Kino.Data;
using Kino.Data.Models;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Kino.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext context;

        private readonly List<string> platnosci = new List<string>
        {
            "online", "gotówka"
        };

        private readonly Dictionary<string, double> ulgi = new()
        {
            {"normalny", 0},
            {"student", 0.2},
            {"emeryt", 0.2},
            {"dziecko do lat 3", 0.8},
            {"uczeń", 0.3}
        };

        private const double cenaBazowaBiletu = 30;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var seanse = context.Seanse
                .Include(x => x.Film)
                .Include(x => x.Sala)
                .ToList();
            return View(seanse);
        }

        [HttpPost]
        public IActionResult Index(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                var seanse = context.Seanse
                   .Include(x => x.Film)
                   .Include(x => x.Sala)
                   .ToList();
                return View(seanse);
            }
            else
            {
                var seanse = context.Seanse
                 .Include(x => x.Film)
                 .Include(x => x.Sala)
                 .Where(x => x.Film.Tytul.ToLower().Contains(text.ToLower()))
                 .ToList();
                return View(seanse);
            }
        }

        private List<int> GenerujLiczby(int koniec)
        {
            List<int> liczby = new List<int>();
            for (int i = 1; i <= koniec; i++)
            {
                liczby.Add(i);
            }
            return liczby;
        }

        private void DodajInfoSeans(int id)
        {
            var seans = context.Seanse.Include(x => x.Film).Include(x => x.Sala).FirstOrDefault(x => x.IdSeans == id);
            ViewBag.Seans = seans;
            ViewBag.Miejsca = new SelectList(GenerujLiczby(seans.Sala.IloscMiejsc));
            ViewBag.Rzedy = new SelectList(GenerujLiczby(seans.Sala.IloscRzedow));
            ViewBag.Platnosci = new SelectList(platnosci);
            ViewBag.Ulgi = new SelectList(ulgi.Keys.ToList());
        }

        public IActionResult SeansDetails(int id)
        {
            if (!context.Seanse.Any(x => x.IdSeans == id))
            {
                return NotFound();
            }

            DodajInfoSeans(id);
            return View(new ZamowienieViewModel());
        }

        [HttpPost]
        public IActionResult SeansDetails(int id, ZamowienieViewModel model)
        {
            var seans = context.Seanse.FirstOrDefault(x => x.IdSeans == id);
            if (seans == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (CzyMiejsceZajete(seans, model.NrRzedu, model.NrMiejsca))
                {
                    ViewBag.Error = "Podane miejsce jest już zajęte";
                    DodajInfoSeans(id);
                    return View(model);
                }

                var zamowienie = new Zamowienie
                {
                    IdSeans = id,
                    Mail = model.Mail,
                    Imie = model.Imie,
                    Status = "Niepotwierdzone",
                    Platnosc = model.Platnosc,
                    Nazwisko = model.Nazwisko,
                    Ulga = model.Ulga
                };
                context.Add(zamowienie);

                var miejsce = new Miejsce
                {
                    CzyZajete = true,
                    Rzad = model.NrRzedu,
                    Zamowienie = zamowienie,
                    NrMiejsca = model.NrMiejsca
                };
                context.Add(miejsce);

                context.SaveChanges();
                return RedirectToAction("Podsumowanie", new { guid = zamowienie.Guid });
            }

            DodajInfoSeans(id);
            return View(model);
        }

        public IActionResult Podsumowanie(Guid guid)
        {
            var zamowienie = context
                .Zamowienia
                .Include(x => x.Seans)
                .ThenInclude(x => x.Film)
                .FirstOrDefault(x => x.Guid == guid);
            if (zamowienie == null)
            {
                return NotFound();
            }
            var miejsce = context.Miejsca.FirstOrDefault(x => x.IdZamowienie == zamowienie.IdZamowienie);
            ViewBag.Miejsce = miejsce;
            ViewBag.Cena = Math.Round(cenaBazowaBiletu * (1 - ulgi[zamowienie.Ulga]), 2);
            return View(zamowienie);
        }

        public IActionResult Potwierdzenie(Guid guid)
        {
            var zamowienie = context.Zamowienia.FirstOrDefault(x => x.Guid == guid);
            if (zamowienie == null)
            {
                return NotFound();
            }
            if (zamowienie.Platnosc == "online")
            {
                zamowienie.Status = "Potwierdzone, opłacone";
            }
            else
            {
                zamowienie.Status = "Potwierdzone, do opłacenia w kasie";
            }
            context.SaveChanges();
            return RedirectToAction("Podsumowanie", new { guid = zamowienie.Guid });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Popularne()
        {
            WebClient webClient = new WebClient();
            var pageNr = new Random().Next(1, 11);
            string data = webClient.DownloadString($"https://api.themoviedb.org/3/movie/popular?api_key=a84909a3156caf84337832e7fe15e20c&page={pageNr}");
            var movies = JsonSerializer.Deserialize<FilmyViewModel>(data);
            return View(movies);
        }

        private bool CzyMiejsceZajete(Seans seans, int nrRzedu, int nrMiejsca)
        {
            return context.Miejsca
                .Include(x => x.Zamowienie)
                .Any(miejsce => miejsce.Zamowienie.IdSeans == seans.IdSeans
                && miejsce.Rzad == nrRzedu && miejsce.NrMiejsca == nrMiejsca);
        }
    }
}