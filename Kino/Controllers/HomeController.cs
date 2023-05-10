using Kino.Data;
using Kino.Data.Models;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
///<summary>
///strona domowa, zawierająca metody, które są powiązane z widokami
///za pomoca zmiennej context moge wyszukiwac w bazie
/// </summary>
namespace Kino.Controllers //strona domowa, zawierająca metody, które są powiązane z widokami
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext context; //za pomoca zmiennej context moge wyszukiwac w bazie
        /// <summary>
        /// lista z mozliwosciami odnosnie platnosci
        /// </summary>
        private readonly List<string> platnosci = new List<string> //lista z mozliwosciami odnosnie platnosci
        {
            "online", "gotówka"
        };
        /// <summary>
        /// Slownik do odczytu zwiazany z wybierana ulga
        ///  Jest to zbiór par klucz-wartość, gdzie kluczem jest ciąg znaków reprezentujący określony rodzaj rabatu, a wartością jest podwójny reprezentujący mnożnik powiązany z tym rabatem
        /// </summary>
        private readonly Dictionary<string, double> ulgi = new() 
        {
            {"normalny", 0},
            {"student", 0.2},
            {"emeryt", 0.2},
            {"dziecko do lat 3", 0.8},
            {"uczeń", 0.3}
        };
        /// <summary>
        ///  private: Oznacza to, że stała wartość jest polem instancji prywatnej i nie można uzyskać do niej dostępu poza klasą, do której należy.
        ///const: To słowo kluczowe wskazuje, że wartość pola jest stałą i nie można jej modyfikować po jej przypisaniu.
        ///double: Wskazuje typ danych wartości stałej.Jest to liczba zmiennoprzecinkowa podwójnej precyzji.
        ///cenaBazowaBiletu: To jest nazwa pola stałych. = 30: To przypisuje wartość 30 do pola stałej. Ogólnie rzecz biorąc, ten kod definiuje stałą wartość, która reprezentuje cenę bazową biletu.
        ///Ponieważ wartość jest oznaczona jako const, nie można jej zmienić w czasie wykonywania.
        /// </summary>
        private const double cenaBazowaBiletu = 30;
        /// <summary>
        /// ASP tworzy kontroler, tworzy DataContext, dodaje do data context przez konstruktor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public HomeController(ILogger<HomeController> logger, DataContext context) //ASP tworzy kontroler, tworzy DataContext, dodaje do data context przez konstruktor
        {
            _logger = logger;
            this.context = context;
        }
        /// <summary>
        /// zaladowanie seansow do widoku html
        /// Jest to metoda o nazwie Index, która zwraca IActionResult. Wykorzystuje Entity Framework Core do pobierania listy obiektów Seans z bazy danych i zawiera powiązane obiekty Film i Sala 
        /// dla każdego Seana. 
        /// Następnie metoda przekazuje tę listę obiektów Seans do widoku o nazwie „Indeks”.
        /// </summary>
        /// <returns>Zwraca widok o nazwie „Indeks” i przekazuje listę obiektów seanse jako parametr do widoku. Metoda View() jest metodą ASP.NET Core, która tworzy obiekt ViewResult i określa 
        /// widok do renderowania.</returns>
        public IActionResult Index() 
        {
            var seanse = context.Seanse
                .Include(x => x.Film)
                .Include(x => x.Sala)
                .ToList();
            return View(seanse);
        }
        /// <summary>
        /// Jest to metoda o nazwie Index, która akceptuje żądanie HTTP POST z parametrem ciągu o nazwie text. Wykorzystuje Entity Framework Core do pobierania listy obiektów Seans z bazy danych na podstawie parametru text. Jeśli parametr tekstowy ma wartość NULL lub jest pusty, pobiera wszystkie obiekty Seans z bazy danych. Następnie metoda przekazuje listę obiektów Seans do widoku o nazwie „Indeks”.

        /// </summary>
        /// <param name="text"></param>
        /// <returns> Zwraca widok o nazwie „Indeks” pod warunkami i przekazuje listę obiektów seanse jako parametr do widoku.</returns>
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
        /// <summary>
        /// Jest to metoda o nazwie GenerujLiczby, która przyjmuje parametr końca w postaci liczby całkowitej i zwraca List<int>. Celem metody jest wygenerowanie listy liczb całkowitych od 1 do końca w celu wyborów miejsc.
        /// </summary>
        /// <param name="koniec"> private List<int> GenerujLiczby(int koniec): Jest to sygnatura metody, która określa, że metoda jest prywatna, zwraca List<int> i akceptuje parametr całkowity o nazwie koniec.
        ///List<int> liczby = new List<int>() Tworzy to pustą listę liczb całkowitych o nazwie liczba.
        ///for (int i = 1; i <= koniec; i++) To jest pętla for, która zaczyna się od 1 i iteruje aż do końca.
        ///liczba.Add(i) Dodaje bieżącą wartość i do listy liczby.</param>
        /// <returns>Zwraca listę liczb całkowitych.</returns>
        private List<int> GenerujLiczby(int koniec) 
        {
            List<int> liczby = new List<int>();
            for (int i = 1; i <= koniec; i++)
            {
                liczby.Add(i);
            }
            return liczby;
        }
        /// <summary>
        /// Jest to metoda o nazwie DodajInfoSeans, która przyjmuje identyfikator parametru liczby całkowitej i nic nie zwraca. Celem metody jest dodanie informacji o konkretnym screeningu do ViewBag, który jest obiektem służącym do przekazywania danych z kontrolera do widoku w ASP.NET MVC.
        /// var seans = context.Seanse.Include(x => x.Film).Include(x => x.Sala).FirstOrDefault(x => x.IdSeans == id); bazy danych i chętnie ładuje skojarzone z nią podmioty Film i Sala. Metoda FirstOrDefault służy do pobierania pierwszego badania przesiewowego, które pasuje do określonego identyfikatora, lub null, jeśli nie zostanie znalezione takie badanie przesiewowe.
        ///ViewBag.Seans = seans;: Dodaje pobrany screening do ViewBag z kluczem Seans.Dzięki temu widok ma dostęp do danych przesiewowych i wyświetla je.
        ///ViewBag.Miejsca = new SelectList(GenerujLiczby(seans.Sala.IloscMiejsc));: Tworzy to SelectList liczb całkowitych od 1 do liczby miejsc w sali kinowej i dodaje ją do ViewBag za pomocą klawisza Miejsca.Dzięki temu widok może wyświetlać rozwijaną listę numerów miejsc do wyboru przez użytkownika.
        ///ViewBag.Rzedy = new SelectList(GenerujLiczby(seans.Sala.IloscRzedow));: Tworzy to SelectList liczb całkowitych od 1 do liczby rzędów w sali projekcyjnej i dodaje ją do ViewBag za pomocą klucza Rzedy.Dzięki temu widok może wyświetlać rozwijaną listę numerów wierszy do wyboru przez użytkownika.
        ///ViewBag.Platnosci = new SelectList(platnosci);: Tworzy SelectList opcji płatności i dodaje ją do ViewBag z kluczem Platnosci.Dzięki temu widok może wyświetlać rozwijaną listę opcji płatności do wyboru przez użytkownika.
        ///ViewBag.Ulgi = new SelectList(ulgi.Keys.ToList());: To tworzy SelectList dostępnych rabatów i dodaje ją do ViewBag za pomocą klucza Ulgi.Dzięki temu widok może wyświetlać rozwijaną listę dostępnych rabatów do wyboru przez użytkownika.Obiekt ulgi jest prywatnym słownikiem rabatów, który odwzorowuje nazwy rabatów na odpowiadające im mnożniki.
        /// </summary>
        /// <param name="id"></param>
        private void DodajInfoSeans(int id) //funkcja odnosnie informacji o seansie
        {
            var seans = context.Seanse.Include(x => x.Film).Include(x => x.Sala).FirstOrDefault(x => x.IdSeans == id);
            ViewBag.Seans = seans;
            ViewBag.Miejsca = new SelectList(GenerujLiczby(seans.Sala.IloscMiejsc));
            ViewBag.Rzedy = new SelectList(GenerujLiczby(seans.Sala.IloscRzedow));
            ViewBag.Platnosci = new SelectList(platnosci); //wybor platnosci
            ViewBag.Ulgi = new SelectList(ulgi.Keys.ToList()); //wybor ulgi
        }
        /// <summary>
        /// Jest to metoda o nazwie SeansDetails, która przyjmuje identyfikator parametru liczby całkowitej i zwraca wartość IActionResult. Celem metody jest wyświetlenie szczegółów konkretnego 
        /// seansu oraz umożliwienie użytkownikowi złożenia zamówienia.

        /// </summary>
        /// <param name="id"></param>
        /// <returns>Zwraca widok o nazwie SeansDetails z pustym ZamowienieViewModel. Celem tego widoku jest umożliwienie użytkownikowi wyboru liczby miejsc oraz zastosowania ewentualnych 
        /// zniżek lub opcji płatności. Gdy użytkownik przesyła formularz, ZamowienieViewModel jest wypełniany wybranymi opcjami i przekazywany do metody akcji ZlozZamowienie w celu sfinalizowania zamówienia.</returns>
        public IActionResult SeansDetails(int id)
        {
            if (!context.Seanse.Any(x => x.IdSeans == id)) 
            {
                return NotFound();
            }

            DodajInfoSeans(id);
            return View(new ZamowienieViewModel());
        }
        /// <summary>
        /// Jest to metoda C# o nazwie SeansDetails z atrybutem HTTP POST, która przyjmuje dwa parametry: id typu integer oraz obiekt ZamowienieViewModel o nazwie model. Celem metody jest obsługa przesyłania formularza, gdy użytkownik składa zamówienie na bilety.
        ///  var seans = context.Seanse.FirstOrDefault(x => x.IdSeans == id);: Pobiera z bazy danych screening o określonym identyfikatorze.
        ///if (seans == null): sprawdza, czy obiekt seans ma wartość null, co wskazuje, że żądane sprawdzanie nie istnieje w bazie danych.Jeśli ma wartość null, metoda zwraca wynik NotFound.
        ///if (ModelState.IsValid): Sprawdza, czy dane formularza w modelu są poprawne zgodnie z adnotacjami danych w klasie ZamowienieViewModel.
        ///if (CzyMiejsceZajete(seans, model.NrRzedu, model.NrMiejsca)): Wywołuje metodę o nazwie CzyMiejsceZajete w celu sprawdzenia, czy wybrane miejsce jest już zajęte.Jeśli tak, metoda ustawia komunikat o błędzie w ViewBag.Error i zwraca widok SeansDetails z bieżącym modelem.
        ///DodajInfoSeans(id);: Ta metoda jest wywoływana w celu dodania informacji o screeningu do ViewBag, aby można je było wyświetlić w widoku.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Powoduje to zwrócenie widoku SeansDetails z bieżącym modelem, dzięki czemu wszelkie błędy sprawdzania poprawności lub komunikaty o błędach mogą być wyświetlane użytkownikowi.</returns>
        [HttpPost]
        public IActionResult SeansDetails(int id, ZamowienieViewModel model)
        {
            var seans = context.Seanse.FirstOrDefault(x => x.IdSeans == id); //sprawdzenie czy seans istnieje
            if (seans == null)
            {
                return NotFound(); //zabezpieczenie przed podaniem id seansu ktore nie istnieje
            }

            if (ModelState.IsValid) //sprawdzenie czy formularz jest poprawny
            {
                if (CzyMiejsceZajete(seans, model.NrRzedu, model.NrMiejsca)) //jezeli miejsce jest juz zajete, nie da sie go zarezerwowac
                {
                    ViewBag.Error = "Podane miejsce jest już zajęte"; //wyswietlenie komunikatu
                    DodajInfoSeans(id);
                    return View(model);
                }
                ///<summary>kod tworzy nową instancję klasy Zamowienie z danymi podanymi przez użytkownika w ZamowienieViewModel, w tym Mail, Imie, Status, Platnosc, Nazwisko i Ulga. 
                ///Następnie dodaje tę instancję do kontekstu kontekstowej bazy danych przy użyciu metody Add.</summary> 
                var zamowienie = new Zamowienie //generacja danych po zlozeniu zamowienia
                {
                    IdSeans = id,
                    Mail = model.Mail,
                    Imie = model.Imie,
                    Status = "Niepotwierdzone",
                    Platnosc = model.Platnosc,
                    Nazwisko = model.Nazwisko,
                    Ulga = model.Ulga
                };
                context.Add(zamowienie); //wyslanie danych do bazy

                var miejsce = new Miejsce
                {
                    CzyZajete = true,
                    Rzad = model.NrRzedu,
                    Zamowienie = zamowienie,
                    NrMiejsca = model.NrMiejsca
                };
                context.Add(miejsce); //wyslanie danych do bazy

                context.SaveChanges();
                return RedirectToAction("Podsumowanie", new { guid = zamowienie.Guid });
            }
            ///<summary>przechodzimy do widoku podsumowania</summary>
            DodajInfoSeans(id);
            return View(model); //przechodzimy do widoku podsumowania
        }
        /// <summary>
        /// Ten kod definiuje metodę akcji o nazwie Podsumowanie, która obsługuje żądanie GET i przyjmuje identyfikator GUID pojedynczego parametru typu Guid. Parametr guid służy do pobrania z bazy danych szczegółów wcześniej złożonego zamówienia.
        ///Najpierw metoda sprawdza, czy w bazie danych istnieje zamówienie o podanym GUID.Jeśli nie istnieje, metoda zwraca wynik NotFound.
        ///Następnie metoda pobiera zamówienie z bazy danych, w tym szczegóły dotyczące powiązanych seansów i filmów. Pobiera również szczegóły dotyczące miejsca zarezerwowanego dla zamówienia.
        ///Następnie metoda oblicza cenę biletu na podstawie wybranej zniżki (Ulga) oraz ceny biletu bazowego (cenaBazowaBiletu).
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>metoda zwraca wynik View, przekazując pobrane zamówienie jako model. Właściwość ViewBag.Miejsce jest ustawiona na zarezerwowane miejsce, a właściwość ViewBag.Cena jest ustawiona na obliczoną cenę biletu. Widok Podsumowanie może wtedy wyświetlić szczegóły zamówienia wraz z zarezerwowanym miejscem i obliczoną ceną biletu.</returns>
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
            ViewBag.Cena = Math.Round(cenaBazowaBiletu * (1 - ulgi[zamowienie.Ulga]), 2); //wyliczenie ceny biletu po wybraniu ulgi
            return View(zamowienie);
        }
        /// <summary>
        /// Akcja „Potwierdzenie” odpowiada za potwierdzenie i zmianę statusu zamówienia na podstawie wybranej metody płatności. Jeżeli forma płatności to "online", status jest ustawiony na 
        /// "Potwierdzone, opłacone". W przeciwnym razie status jest ustawiony na „Potwierdzone, do opłacenia w kasie”. Po zmianie statusu zmiany zostają zapisane w bazie danych, a użytkownik 
        /// zostaje przekierowany do akcji „Podsumowanie” w celu przejrzenia podsumowania zamówienia.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>przekierowanie do podsumowania</returns>
        public IActionResult Potwierdzenie(Guid guid)
        {
            var zamowienie = context.Zamowienia.FirstOrDefault(x => x.Guid == guid);
            if (zamowienie == null)
            {
                return NotFound();
            }
            if (zamowienie.Platnosc == "online") //jezeli zamowienie online
            {
                zamowienie.Status = "Potwierdzone, opłacone"; //po zakupie wyswietla komunikat statusu
            }
            else
            {
                zamowienie.Status = "Potwierdzone, do opłacenia w kasie";
            }
            context.SaveChanges(); //dodanie do bazy danych
            return RedirectToAction("Podsumowanie", new { guid = zamowienie.Guid });
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Jest to domyślna akcja błędu w ASP.NET Core MVC. Zwraca widok w celu wyświetlenia informacji o błędzie, w tym unikatowego identyfikatora żądania dla błędu, jeśli jest dostępny.
        /// Atrybut ResponseCache zastosowany do tej akcji wskazuje, że odpowiedzi nie powinny być buforowane, a NoStore = true wskazuje, że buforowanie odpowiedzi powinno być wyłączone.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// Akcja Popularne wykorzystuje instancję WebClient do pobrania ciągu znaków ze strony internetowej zawierającej informacje o popularnych filmach. 
        /// Następnie używa JsonSerializer.Deserialize do deserializacji ciągu JSON do obiektu FilmyViewModel, który jest zwracany do widoku Popularne w celu wyświetlenia. FilmyViewModel to niestandardowy model, który zawiera właściwości szczegółów filmu, takie jak tytuł, data wydania, ścieżka plakatu i przegląd.
        /// </summary>
        /// <returns></returns>
        public IActionResult Popularne() //Pobieranie danych ze strony intenrnetowej odnosnie popularnych filmow
        {
            WebClient webClient = new WebClient();
            var pageNr = new Random().Next(1, 11);
            string data = webClient.DownloadString($"https://api.themoviedb.org/3/movie/popular?api_key=a84909a3156caf84337832e7fe15e20c&page={pageNr}");
            var movies = JsonSerializer.Deserialize<FilmyViewModel>(data); //zamiana na obiekty
            return View(movies); 
        }
        /// <summary>
        /// Jest to prywatna metoda, która sprawdza, czy miejsce jest już zajęte, wyszukując odpowiedni rząd, numer miejsca i sprawdzając w bazie danych. Zwraca wartość logiczną wskazującą, czy miejsce jest zajęte, czy nie. Metoda przyjmuje obiekt Seans reprezentujący ekranowanie oraz dwie liczby całkowite: nrRzedu i nrMiejsca reprezentujące odpowiednio numer rzędu i siedzenia. Metoda zwraca true, jeśli miejsce jest już zajęte i false, jeśli jest dostępne.
        /// Metoda osiąga to przez wysłanie zapytania do bazy danych przy użyciu Entity Framework Core. Zawiera powiązany obiekt Zamowienie, aby sprawdzić, czy miejsce jest zarezerwowane i czy jest zarezerwowane dla danego obiektu Seans. Następnie sprawdza, czy numer rzędu i numer siedzenia są zgodne z podanymi jako parametry.
        /// </summary>
        /// <param name="seans"></param>
        /// <param name="nrRzedu"></param>
        /// <param name="nrMiejsca"></param>
        /// <returns></returns>
        private bool CzyMiejsceZajete(Seans seans, int nrRzedu, int nrMiejsca)
        {
            return context.Miejsca //szukamy czy istnieje miejsce, musi spelniac 3 warunki
                .Include(x => x.Zamowienie)
                .Any(miejsce => miejsce.Zamowienie.IdSeans == seans.IdSeans
                && miejsce.Rzad == nrRzedu && miejsce.NrMiejsca == nrMiejsca);
        }
    }
} 