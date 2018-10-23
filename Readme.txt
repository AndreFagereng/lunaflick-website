Gruppe 20

Ludvik Lund		s309855
Andre Fagereng		s182417
Bendik Mørk Jørgensen	s301100
Øyvind Mjelstad		s315273
Kim Mikal Torp		s315278

Kjørbar løsning:	lunaflick.azurewebsites.net


Deler av koden er inspirert av forelesningsnotatene og videoene lagt ut på canvas. Vi har brukt
sikkerhets-kompendiet til å kryptere passord med salt. Vi har bruk forelesningsnotater og videoer til inspirasjon og lærdom.
Vi fant raskt ut at modaler var noe vi ønsket å bruke, men utover i prosjektet hadde vi en del trøbbel med hvordan de oppførte seg.

Mangler: 
	Brukervennelighet:
	- Beskrive siden bedre og gi et raskt inntrykk av hva siden dreier seg om. For uteforstaende er det vanskelig å vite siden egentlig tilbyr.
	
	- Lage en side med "Mine filmer" som viser filmene brukeren har kjøpt. Dette fikk vi ikke tid til i denne omgangen, men er jo en selvfølge å ha med i neste innlevering.
	
	- Markere alle filmer som allerede er kjøpt og gjøre dem u-klikkbare slik at man ikke kan kjøpe samme film to ganger
	
	Validering:
	- Backend-validering i C# fungerer ikke helt som det skal på vårt design. Login og Registrer bruker samme cshtml fil. 
	Det gjør at loginskjema krever da samme felter som registreringsskjema, som den ikke har. Det gjør at vi bare har Required på Epost og Passord. 
	Vi fant det ut for sent til å rekke å endre design. Vi har JS-validering i modalene.
	
	- Vi har laget vår egen JS-validering, istedet for å bruke JQuery-plugin. Vi er klar over at dette skaper problemer med backendvalidering ifm testing, men vi ville prøve likevel.

	Generelt:
	- Vi har flere metoder i kontrolleren som fremdeles jobber direkte mot databasen uten å gå gjennom et repository-layer.
	
	- Vi mener at strukturen på applikasjonen har et godt potensiale, men at det fremdeles er mye å gjøre for å gjøre det enklere å navigere i koden.

	- Navngivning av metoder og attributter kan forbedres for å gi økt forståelse av koden og gjøre den enklere å lese.


	
