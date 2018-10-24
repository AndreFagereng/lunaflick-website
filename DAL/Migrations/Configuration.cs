namespace PresentationLayer.Migrations
{
    using DAL;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LunaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Oblig1.Models.LunaContext";
        }

        protected override void Seed(LunaContext context)
        {
            var allMovies = new List<Movie>
            {
				//DRAMA
				new Movie
                {
                    Title = "Gjøkeredet",
                    Genre = "Drama",
                    Stars = 8.7,
                    Storyline = "McMurphy plasseres på et sinnssykehus hvor alle pasientene er sløvet ned av" +
                                 "medikamenter og underkastet sykehusledelsen og oversøster Ratched." +
                                 "McMurphy gjør opprør fra første stund og etterhvert får han de andre pasientene med seg. " +
                                  "Hans opprør tas imidlertid ille opp av stedets ledelse og de ser seg derfor nødt til å knekke ham.",
                    ContentRating = "15",
                    ReleaseYear = "1975",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BZjA0OWVhOTAtYWQxNi00YzNhLWI4ZjYtNjFjZTEyYjJlNDVlL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,672,1000_AL_.jpg",
                    Director = "Milos Forman",
                    Duration = "132 min"
                },
                new Movie
                {
                    Title = "Jakten",
                    Genre = "Drama",
                    Stars = 8.3,
                    Storyline = "Jakten er en foruroligende skildring av hvordan løgn blir til sannhet - en moderne fortelling om heksejakt, " +
                                "urettferdighet, skyld og tilgivelse. En beretning om hvor skrøpelig fellesskapet er, når sladder, tvil og " +
                                "ondskap får lov til å spre om seg.",
                    ContentRating = "15",
                    ReleaseYear = "2012",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNDM2MzMwMzcxNF5BMl5BanBnXkFtZTcwNTczMDk3OA@@._V1_SY1000_CR0,0,681,1000_AL_.jpg",
                    Director = "Thomas Vinterberg",
                    Duration = "115 min"
                },
                new Movie
                {

                    Title = "Frihetens regn",
                    Genre = "Drama",
                    Stars = 9.3,
                    Storyline = "Andy Dufrenes’ kone bedrar ham, når hun så blir drept og Andy kan plasseres på åstedet bærer det rett i kasjotten. " +
                                "Shawshank-fengselet er så visst ingen anstalt for mors beste barn, der vaktene har sadisme og tortur som hobby.",
                    ContentRating = "15",
                    Director = "Frank Darabont",
                    Duration = "142 min",
                    ReleaseYear = "1994",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                },
                new Movie
                {
                    Title = "Forrest Gump",
                    Genre = "Drama",
                    Stars = 8.8,
                    Storyline = "Forrest Gump er en enkel mann som sitter på en benk og forteller fremmede mennesker om sin fantastiske livshistorie. " +
                                "Gjennom hans uskyldige, naive og godtroende synsvinkel er vi vitne til en rekke viktige hendelser som bidro til å forme det 20. århundre.",
                    ContentRating = "11",
                    Director = "Robert Zemeckis",
                    Duration = "142 min",
                    ReleaseYear = "1994",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg"
                },
                    new Movie
                {
                    Title = "12 Angry Men",
                    Genre = "Drama",
                    Stars = 8.9,
                    Storyline = "Et jurymedlem (Henry Fonda) som må prøve å overbevise de 11 andre medlemmene om å la en drapsmistenkte frikjennes, " +
                                "fordi tvilen bør falle han til gode.",
                    ContentRating = "15",
                    Director = "Sidney Lumet",
                    Duration = "96 min",
                    ReleaseYear = "1957",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMWU4N2FjNzYtNTVkNC00NzQ0LTg0MjAtYTJlMjFhNGUxZDFmXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SY1000_CR0,0,649,1000_AL_.jpg"

                },
                    new Movie
                    {
                        Title = "City of God",
                        Genre = "Drama",
                        Stars = 8.6,
                        Storyline = "Filmen handler om livet i favelaen Cidade de Deus, en av slummene i Rio de Janeiro. De fleste skuespillerne hadde aldri spilt før, og kommer fra forskjellige favelaer. " +
                                    "Filmen ble dog ikke spilt inn i Cidade de Deus, av sikkerhetsmessige grunner.",
                        ContentRating = "15",
                        Director = " Fernando Meirelles",
                        Duration = "130 min",
                        ReleaseYear = "2002",
                        Price = 80.00,
                        Poster = "https://m.media-amazon.com/images/M/MV5BMGU5OWEwZDItNmNkMC00NzZmLTk1YTctNzVhZTJjM2NlZTVmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,677,1000_AL_.jpg"
                    },
				//ACTION

				new Movie
                {
                       Title = "The Matrix",
                    Genre = "Action",
                    Stars = 8.7,
                    Storyline = "Tenk deg at virkeligheten er en drøm. Denne tanken forfølger Thomas Anderson (Keanu Reeves). Thomas lever et dobbeltliv, " +
                                "om dagen er han ansatt i et stort datafirma, om natten er han hackeren Neo, en langer av virtuelle fantasier.",
                    ContentRating = "15",
                    Director = "The Wachowski Brothers",
                    Duration = "136 min",
                    ReleaseYear = "1999",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg"
                },
                new Movie
                {
                   Title = "Die Hard",
                    Genre = "Action",
                    Stars = 8.2,
                    Storyline = "John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                    ContentRating = "18",
                    Director = "John McTiernan",
                    Duration = "132 min",
                    ReleaseYear = "1988",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMzNmY2IwYzAtNDQ1NC00MmI4LThkOTgtZmVhYmExOTVhMWRkXkEyXkFqcGdeQXVyMTk5NDA3Nw@@._V1_.jpg"
                },
                new Movie
                {

                    Title = "Mad Max: Fury Road",
                    Genre = "Action",
                    Stars = 8.1,
                    Storyline = "Max (Tom Hardy) blir motvillig tatt med i jakten på Furiosa (Charlize Theron), som har stjålet noe verdifullt fra krigsherren Udødelige Joe (Hugh Keays-Byrne), nemlig avlsmødrene som skal føde hans avkom.",
                    ContentRating = "15",
                    Director = "George Miller",
                    Duration = "120 min",
                    ReleaseYear = "2015",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    Genre = "Action",
                    Stars = 9.0,
                    Storyline = "Det har gått ett år siden Batman reddet Gotham fra Ra's Al Ghul. En bank blir ranet av en gjeng maskerte tyver. Men når alt kommer til alt er det kun én mann " +
                    "som står igjen som vinneren – den gale The Joker (Heath Ledger), som gjerne vil se hele verden gå under for sine føtter.",
                    ContentRating = "15",
                    Director = "Christopher Nolan",
                    Duration = "152 min",
                    ReleaseYear = "2008",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "Kill Bill: Vol 1",
                    Genre = "Action",
                    Stars = 8.1,
                    Storyline = "Leiemorderen The Bride obber i elitegruppen DiVAS. Da hun velger å forlate karrieren for å bli smidd i hymnens lenker, blir det ikke tatt nådig opp av sjefen hennes, Bill. " +
                                "Han sørger for å sende hennes tidligere kolleger til bryllupet for å lage et blodbad. På mirakuløst vis overlever The Bride å bli skutt i hodet, " +
                                "men havner i koma. Fire år senere våkner hun opp fast bestemt på hevn.",
                    ContentRating = "15",
                    Director = "Quentin Tarantino",
                    Duration = "111 min",
                    ReleaseYear = "2003",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNzM3NDFhYTAtYmU5Mi00NGRmLTljYjgtMDkyODQ4MjNkMGY2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
                },
                new Movie
                {
                    Title = "Inception",
                    Genre = "Action",
                    Stars = 8.8,
                    Storyline = "Handlingen er satt til en verden hvor drømmer i stor grad styrer verdens rundgang. Dom Cobb (Leonardo DiCaprio) er verdens beste på en illegal ting kalt \"extraction\" – " +
                                "han kan bryte seg inn i folks drømmer og stjele ideer – noe han både har profittert på og tapt på, siden han også mistet " +
                                "familien på grunn av evnene sine, og samtidig er en av Amerikas mest ettersøkte menn.",
                    ContentRating = "15",
                    Director = "Christopher Nolan",
                    Duration = "148 min",
                    ReleaseYear = "2010",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                },
				//KOMEDIER
				new Movie
                {
                    Title = "The Big Lebowski",
                    Genre = "Komedie",
                    Stars = 8.1,
                    Storyline = "Jeff Bridges spiller Jeffrey Lebowski, en arbeidsledig etterlevning fra hippietiden som går under kallenavnet «The Dude». The Dude, hvis " +
                                "hovedinteresser er bowling, pot og White Russian, blir overfalt i sin leilighet av pornoprodusenten Jackie Treehorns muskelmenn, " +
        "						som krever å få tilbakebetalt gjelda til The Dudes påståtte kone Bunny.",
                    Director = "Joel & Ethan Coen",
                    Duration = "117 min",
                    ReleaseYear = "1998",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BZTFjMjBiYzItNzU5YS00MjdiLWJkOTktNDQ3MTE3ZjY2YTY5XkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SY1000_CR0,0,665,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "Tilbake til Fremtiden",
                    Genre = "Komedie",
                    Stars = 8.5,
                    Storyline = "Marty McFly, en 17 år gammel gutt som går på videregående skole, og som liker å skate og spille på el-gitar, blir invitert av vennen hans " +
                                "Dr. Emmet Brown, en eksentrisk lokal vitenskapsmann, for å se på en demonstrasjon av Doktorens nyeste oppfinnelse: en modifisert DeLorean " +
                                "DMC-12 som kan reise i tid. For å dra gjennom tiden, må man nå 140 km/t.",
                    ContentRating = "12",
                    Director = "Robert Zemeckis",
                    Duration = "116 min",
                    ReleaseYear = "1985",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,643,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "The Great Dictator",
                    Genre = "Komedie",
                    Stars = 8.5,
                    Storyline = "Diktatoren handler om en jødisk barberer (Charlie Chaplin) som pådrar seg hukommelsestap etter en krigsskade under første verdenskrig. " +
                                "Som pasient i diverse sykehus er han derfor beskyttet for forandringene i hjemlandet Tomania (omskrivining av Tyskland).",
                    ContentRating = "12",
                    Director = "Charles Chaplin",
                    Duration = "125 min",
                    ReleaseYear = "1940",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMmExYWJjNTktNGUyZS00ODhmLTkxYzAtNWIzOGEyMGNiMmUwXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,676,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "Hot Fuzz",
                    Genre = "Komedie",
                    Stars = 7.9,
                    Storyline = "Nicholas Angel (Simon Pegg) er den beste politimannen i London, med en arrestasjonsrekord 400% høyere enn noen andre i styrken. " +
                                "Han er så god at han gjør slik at alle andre ser skikkelig talentløse ut. Som et resultat av dette sender Angels overordnede ham til et " +
                                "sted der hans talent ikke vil gjøre dem alle til skamme - den søvnige og tilsynelatende lovlydige landsbyen Sandford.",
                    ContentRating = "12",
                    Director = "Edgar Wright",
                    Duration = "121 min",
                    ReleaseYear = "2007",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMzg4MDJhMDMtYmJiMS00ZDZmLThmZWUtYTMwZDM1YTc5MWE2XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY999_CR0,0,672,999_AL_.jpg"
                },
                new Movie
                {
                    Title = "The Wolf of Wallstreet",
                    Genre = "Komedie",
                    Stars = 8.2,
                    Storyline = "Filmen sentrerer seg rundt Jordan Belfort (Leonardo DiCaprio), en aksjemegler på Wall Street som måtte sitte 20 måneder i fengsel etter å ha " +
                                "innrømmet å ha drevet en \"Pump & Dump\" svindel og hvitvasking av penger. Han fikk redusert fengselsstraff fordi han samarbeidet med politiet " +
                                "og tystet på tidligere kollega og samarbeidspartnere.",
                    ContentRating = "15",
                    Director = "Martin Scorsese",
                    Duration = "180 min",
                    ReleaseYear = "2013",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SY1000_CR0,0,674,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "Hjemme Alene",
                    Genre = "Komedie",
                    Stars = 7.5,
                    Storyline = "Dagen etter en familiekrangel blir åtteåringen Kevin McCallister ved en feil etterlatt hjemme da familien reiser på juleferie. " +
                                "Dette er første gang han ikke har noen voksne å forholde seg til, og han utnytter muligheten til å sove i foreldrenes store seng, " +
                                "samt en rekke andre ting han ellers ikke får lov til. Men han oppdager at det også finnes ulemper med å være hjemme alene." ,
                    ContentRating = "11",
                    Director = "Chris Colombus",
                    Duration = "103 min",
                    ReleaseYear = "1990",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,672,1000_AL_.jpg"

                },
				//BARNEFILMER
				new Movie
                {
                    Title = "Ratatouille ",
                    Genre = "Barn",
                    Stars = 8.0,
                    Storyline = "I den animerte filmen, \"Rottatouille\", drømmer rotta Remy om å bli en fransk mesterkokk, mot familiens ønsker og det faktum at han er en " +
                                "rotte i en desidert gnagerfiendtlig yrkesgruppe.",
                    ContentRating = "5",
                    Director = "Brad Bird",
                    Duration = "111 min",
                    ReleaseYear = "2007",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMTMzODU0NTkxMF5BMl5BanBnXkFtZTcwMjQ4MzMzMw@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",

                },
                    new Movie
                {
                    Title = "Oppdrag Nemo",
                    Genre = "Barn",
                    Stars = 8.1,
                    Storyline = "Filmen har en enkel historie, hvor den lille klovnefisken «Nemo» har verdens mest overbeskyttende alenepappa, «Marlin». " +
                                "«Nemo» blir fanget av en tannlege og hobbydykker i Sydney og «Marlin» må trosse alle sine nevroser for å redde sønnen sin. " +
                                "Med seg på turen har han med seg palettkirurgifisken «Dory», som har ekstremt dårlig korttidshukommelse men som også er utrolig hjertelig.",
                    ContentRating = "5",
                    Director = "Andrew Stanton",
                    Duration = "100 min",
                    ReleaseYear = "2003",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BZjMxYzBiNjUtZDliNC00MDAyLTg3N2QtOWNjNmNhZGQzNDg5XkEyXkFqcGdeQXVyNjE2MjQwNjc@._V1_.jpg"

                },
                        new Movie
                {
                    Title = "Alvin og Gjengen",
                    Genre = "Barn",
                    Stars = 5.2,
                    Storyline = "Vi møter de tre ekornene mens de ser deres hjem blir hugget ned for å brukes som juletre, mens de fortsatt er inne i det. " +
                                "De ender opp i lobbyen til Jet Records hvor de hopper opp i muffinskurven til Dave som er på vei hjem etter å ha blitt kastet ut fra " +
                                "plateselskapet, som mener han ikke kan skrive sanger." ,
                    ContentRating = "5",
                    Director = "Tim Hill",
                    Duration = "92 min",
                    ReleaseYear = "2007",
                    Price = 65.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjdmNWY4MjItMjBiMi00MWNiLWI0ZjctYzBjZmEzOGRmNTc5XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,678,1000_AL_.jpg"
                },
                new Movie
                {
                    Title = "Småspioner",
                    Genre = "Barn",
                    Stars = 5.5,
                    Storyline = "Carmen (Alexa Vega) og Juni (Daryl Sabara) er to helt normale barn som har helt alminnelig kjedelige foreldre. Det er iallfall det de tror, " +
                                "helt til de finner ut at foreldrene Gregorio (Antonio Banderas) og Ingrid (Carla Gugino) er tidligere topptrente hemmelige agenter som blir " +
                                "tvunget tilbake i bransjen når de hører at flere av kollegene deres har forsvunnet på mystisk vis. ",
                    ContentRating = "5",
                    Director = "Robert Rodriguez",
                    Duration = "88 min",
                    ReleaseYear = "2001",
                    Price = 65.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BY2JhODU1NmQtNjllYS00ZmQwLWEwZjYtMTE5NjA1M2YyMzdjXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,673,1000_AL_.jpg"

                },
                new Movie
                {
                    Title = "Paddington 2",
                    Genre = "Barn",
                    Stars = 7.9,
                    Storyline = "Da Paddington leter etter den perfekte presangen til sin tante Lucys hundreårsdag finner han en bok i Herr Grubers butikk. " +
                                "For å få råd til å kjøpe boken må Paddington begynne å jobbe. Men plutselig blir boken stjålet! Nå er det opp til Paddington " +
                                "og familien Brown å avsløre tyven" ,
                    ContentRating = "5",
                    Director = "Paul King",
                    Duration = "103 min",
                    ReleaseYear = "2017",
                    Price = 80.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMmYwNWZlNzEtNjE4Zi00NzQ4LWI2YmUtOWZhNzZhZDYyNmVmXkEyXkFqcGdeQXVyNzYzODM3Mzg@._V1_.jpg"

                },
                new Movie
                {
                    Title = "Grusomme Meg",
                    Genre = "Barn",
                    Stars = 7.7,
                    Storyline = "Gru er en bitter og middelmådig småkriminell som tenker altfor høyt om seg selv. Han bestemmer seg for å sette seg selv på kartet ved å " +
                                "gjøre det største kuppet noensinne - nemlig å stjele månen. Han adopterer derfor tre jenter, som inngår i planen for å spionere på fienden Vector. " +
                                "Men når Gru faktisk gradvis begynner å bry seg om barna, står hele planen i fare, siden disse to tingene ikke lar seg kombinere. " ,
                    ContentRating = "5",
                    Director = "Pierre Coffin",
                    Duration = "95 min",
                    ReleaseYear = "2010",
                    Price = 100.00,
                    Poster = "https://m.media-amazon.com/images/M/MV5BMTY3NjY0MTQ0Nl5BMl5BanBnXkFtZTcwMzQ2MTc0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                },
            };



            foreach (Movie m in allMovies)
            {
                context.Movies.Add(m);
            }
			
        }


    }
}

