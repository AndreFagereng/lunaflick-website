Gruppe 20

Ludvik Lund		s309855
Andre Fagereng		s182417
Bendik M�rk J�rgensen	s301100
�yvind Mjelstad		s315273
Kim Mikal Torp		s315278

Kj�rbar l�sning:	lunaflick.azurewebsites.net


Deler av koden er inspirert av forelesningsnotatene og videoene lagt ut p� canvas. Vi har brukt
sikkerhets-kompendiet til � kryptere passord med salt. Vi har bruk forelesningsnotater og videoer til inspirasjon og l�rdom.
Vi fant raskt ut at modaler var noe vi �nsket � bruke, men utover i prosjektet hadde vi en del tr�bbel med hvordan de oppf�rte seg.

Mangler: 
	Brukervennelighet:
	- Beskrive siden bedre og gi et raskt inntrykk av hva siden dreier seg om. For uteforstaende er det vanskelig � vite siden egentlig tilbyr.
	
	- Lage en side med "Mine filmer" som viser filmene brukeren har kj�pt. Dette fikk vi ikke tid til i denne omgangen, men er jo en selvf�lge � ha med i neste innlevering.
	
	- Markere alle filmer som allerede er kj�pt og gj�re dem u-klikkbare slik at man ikke kan kj�pe samme film to ganger
	
	Validering:
	- Backend-validering i C# fungerer ikke helt som det skal p� v�rt design. Login og Registrer bruker samme cshtml fil. 
	Det gj�r at loginskjema krever da samme felter som registreringsskjema, som den ikke har. Det gj�r at vi bare har Required p� Epost og Passord. 
	Vi fant det ut for sent til � rekke � endre design. Vi har JS-validering i modalene.
	
	- Vi har laget v�r egen JS-validering, istedet for � bruke JQuery-plugin. Vi er klar over at dette skaper problemer med backendvalidering ifm testing, men vi ville pr�ve likevel.

	Generelt:
	- Vi har flere metoder i kontrolleren som fremdeles jobber direkte mot databasen uten � g� gjennom et repository-layer.
	
	- Vi mener at strukturen p� applikasjonen har et godt potensiale, men at det fremdeles er mye � gj�re for � gj�re det enklere � navigere i koden.

	- Navngivning av metoder og attributter kan forbedres for � gi �kt forst�else av koden og gj�re den enklere � lese.


	
