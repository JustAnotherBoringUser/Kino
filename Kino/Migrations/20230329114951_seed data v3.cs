using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class seeddatav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Seanse_SeansIdSeans",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "Obsada",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "Plakat",
                table: "Filmy");

            migrationBuilder.RenameColumn(
                name: "SeansIdSeans",
                table: "Zamowienia",
                newName: "IdSeans");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_SeansIdSeans",
                table: "Zamowienia",
                newName: "IX_Zamowienia_IdSeans");

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 1,
                columns: new[] { "DataPremiery", "OgrWiekowe", "OpisDlugi", "OpisKrotki", "Rezyseria" },
                values: new object[] { new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "+16", "Akcja filmu \"Za linią wroga\" rozgrywa się w czasie II wojny światowej. Naziści zajęli tereny Polski i szybko posuwają się dalej. Niebawem w ręce okupantów trafia wybitny naukowiec Fabian (Paweł Deląg, \"Lista Schindlera\", \"Kiler\"). Mężczyzna jest prawdziwym geniuszem, mającym w głowie plany sekretnych innowacji. Z tego powodu odbicie go z rąk wrogów i przetransportowanie do Wielkiej Brytanii ma priorytetowe znaczenie. Wszyscy doskonale rozumieją, że jeżeli posiadana przez jeńca wiedza zostanie wykorzystana przez nazistów, wynik wojny będzie przesądzony. Do przeprowadzenia specjalnej operacji ratunkowej zostaje przydzielony amerykański oficer. Łącząc siły z elitarną drużyną sojuszniczych sił, trafia w samo centrum okupowanego terytorium. Czy uda im się odnaleźć naukowca i wyrwać go z rąk wrogów?", "Amerykański film wojenny z 2001 roku w reżyserii Johna Moore’a, z Gene’em Hackmanem i Owenem Wilsonem w rolach głównych. ", "John Moore" });

            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "IdFilm", "CzasTrawania", "DataPremiery", "DostepneWersje", "Gatunek", "Jezyk", "Kraj", "OgrWiekowe", "OpisDlugi", "OpisKrotki", "Rezyseria", "Tytul" },
                values: new object[,]
                {
                    { 2, "01:57:00", new DateTime(2001, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "dsfds", "Animowany", "Ang", "USA", "+8", "W bagnie żył olbrzym Shrek, którego cenna samotność została nagle zakłócona inwazją dokuczliwych postaci z bajek. Ślepe myszki buszują w zapasach olbrzyma, zły wilk sypia w jego łóżku, a trzy świnki buszują  po jego samotni. Wszystkie te postaci zostały wypędzone ze swego królestwa przez złego Lorda Farquaada.  Zdecydowany ocalić ich dom – nie mówiąc już o swoim – Shrek porozumiewa się z Farquaadem i wyrusza na ratunek pięknej księżniczce Fionie, która ma zostać żoną Lorda. W misji towarzyszy mu przemądrzały Osioł, który zrobi dla Shreka wszystko z wyjątkiem... przestania mielenia ozorem. Ocalenie księżniczki przed ziejącym ogniem smokiem okazuje się być najmniejszym problemem przyjaciół, kiedy to zostaje odkryty głęboko skrywany, mroczny sekret Fiony.  ", "Amerykański film animowany z 2001 w reżyserii Andrew Adamsona i Vicky Jenson, będący adaptacją ilustrowanej książki Shrek! autorstwa Williama Steiga. ", "Vicky Jenson, Andrew Adamson", "Shrek" },
                    { 3, "02:39:00", new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "dsfds", "Kryminał", "Ang", "USA", "+16", "Ceny idą w górę, więc także stawka za głowę legendarnego zabójcy, Johna Wicka przebiła już sufit. Stając do ostatecznego pojedynku, który może dać mu upragnioną wolność i zasłużoną emeryturę, John wie, że może liczyć tylko na siebie. Dla niego, to nic nowego. To co zmieniło się tym razem, to fakt, że przeciwko sobie ma całą międzynarodową organizację najlepszych płatnych zabójców, a jej nowy szef Markiz de Gramond jest równie wyrafinowany, co bezlitosny. Zanim John stanie z nim oko w oko, będzie musiał odwiedzić kilka kontynentów mierząc się z całą plejadą twardzieli, którzy wiedzą wszystko o zabijaniu. Tuż przed wielkim finałem tej morderczej symfonii, John Wick trafi na trop swojej dalekiej rodziny, której członkowie mogą mieć decydujący wpływ na wynik całej rozgrywki. ", "Amerykański thriller neo-noir z 2023 roku, wyreżyserowany przez Chada Stahelskiego i napisany przez Shay'a Hattena i Michaela Fincha. Kontynuacja Johna Wicka 3 z 2019 roku, a także czwarta część serii filmów John Wick. W roli tytułowej wystąpił Keanu Reeves. ", "Chad Stahelski", "John Wick 4" },
                    { 4, "01:39:00", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dsfds", "Thriller", "PL", "USA", "+15", "Tajemniczy wypadek samochodowy zmienia całkowicie życie Maćka (Tomasz Kot). W zdarzeniu ginie jego żona Janina (Karolina Gruszka). Najprawdopodobniej kobieta popełniła samobójstwo. Maciej nie ma jednak pojęcia, dlaczego do wypadku doszło pod Mrągowem, skoro Janina powiedziała, że jedzie na delegację do Krakowa. Pomyliła się? A może kłamała? Zrozpaczony mężczyzna wyrusza w podróż, aby rozwiązać zagadkę jej śmierci. Wkrótce trafia na trop niejakiego Wojnara (Grzegorz Damięcki) – aktora, którego podejrzewa o romans ze zmarłą żoną. Od tego momentu pytania zaczynają się mnożyć, a tragedia zmienia się w skomplikowaną zagadkę. Maciej dochodzi do wniosku, że być może w ogóle nie znał kobiety, którą poślubił… ", "Thriller psychologiczny, poruszający trudną tematykę konsekwencji życiowych błędów, straty oraz małżeńskich sekretów, a także miłości dwóch mężczyzn. ", "Bartosz Konopka", "Wyrwa" }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "IdSala", "IloscMiejsc", "IloscRzedow", "Numer" },
                values: new object[] { 4, 50, 10, 4 });

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienie", "IdSeans", "Imie", "Mail", "Nazwisko", "Platnosc", "Status" },
                values: new object[] { 1, 1, "Marcin", "marcin.kowalski@o2.pl", "Kowalski", "Online", "Zrealizowane" });

            migrationBuilder.InsertData(
                table: "Seanse",
                columns: new[] { "IdSeans", "Data", "IdFilm", "IdSala", "WersjaJez" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "PL" },
                    { 3, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "PL" },
                    { 4, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "PL" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienie", "IdSeans", "Imie", "Mail", "Nazwisko", "Platnosc", "Status" },
                values: new object[,]
                {
                    { 2, 2, "Michał", "michal.kubicki@o2.pl", "Kubicki", "Online", "Zrealizowane" },
                    { 3, 3, "Dominik", "dominik.syska@o2.pl", "Syska", "Online", "Zrealizowane" },
                    { 4, 4, "Magda", "magda.sokolowska@o2.pl", "Sokołowska", "Online", "Zrealizowane" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Seanse_IdSeans",
                table: "Zamowienia",
                column: "IdSeans",
                principalTable: "Seanse",
                principalColumn: "IdSeans",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Seanse_IdSeans",
                table: "Zamowienia");

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "IdSeans",
                table: "Zamowienia",
                newName: "SeansIdSeans");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_IdSeans",
                table: "Zamowienia",
                newName: "IX_Zamowienia_SeansIdSeans");

            migrationBuilder.AddColumn<string>(
                name: "Obsada",
                table: "Filmy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plakat",
                table: "Filmy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 1,
                columns: new[] { "DataPremiery", "Obsada", "OgrWiekowe", "OpisDlugi", "OpisKrotki", "Plakat", "Rezyseria" },
                values: new object[] { new DateTime(2008, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ssdsd", "PEGI", "Fdsfsdfdsfsd", "fdfdfddf", "dfjsfdsfds", "Ktos tam" });

            migrationBuilder.UpdateData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Seanse_SeansIdSeans",
                table: "Zamowienia",
                column: "SeansIdSeans",
                principalTable: "Seanse",
                principalColumn: "IdSeans",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
