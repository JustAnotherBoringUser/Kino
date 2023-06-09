USE [master]
GO
/****** Object:  Database [KinoDB]    Script Date: 06.05.2023 19:22:10 ******/
CREATE DATABASE [KinoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KinoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KinoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KinoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KinoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KinoDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KinoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KinoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KinoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KinoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KinoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KinoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KinoDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KinoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KinoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KinoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KinoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KinoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KinoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KinoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KinoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KinoDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KinoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KinoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KinoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KinoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KinoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KinoDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [KinoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KinoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KinoDB] SET  MULTI_USER 
GO
ALTER DATABASE [KinoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KinoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KinoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KinoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KinoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KinoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KinoDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [KinoDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KinoDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bilety]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bilety](
	[IdBilet] [int] IDENTITY(1,1) NOT NULL,
	[Ulga] [nvarchar](max) NOT NULL,
	[Cena] [real] NOT NULL,
	[MiejsceIdMiejsce] [int] NOT NULL,
	[ZamowienieIdZamowienie] [int] NOT NULL,
 CONSTRAINT [PK_Bilety] PRIMARY KEY CLUSTERED 
(
	[IdBilet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filmy]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filmy](
	[IdFilm] [int] IDENTITY(1,1) NOT NULL,
	[Tytul] [nvarchar](max) NOT NULL,
	[Gatunek] [nvarchar](max) NOT NULL,
	[CzasTrawania] [nvarchar](max) NOT NULL,
	[DataPremiery] [datetime2](7) NOT NULL,
	[Rezyseria] [nvarchar](max) NOT NULL,
	[Kraj] [nvarchar](max) NOT NULL,
	[Jezyk] [nvarchar](max) NOT NULL,
	[OgrWiekowe] [nvarchar](max) NOT NULL,
	[OpisDlugi] [nvarchar](max) NOT NULL,
	[OpisKrotki] [nvarchar](max) NOT NULL,
	[DostepneWersje] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Filmy] PRIMARY KEY CLUSTERED 
(
	[IdFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Miejsca]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Miejsca](
	[IdMiejsce] [int] IDENTITY(1,1) NOT NULL,
	[Rzad] [int] NOT NULL,
	[CzyZajete] [bit] NOT NULL,
	[IdZamowienie] [int] NOT NULL,
	[NrMiejsca] [int] NOT NULL,
 CONSTRAINT [PK_Miejsca] PRIMARY KEY CLUSTERED 
(
	[IdMiejsce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[IdSala] [int] IDENTITY(1,1) NOT NULL,
	[Numer] [int] NOT NULL,
	[IloscRzedow] [int] NOT NULL,
	[IloscMiejsc] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[IdSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seanse]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seanse](
	[IdSeans] [int] IDENTITY(1,1) NOT NULL,
	[IdFilm] [int] NOT NULL,
	[IdSala] [int] NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[WersjaJez] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Seanse] PRIMARY KEY CLUSTERED 
(
	[IdSeans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zamowienia]    Script Date: 06.05.2023 19:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienia](
	[IdZamowienie] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](max) NOT NULL,
	[Nazwisko] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Platnosc] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[IdSeans] [int] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Ulga] [nvarchar](max) NULL,
 CONSTRAINT [PK_Zamowienia] PRIMARY KEY CLUSTERED 
(
	[IdZamowienie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322131356_init', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322132540_seed data', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322132849_seed data v2', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230329114951_seed data v3', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230403093752_seed data v4', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230403094702_seed data v5', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230412101859_Alter miejsce add zamowienie col', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230412103424_poprawki do tabel', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230412103922_poprawki do tabel v2', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230417173941_v6', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230417180635_v6', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230419142457_kk', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506155515_migracja', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506160105_migracja2', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506160737_migracja', N'7.0.4')
GO
SET IDENTITY_INSERT [dbo].[Filmy] ON 

INSERT [dbo].[Filmy] ([IdFilm], [Tytul], [Gatunek], [CzasTrawania], [DataPremiery], [Rezyseria], [Kraj], [Jezyk], [OgrWiekowe], [OpisDlugi], [OpisKrotki], [DostepneWersje]) VALUES (1, N'Za linią wroga', N'Wojenny', N'02:00:00', CAST(N'2001-10-15T00:00:00.0000000' AS DateTime2), N'John Moore', N'USA', N'Ang', N'+16', N'Akcja filmu "Za linią wroga" rozgrywa się w czasie II wojny światowej. Naziści zajęli tereny Polski i szybko posuwają się dalej. Niebawem w ręce okupantów trafia wybitny naukowiec Fabian (Paweł Deląg, "Lista Schindlera", "Kiler"). Mężczyzna jest prawdziwym geniuszem, mającym w głowie plany sekretnych innowacji. Z tego powodu odbicie go z rąk wrogów i przetransportowanie do Wielkiej Brytanii ma priorytetowe znaczenie. Wszyscy doskonale rozumieją, że jeżeli posiadana przez jeńca wiedza zostanie wykorzystana przez nazistów, wynik wojny będzie przesądzony. Do przeprowadzenia specjalnej operacji ratunkowej zostaje przydzielony amerykański oficer. Łącząc siły z elitarną drużyną sojuszniczych sił, trafia w samo centrum okupowanego terytorium. Czy uda im się odnaleźć naukowca i wyrwać go z rąk wrogów?', N'Amerykański film wojenny z 2001 roku w reżyserii Johna Moore’a, z Gene’em Hackmanem i Owenem Wilsonem w rolach głównych. ', N'PL')
INSERT [dbo].[Filmy] ([IdFilm], [Tytul], [Gatunek], [CzasTrawania], [DataPremiery], [Rezyseria], [Kraj], [Jezyk], [OgrWiekowe], [OpisDlugi], [OpisKrotki], [DostepneWersje]) VALUES (2, N'Shrek', N'Animowany', N'01:57:00', CAST(N'2001-08-15T00:00:00.0000000' AS DateTime2), N'Vicky Jenson, Andrew Adamson', N'USA', N'Ang', N'+8', N'W bagnie żył olbrzym Shrek, którego cenna samotność została nagle zakłócona inwazją dokuczliwych postaci z bajek. Ślepe myszki buszują w zapasach olbrzyma, zły wilk sypia w jego łóżku, a trzy świnki buszują  po jego samotni. Wszystkie te postaci zostały wypędzone ze swego królestwa przez złego Lorda Farquaada.  Zdecydowany ocalić ich dom – nie mówiąc już o swoim – Shrek porozumiewa się z Farquaadem i wyrusza na ratunek pięknej księżniczce Fionie, która ma zostać żoną Lorda. W misji towarzyszy mu przemądrzały Osioł, który zrobi dla Shreka wszystko z wyjątkiem... przestania mielenia ozorem. Ocalenie księżniczki przed ziejącym ogniem smokiem okazuje się być najmniejszym problemem przyjaciół, kiedy to zostaje odkryty głęboko skrywany, mroczny sekret Fiony.  ', N'Amerykański film animowany z 2001 w reżyserii Andrew Adamsona i Vicky Jenson, będący adaptacją ilustrowanej książki Shrek! autorstwa Williama Steiga. ', N'PL')
INSERT [dbo].[Filmy] ([IdFilm], [Tytul], [Gatunek], [CzasTrawania], [DataPremiery], [Rezyseria], [Kraj], [Jezyk], [OgrWiekowe], [OpisDlugi], [OpisKrotki], [DostepneWersje]) VALUES (3, N'John Wick 4', N'Kryminał', N'02:39:00', CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), N'Chad Stahelski', N'USA', N'Ang', N'+16', N'Ceny idą w górę, więc także stawka za głowę legendarnego zabójcy, Johna Wicka przebiła już sufit. Stając do ostatecznego pojedynku, który może dać mu upragnioną wolność i zasłużoną emeryturę, John wie, że może liczyć tylko na siebie. Dla niego, to nic nowego. To co zmieniło się tym razem, to fakt, że przeciwko sobie ma całą międzynarodową organizację najlepszych płatnych zabójców, a jej nowy szef Markiz de Gramond jest równie wyrafinowany, co bezlitosny. Zanim John stanie z nim oko w oko, będzie musiał odwiedzić kilka kontynentów mierząc się z całą plejadą twardzieli, którzy wiedzą wszystko o zabijaniu. Tuż przed wielkim finałem tej morderczej symfonii, John Wick trafi na trop swojej dalekiej rodziny, której członkowie mogą mieć decydujący wpływ na wynik całej rozgrywki. ', N'Amerykański thriller neo-noir z 2023 roku, wyreżyserowany przez Chada Stahelskiego i napisany przez Shay''a Hattena i Michaela Fincha. Kontynuacja Johna Wicka 3 z 2019 roku, a także czwarta część serii filmów John Wick. W roli tytułowej wystąpił Keanu Reeves. ', N'PL')
INSERT [dbo].[Filmy] ([IdFilm], [Tytul], [Gatunek], [CzasTrawania], [DataPremiery], [Rezyseria], [Kraj], [Jezyk], [OgrWiekowe], [OpisDlugi], [OpisKrotki], [DostepneWersje]) VALUES (4, N'Wyrwa', N'Thriller', N'01:39:00', CAST(N'2023-03-17T00:00:00.0000000' AS DateTime2), N'Bartosz Konopka', N'USA', N'PL', N'+15', N'Tajemniczy wypadek samochodowy zmienia całkowicie życie Maćka (Tomasz Kot). W zdarzeniu ginie jego żona Janina (Karolina Gruszka). Najprawdopodobniej kobieta popełniła samobójstwo. Maciej nie ma jednak pojęcia, dlaczego do wypadku doszło pod Mrągowem, skoro Janina powiedziała, że jedzie na delegację do Krakowa. Pomyliła się? A może kłamała? Zrozpaczony mężczyzna wyrusza w podróż, aby rozwiązać zagadkę jej śmierci. Wkrótce trafia na trop niejakiego Wojnara (Grzegorz Damięcki) – aktora, którego podejrzewa o romans ze zmarłą żoną. Od tego momentu pytania zaczynają się mnożyć, a tragedia zmienia się w skomplikowaną zagadkę. Maciej dochodzi do wniosku, że być może w ogóle nie znał kobiety, którą poślubił… ', N'Thriller psychologiczny, poruszający trudną tematykę konsekwencji życiowych błędów, straty oraz małżeńskich sekretów, a także miłości dwóch mężczyzn. ', N'dsfds')
SET IDENTITY_INSERT [dbo].[Filmy] OFF
GO
SET IDENTITY_INSERT [dbo].[Miejsca] ON 

INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (1, 1, 1, 6, 13)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (2, 1, 1, 7, 15)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (3, 1, 1, 8, 14)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (4, 1, 1, 9, 10)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (5, 1, 1, 10, 16)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (6, 3, 1, 11, 18)
INSERT [dbo].[Miejsca] ([IdMiejsce], [Rzad], [CzyZajete], [IdZamowienie], [NrMiejsca]) VALUES (7, 3, 1, 12, 14)
SET IDENTITY_INSERT [dbo].[Miejsca] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([IdSala], [Numer], [IloscRzedow], [IloscMiejsc]) VALUES (1, 1, 5, 30)
INSERT [dbo].[Sale] ([IdSala], [Numer], [IloscRzedow], [IloscMiejsc]) VALUES (2, 2, 30, 100)
INSERT [dbo].[Sale] ([IdSala], [Numer], [IloscRzedow], [IloscMiejsc]) VALUES (3, 3, 28, 80)
INSERT [dbo].[Sale] ([IdSala], [Numer], [IloscRzedow], [IloscMiejsc]) VALUES (4, 4, 10, 50)
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
SET IDENTITY_INSERT [dbo].[Seanse] ON 

INSERT [dbo].[Seanse] ([IdSeans], [IdFilm], [IdSala], [Data], [WersjaJez]) VALUES (1, 1, 2, CAST(N'2023-04-04T10:20:00.0000000' AS DateTime2), N'PL')
INSERT [dbo].[Seanse] ([IdSeans], [IdFilm], [IdSala], [Data], [WersjaJez]) VALUES (2, 2, 1, CAST(N'2023-06-18T15:30:00.0000000' AS DateTime2), N'PL')
INSERT [dbo].[Seanse] ([IdSeans], [IdFilm], [IdSala], [Data], [WersjaJez]) VALUES (3, 3, 3, CAST(N'2023-06-18T20:00:00.0000000' AS DateTime2), N'PL')
INSERT [dbo].[Seanse] ([IdSeans], [IdFilm], [IdSala], [Data], [WersjaJez]) VALUES (4, 4, 4, CAST(N'2023-04-05T22:30:00.0000000' AS DateTime2), N'PL')
SET IDENTITY_INSERT [dbo].[Seanse] OFF
GO
SET IDENTITY_INSERT [dbo].[Zamowienia] ON 

INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (1, N'Marcin', N'Kowalski', N'marcin.kowalski@o2.pl', N'Online', N'Zrealizowane', 1, N'2212e034-af91-4be8-bdc3-2cdec94919bd', NULL)
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (2, N'Michał', N'Kubicki', N'michal.kubicki@o2.pl', N'Online', N'Zrealizowane', 2, N'72a34e92-865b-4ad5-8e04-eebd45d47be9', NULL)
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (3, N'Dominik', N'Syska', N'dominik.syska@o2.pl', N'Online', N'Zrealizowane', 3, N'f078a654-308c-4f6c-a869-b24de46096b9', NULL)
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (4, N'Magda', N'Sokołowska', N'magda.sokolowska@o2.pl', N'Online', N'Zrealizowane', 4, N'c5434e83-f907-49a1-9542-8374b8345500', NULL)
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (6, N'Klementyna', N'Bajewska', N'dfgsfsfsf@sdgsd.pl', N'online', N'niepotwierdzone', 2, N'406b16ca-3bc7-4cbf-9950-20f0db105dcb', N'normalny')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (7, N'Klementyna', N'Bajewska', N'dfgsfsfsf@sdgsd.pl', N'online', N'niepotwierdzone', 2, N'51df5959-d866-4e79-b7b3-f1997e16c154', N'dziecko do lat 3')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (8, N'sfsdf', N'dsf', N'sss@dd.pl', N'online', N'niepotwierdzone', 2, N'2bd480aa-60e7-4912-b8ee-24a3cbdee441', N'student')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (9, N'Klementyna', N'Bajewska', N'dfgsfsfsf@sdgsd.pl', N'online', N'Potwierdzone, opłacone', 2, N'5aae36da-e0c9-48fd-a6c7-320038e49135', N'student')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (10, N'Klementyna', N'Bajewska', N'dfgsfsfsf@sdgsd.pl', N'online', N'Potwierdzone, opłacone', 2, N'd03d3fbd-4a17-4c58-a691-6227086fe931', N'student')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (11, N'Miłosz', N'Kukulski', N'dfgsfsfsf@sdgsd.pl', N'online', N'Potwierdzone, opłacone', 2, N'c1738666-da8c-4cfa-9337-734b75082e98', N'dziecko do lat 3')
INSERT [dbo].[Zamowienia] ([IdZamowienie], [Imie], [Nazwisko], [Mail], [Platnosc], [Status], [IdSeans], [Guid], [Ulga]) VALUES (12, N'Miłosz', N'Kukulski', N'dfgsfsfsf@sdgsd.pl', N'online', N'Niepotwierdzone', 2, N'418b61bc-89e6-4842-b7cf-7998a945802b', N'dziecko do lat 3')
SET IDENTITY_INSERT [dbo].[Zamowienia] OFF
GO
/****** Object:  Index [IX_Bilety_MiejsceIdMiejsce]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Bilety_MiejsceIdMiejsce] ON [dbo].[Bilety]
(
	[MiejsceIdMiejsce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bilety_ZamowienieIdZamowienie]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Bilety_ZamowienieIdZamowienie] ON [dbo].[Bilety]
(
	[ZamowienieIdZamowienie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Miejsca_IdZamowienie]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Miejsca_IdZamowienie] ON [dbo].[Miejsca]
(
	[IdZamowienie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seanse_IdFilm]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Seanse_IdFilm] ON [dbo].[Seanse]
(
	[IdFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seanse_IdSala]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Seanse_IdSala] ON [dbo].[Seanse]
(
	[IdSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Zamowienia_IdSeans]    Script Date: 06.05.2023 19:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_Zamowienia_IdSeans] ON [dbo].[Zamowienia]
(
	[IdSeans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Miejsca] ADD  DEFAULT ((0)) FOR [NrMiejsca]
GO
ALTER TABLE [dbo].[Zamowienia] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [Guid]
GO
ALTER TABLE [dbo].[Bilety]  WITH CHECK ADD  CONSTRAINT [FK_Bilety_Miejsca_MiejsceIdMiejsce] FOREIGN KEY([MiejsceIdMiejsce])
REFERENCES [dbo].[Miejsca] ([IdMiejsce])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bilety] CHECK CONSTRAINT [FK_Bilety_Miejsca_MiejsceIdMiejsce]
GO
ALTER TABLE [dbo].[Bilety]  WITH CHECK ADD  CONSTRAINT [FK_Bilety_Zamowienia_ZamowienieIdZamowienie] FOREIGN KEY([ZamowienieIdZamowienie])
REFERENCES [dbo].[Zamowienia] ([IdZamowienie])
GO
ALTER TABLE [dbo].[Bilety] CHECK CONSTRAINT [FK_Bilety_Zamowienia_ZamowienieIdZamowienie]
GO
ALTER TABLE [dbo].[Miejsca]  WITH CHECK ADD  CONSTRAINT [FK_Miejsca_Zamowienia_IdZamowienie] FOREIGN KEY([IdZamowienie])
REFERENCES [dbo].[Zamowienia] ([IdZamowienie])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Miejsca] CHECK CONSTRAINT [FK_Miejsca_Zamowienia_IdZamowienie]
GO
ALTER TABLE [dbo].[Seanse]  WITH CHECK ADD  CONSTRAINT [FK_Seanse_Filmy_IdFilm] FOREIGN KEY([IdFilm])
REFERENCES [dbo].[Filmy] ([IdFilm])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seanse] CHECK CONSTRAINT [FK_Seanse_Filmy_IdFilm]
GO
ALTER TABLE [dbo].[Seanse]  WITH CHECK ADD  CONSTRAINT [FK_Seanse_Sale_IdSala] FOREIGN KEY([IdSala])
REFERENCES [dbo].[Sale] ([IdSala])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seanse] CHECK CONSTRAINT [FK_Seanse_Sale_IdSala]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Seanse_IdSeans] FOREIGN KEY([IdSeans])
REFERENCES [dbo].[Seanse] ([IdSeans])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Seanse_IdSeans]
GO
USE [master]
GO
ALTER DATABASE [KinoDB] SET  READ_WRITE 
GO
