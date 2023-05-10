using Kino.Data.Models;
using Kino.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using System.Security.Cryptography;

//dotnet tool install --global dotnet-ef
//Add-Migrations "init"
//Database-Update

//dotnet ef migrations add "nazwa"
//dotnet ef database update
///<summary>
///definicja klasy dla DbContext o nazwie DataContext, która dziedziczy z DbContext. Definiuje zestaw właściwości DbSet dla każdego podmiotu w bazie danych, w tym Bilety, Filmy, Miejsce, Sala, Seans i Zamowienie.
///Parametr DbContextOptions w konstruktorze służy do konfigurowania połączenia z bazą danych.
/// </summary>
namespace Kino.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bilet> Bilety { get; set; }
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Seans> Seanse { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ///<summary>
            ///Ten kod używa płynnego interfejsu API Entity Framework Core do konfigurowania danych początkowych jednostki Sala. Metoda OnModelCreating jest wywoływana podczas tworzenia kontekstu bazy danych i służy do konfigurowania modeli jednostek i ich relacji.
            /// W tym przypadku jednostka Sala ma cztery instancje danych początkowych, które są zdefiniowane za pomocą metody HasData. Każda Sala ma właściwość IdSala, Numer, IloscMiejsc i IloscRzedow.Metoda HasData pobiera tablicę anonimowych obiektów, które reprezentują początkowe dane jednostki.
            ///Właściwość IdSala jest kluczem podstawowym jednostki Sala i jest ustawiana jawnie dla każdej instancji danych.Definiując dane początkowe w ten sposób, baza danych zostanie zaszczepiona początkowymi danymi Sala, gdy kontekst zostanie utworzony po raz pierwszy.
            /// </summary>
            modelBuilder.Entity<Sala>().HasData(new[]
            {
                new Sala
                {
                    IdSala = 1,
                    Numer = 1,
                    IloscMiejsc = 30,
                    IloscRzedow = 5
                },
                new Sala
                {
                    IdSala = 2,
                    Numer = 2,
                    IloscMiejsc = 100,
                    IloscRzedow = 30
                },
                new Sala
                {
                    IdSala = 3,
                    Numer = 3,
                    IloscMiejsc = 80,
                    IloscRzedow = 28
                },
                 new Sala
                {
                    IdSala = 4,
                    Numer = 4,
                    IloscMiejsc = 50,
                    IloscRzedow = 10
                },
            });
            ///<summary>
            ///Fragment kodu jest napisany w języku C# i definiuje dane dla filmów w aplikacji. Każdy film ma właściwości, takie jak identyfikator, tytuł, gatunek, czas trwania, data premiery, reżyser, dostępne wersje, język, kraj, ograniczenia wiekowe, długie i krótkie opisy.
            ///Metoda HasData służy do wypełniania początkowych danych dla encji Film.Każdy film jest definiowany jako instancja klasy Film i dodawany do tablicy filmów przy użyciu inicjatora obiektu.Składnia new[] wskazuje, że tworzona jest tablica.
            ///Na przykład pierwszy film ma IdFilm 1, tytuł „Za linią wroga”, gatunek „Wojenny”, czas trwania „02:00:00”, datę premiery 15 października 2001 itd. NA.
            ///</summary>
            modelBuilder.Entity<Film>().HasData(new[]
            {
                new Film
                {
                    IdFilm = 1,
                    Tytul = "Za linią wroga",
                    Gatunek = "Wojenny",
                    CzasTrawania = "02:00:00",
                    DataPremiery = new DateTime(2001, 10, 15),
                    Rezyseria = "John Moore",
                    DostepneWersje = "PL",
                    Jezyk = "Ang",
                    Kraj = "USA",
                    OgrWiekowe = "+16",
                    OpisDlugi = "Akcja filmu \"Za linią wroga\" rozgrywa się w czasie II wojny światowej. Naziści zajęli tereny Polski i szybko posuwają się dalej. Niebawem w ręce okupantów trafia wybitny naukowiec Fabian (Paweł Deląg, \"Lista Schindlera\", \"Kiler\"). Mężczyzna jest prawdziwym geniuszem, mającym w głowie plany sekretnych innowacji. Z tego powodu odbicie go z rąk wrogów i przetransportowanie do Wielkiej Brytanii ma priorytetowe znaczenie. Wszyscy doskonale rozumieją, że jeżeli posiadana przez jeńca wiedza zostanie wykorzystana przez nazistów, wynik wojny będzie przesądzony. Do przeprowadzenia specjalnej operacji ratunkowej zostaje przydzielony amerykański oficer. Łącząc siły z elitarną drużyną sojuszniczych sił, trafia w samo centrum okupowanego terytorium. Czy uda im się odnaleźć naukowca i wyrwać go z rąk wrogów?",
                    OpisKrotki = "Amerykański film wojenny z 2001 roku w reżyserii Johna Moore’a, z Gene’em Hackmanem i Owenem Wilsonem w rolach głównych. ",
                },
                new Film
                {
                    IdFilm = 2,
                    Tytul = "Shrek",
                    Gatunek = "Animowany",
                    CzasTrawania = "01:57:00",
                    DataPremiery = new DateTime(2001, 08, 15),
                    Rezyseria = "Vicky Jenson, Andrew Adamson",
                    DostepneWersje = "PL",
                    Jezyk = "Ang",
                    Kraj = "USA",
                    OgrWiekowe = "+8",
                    OpisDlugi = "W bagnie żył olbrzym Shrek, którego cenna samotność została nagle zakłócona inwazją dokuczliwych postaci z bajek. Ślepe myszki buszują w zapasach olbrzyma, zły wilk sypia w jego łóżku, a trzy świnki buszują  po jego samotni. Wszystkie te postaci zostały wypędzone ze swego królestwa przez złego Lorda Farquaada.  Zdecydowany ocalić ich dom – nie mówiąc już o swoim – Shrek porozumiewa się z Farquaadem i wyrusza na ratunek pięknej księżniczce Fionie, która ma zostać żoną Lorda. W misji towarzyszy mu przemądrzały Osioł, który zrobi dla Shreka wszystko z wyjątkiem... przestania mielenia ozorem. Ocalenie księżniczki przed ziejącym ogniem smokiem okazuje się być najmniejszym problemem przyjaciół, kiedy to zostaje odkryty głęboko skrywany, mroczny sekret Fiony.  ",
                    OpisKrotki = "Amerykański film animowany z 2001 w reżyserii Andrew Adamsona i Vicky Jenson, będący adaptacją ilustrowanej książki Shrek! autorstwa Williama Steiga. ",
                },
                new Film
                {
                    IdFilm = 3,
                    Tytul = "John Wick 4",
                    Gatunek = "Kryminał",
                    CzasTrawania = "02:39:00",
                    DataPremiery = new DateTime(2023, 03, 24),
                    Rezyseria = "Chad Stahelski",
                    DostepneWersje = "PL",
                    Jezyk = "Ang",
                    Kraj = "USA",
                    OgrWiekowe = "+16",
                    OpisDlugi = "Ceny idą w górę, więc także stawka za głowę legendarnego zabójcy, Johna Wicka przebiła już sufit. Stając do ostatecznego pojedynku, który może dać mu upragnioną wolność i zasłużoną emeryturę, John wie, że może liczyć tylko na siebie. Dla niego, to nic nowego. To co zmieniło się tym razem, to fakt, że przeciwko sobie ma całą międzynarodową organizację najlepszych płatnych zabójców, a jej nowy szef Markiz de Gramond jest równie wyrafinowany, co bezlitosny. Zanim John stanie z nim oko w oko, będzie musiał odwiedzić kilka kontynentów mierząc się z całą plejadą twardzieli, którzy wiedzą wszystko o zabijaniu. Tuż przed wielkim finałem tej morderczej symfonii, John Wick trafi na trop swojej dalekiej rodziny, której członkowie mogą mieć decydujący wpływ na wynik całej rozgrywki. ",
                    OpisKrotki = "Amerykański thriller neo-noir z 2023 roku, wyreżyserowany przez Chada Stahelskiego i napisany przez Shay'a Hattena i Michaela Fincha. Kontynuacja Johna Wicka 3 z 2019 roku, a także czwarta część serii filmów John Wick. W roli tytułowej wystąpił Keanu Reeves. ",
                },
                new Film
                {
                    IdFilm = 4,
                    Tytul = "Wyrwa",
                    Gatunek = "Thriller",
                    CzasTrawania = "01:39:00",
                    DataPremiery = new DateTime(2023, 03, 17),
                    Rezyseria = "Bartosz Konopka",
                    DostepneWersje = "PL",
                    Jezyk = "PL",
                    Kraj = "USA",
                    OgrWiekowe = "+15",
                    OpisDlugi = "Tajemniczy wypadek samochodowy zmienia całkowicie życie Maćka (Tomasz Kot). W zdarzeniu ginie jego żona Janina (Karolina Gruszka). Najprawdopodobniej kobieta popełniła samobójstwo. Maciej nie ma jednak pojęcia, dlaczego do wypadku doszło pod Mrągowem, skoro Janina powiedziała, że jedzie na delegację do Krakowa. Pomyliła się? A może kłamała? Zrozpaczony mężczyzna wyrusza w podróż, aby rozwiązać zagadkę jej śmierci. Wkrótce trafia na trop niejakiego Wojnara (Grzegorz Damięcki) – aktora, którego podejrzewa o romans ze zmarłą żoną. Od tego momentu pytania zaczynają się mnożyć, a tragedia zmienia się w skomplikowaną zagadkę. Maciej dochodzi do wniosku, że być może w ogóle nie znał kobiety, którą poślubił… ",
                    OpisKrotki = "Thriller psychologiczny, poruszający trudną tematykę konsekwencji życiowych błędów, straty oraz małżeńskich sekretów, a także miłości dwóch mężczyzn. ",
                },
            });

            modelBuilder.Entity<Seans>().HasData(new[]
            {
                new Seans
                {
                    IdSeans = 1,
                    Data = new DateTime(2023, 04, 04, 10, 20, 0),
                    IdFilm = 1,
                    IdSala = 2,
                    WersjaJez = "PL"
                },
                new Seans
                {
                    IdSeans = 2,
                    Data = new DateTime(2023, 05, 18, 15,30,0),
                    IdFilm = 2,
                    IdSala = 1,
                    WersjaJez = "PL"
                },
                new Seans
                {
                    IdSeans = 3,
                    Data = new DateTime(2023, 05, 18, 20,0,0),
                    IdFilm = 3,
                    IdSala = 3,
                    WersjaJez = "PL"
                },
                new Seans
                {
                    IdSeans = 4,
                    Data = new DateTime(2023, 05, 04, 22, 30, 0),
                    IdFilm = 4,
                    IdSala = 4,
                    WersjaJez = "PL"
                }
            });
            //modelBuilder.Entity<Miejsce>().HasData(new[]
            //{
            //    new Miejsce
            //    {

            //    }

            //});
            modelBuilder.Entity<Zamowienie>().HasData(new[]
            {
                new Zamowienie
                {
                    IdZamowienie = 1,
                    Imie = "Marcin",
                    Nazwisko = "Kowalski",
                    Mail = "marcin.kowalski@o2.pl",
                    Platnosc = "Online",
                    Status = "Zrealizowane",
                    IdSeans = 1,
                },
                new Zamowienie
                {
                    IdZamowienie = 2,
                    Imie = "Michał",
                    Nazwisko = "Kubicki",
                    Mail = "michal.kubicki@o2.pl",
                    Platnosc = "Online",
                    Status = "Zrealizowane",
                    IdSeans = 2,
                },
                new Zamowienie
                {
                    IdZamowienie = 3,
                    Imie = "Dominik",
                    Nazwisko = "Syska",
                    Mail = "dominik.syska@o2.pl",
                    Platnosc = "Online",
                    Status = "Zrealizowane",
                    IdSeans = 3,
                },
                new Zamowienie
                {
                    IdZamowienie = 4,
                    Imie = "Magda",
                    Nazwisko = "Sokołowska",
                    Mail = "magda.sokolowska@o2.pl",
                    Platnosc = "Online",
                    Status = "Zrealizowane",
                    IdSeans = 4,
                }
            });
        }
    }
}
