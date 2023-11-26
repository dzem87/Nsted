# Nøsted

Navn på medlemmer:
- Anita
- Caroline
- Dzemil
- Nora
- Victoria

**Dokumentasjon:**

**Prosjektets mål:** 

Det overordna målet med prosjektet er å utvikle en web-applikasjon som kobler sammen og digitaliserer dagens system. Nøsted& AS har utviklet vedlikeholds-/reparasjons sjekklister som mekanikerne bruker for å utføre ulike sjekker, som nå i dag benyttes i papirform. Den digitale webapplikasjonen har derfor som formål å forenkle registrering av serviceordre, og samtidig lykkes med et system som oppleves brukervennlig for mekanikere og administrativt personell. Dette gjøres gjennom responsive HTML sider knyttet opp mot database, samt sikkerhet i form av XSS og CSRF. I tillegg til registrering og innloggingsfunksjon for autorisering og autentisering. 

*Verktøy:*
- Applikasjonen skal kjøre gjennom **Docker**
- **MariaDb** er brukt til databaselagring
- **Entity Framework** er brukt til databasehåndtering
- Koden er skrevet i **C#** og følger **MVC** mønsteret

*Kjøring av applikasjonen:* 

NB: På Unix og Unix-lignende systemer (Mac and Linux) kan det hende at du må kjøre kommandoene med sudo for å få det til å fungere.

1. Kjøre applikasjonen i Docker ved å bygge et image og en container 

     docker image build -t nsted .
     docker container run --rm -it -d --name nsted --publish 80:80 nsted


Start mariadb container 

Naviger til ønsket lokal lagringsplassering 
Erstatt innholdet i anførselstegnene med korrekt mappesti

| Bash (Mac og Linux) | Powershell (Windows)|
| ------------- | ------------- |
| docker run --rm --name mariadb -p 3308:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=1234 -d mariadb:10.5.11l  | docker run --rm --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=1234 -d mariadb:10.5.11  |


3. Gå inn i den opprettede MariaDb konteineren 

      docker exec -it mariadb bash



4. Logg inn i MariaDb 

      mariadb -u root -p 

Passord: 1234


5. Opprett databaser 


      CREATE DATABASE NstedDb;

      CREATE DATABASE NstedAuthDb; 


6. Oppdater databasene 

Åpne terminal eller powershell og naviger til prosjektets mappe (prosjektet må være clonet ned fra github)


| Bash (Mac og Linux) | Powershell (Windows)|
| ------------- | ------------- |
| dotnet ef database update --context NstedDbContext  | update-database -context NstedDbContext |
|dotnet ef database update --context AuthDbContext  | update-database -context AuthDbContext  |


7. Test koden med http:localhost:80/
Notat: Kan hende Unix systemer må kjøre uten http:


*Videreutvikling av prosjektet:*

Det er tillatt å kopiere koden:) 

Prosjektet bygger på en MVC mønsteret. 
Modeller inneholder informasjon knyttet til ulike entiteter (Service,Kunde, Sjekkliste osv.).
Controllere muliggjør CRUD operasjoner på de ulike entitetene i databasen, og bruker repositories for å kommunisere med databasen. 
Controlleren inneholder metoder som sendes til repository, som har ansvaret for å kommunisere med databasen via context klassen. Interfacet definerer metodene som er implementert i repository. Dette ble gjort for å oppnå good cohesion og fordele ansvarsområder. 

View tar imot data fra controlleren og presenterer det for brukeren. Presenterer dataene for brukeren.
Basert på dette har applikasjonen god struktur, som gjør det enkelt å videreutvikle modellene slik at tabeller kan kobles sammen. Det gjør det også mulig å endre enkelte deler av applikasjonen uavhengig av å måtte endre resten av applikasjonen.  

