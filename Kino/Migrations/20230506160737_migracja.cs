using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class migracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seanse",
                keyColumn: "IdSeans",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filmy",
                keyColumn: "IdFilm",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "IdSala",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("2212e034-af91-4be8-bdc3-2cdec94919bd"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("72a34e92-865b-4ad5-8e04-eebd45d47be9"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("f078a654-308c-4f6c-a869-b24de46096b9"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c5434e83-f907-49a1-9542-8374b8345500"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "IdFilm", "CzasTrawania", "DataPremiery", "DostepneWersje", "Gatunek", "Jezyk", "Kraj", "OgrWiekowe", "OpisDlugi", "OpisKrotki", "Rezyseria", "Tytul" },
                values: new object[,]
                {
                    { 5, "01:50:00", new DateTime(2001, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PL", "Wojenny", "Ang", "USA", "+12", "Akcja filmu \"Za linią wroga\" rozgrywa się w czasie II wojny światowej. Naziści zajęli tereny Polski i szybko posuwają się dalej. Niebawem w ręce okupantów trafia wybitny naukowiec Fabian (Paweł Deląg, \"Lista Schindlera\", \"Kiler\"). Mężczyzna jest prawdziwym geniuszem, mającym w głowie plany sekretnych innowacji. Z tego powodu odbicie go z rąk wrogów i przetransportowanie do Wielkiej Brytanii ma priorytetowe znaczenie. Wszyscy doskonale rozumieją, że jeżeli posiadana przez jeńca wiedza zostanie wykorzystana przez nazistów, wynik wojny będzie przesądzony. Do przeprowadzenia specjalnej operacji ratunkowej zostaje przydzielony amerykański oficer. Łącząc siły z elitarną drużyną sojuszniczych sił, trafia w samo centrum okupowanego terytorium. Czy uda im się odnaleźć naukowca i wyrwać go z rąk wrogów?", "Amerykański film wojenny z 2001 roku w reżyserii Johna Moore’a, z Gene’em Hackmanem i Owenem Wilsonem w rolach głównych. ", "John Moore", "Po drugiej stronie" },
                    { 6, "01:59:00", new DateTime(2002, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "PL", "Animowany", "Ang", "USA", "+8", "W bagnie żył olbrzym Shrek, którego cenna samotność została nagle zakłócona inwazją dokuczliwych postaci z bajek. Ślepe myszki buszują w zapasach olbrzyma, zły wilk sypia w jego łóżku, a trzy świnki buszują  po jego samotni. Wszystkie te postaci zostały wypędzone ze swego królestwa przez złego Lorda Farquaada.  Zdecydowany ocalić ich dom – nie mówiąc już o swoim – Shrek porozumiewa się z Farquaadem i wyrusza na ratunek pięknej księżniczce Fionie, która ma zostać żoną Lorda. W misji towarzyszy mu przemądrzały Osioł, który zrobi dla Shreka wszystko z wyjątkiem... przestania mielenia ozorem. Ocalenie księżniczki przed ziejącym ogniem smokiem okazuje się być najmniejszym problemem przyjaciół, kiedy to zostaje odkryty głęboko skrywany, mroczny sekret Fiony.  ", "Amerykański film animowany z 2001 w reżyserii Andrew Adamsona i Vicky Jenson, będący adaptacją ilustrowanej książki Shrek! autorstwa Williama Steiga. ", "Vicky Jenson, Andrew Adamson", "Shrek2" }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "IdSala", "IloscMiejsc", "IloscRzedow", "Numer" },
                values: new object[,]
                {
                    { 5, 50, 10, 5 },
                    { 6, 50, 10, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 1,
                column: "Guid",
                value: new Guid("e7dbee91-2604-4eda-9707-f21e8e63acc9"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 2,
                column: "Guid",
                value: new Guid("d17dac55-f6b3-4eb6-a3bb-2e9b34bcb4b9"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 3,
                column: "Guid",
                value: new Guid("04a90e26-7473-46d9-8329-8a1d8d120027"));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienie",
                keyValue: 4,
                column: "Guid",
                value: new Guid("472ba614-6021-4085-a97c-b77d69530bad"));

            migrationBuilder.InsertData(
                table: "Seanse",
                columns: new[] { "IdSeans", "Data", "IdFilm", "IdSala", "WersjaJez" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 6, 5, 22, 30, 0, 0, DateTimeKind.Unspecified), 5, 5, "PL" },
                    { 6, new DateTime(2023, 6, 5, 22, 30, 0, 0, DateTimeKind.Unspecified), 6, 6, "PL" }
                });
        }
    }
}
