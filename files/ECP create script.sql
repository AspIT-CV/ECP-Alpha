USE Master
GO
DROP DATABASE IF EXISTS ECP;
CREATE DATABASE ECP;
USE ECP;
GO

CREATE TABLE Users(
	UserId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(256) NOT NULL,
	Description NVARCHAR(MAX)
);

CREATE TABLE Events(
	EventId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(256) NOT NULL,
	Description NVARCHAR(MAX),
	Address NVARCHAR(512) NOT NULL,
	StartTime DATETIME2,
	EndTime DATETIME2,
	OrganizerID_FK INT NOT NULL
);

CREATE TABLE Assignments(
	AssignmentId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(256) NOT NULL,
	Description NVARCHAR(MAX),
	StartTime DATETIME2,
	EndTime DATETIME2,
	VolunteersRequested INT NOT NULL,
	EventId_FK INT NOT NULL
);

CREATE TABLE AssignmentVolunteers(
	UserId INT NOT NULL,
	AssignmentId INT NOT NULL,
	IsSelected BIT NOT NULL DEFAULT 0
);

GO

ALTER TABLE Events
	ADD CONSTRAINT FK_OrganizerUser FOREIGN KEY (OrganizerId_FK) REFERENCES Users(UserId);

ALTER TABLE Assignments
	ADD CONSTRAINT FK_Event FOREIGN KEY (EventId_FK) REFERENCES Events(EventId);

ALTER TABLE AssignmentVolunteers
	ADD CONSTRAINT FK_VolunteerUser FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE AssignmentVolunteers
	ADD CONSTRAINT FK_Assignment FOREIGN KEY (AssignmentId) REFERENCES Assignments(AssignmentId);

GO

INSERT INTO Users (Name, Description) VALUES
	('Max Verstappen', 'God til at stå vagt, har gjort det mange gange.'),
	('Sergio Perez', 'jeg kan lave pandekager.'),
	('Lewis Hamilton', 'Jeg har ti års erfaring i at stå i bar.'),
	('George Russel', 'Lydmand gennem 18 år.'),
	('Daniel Ricciardo', 'AV mand'),
	('Lando Norris', 'Event koordinator.'),
	('Charles Leclerc', 'rengøring og oprydning.'),
	('Carlos Sainz', 'Koordination internt og eksternt.'),
	('Sebastian Vettel', 'Mulighederne for at få praktisk erfaring med arbejdet på det socialpædagogiske område betyder, at jeg meget gerne vil være jeres nye kollega. Som uddannet pædagog på Den Sociale Højskole, har jeg allerede en del erfaring og viden om regler og muligheder for udviklingshæmmede, men jeg savner at få endnu mere erfaring og viden, og jeg har en masse at give beboerne på Hanehøj. '),
	('Lance Stroll', 'Tålmodighed, konsekvens og omsorg er mine kerneværdier, der har ført mig ind i på det sociale fagområde, og de værdier vil Hanehøjs beboerne også få glæde af. Jeg vil især gerne arbejde på Hanehøj, fordi jeg fra bekendte har hørt, at I arbejder med beboernes personlige udvikling. Det område er jeg også optaget af, og ved at jeg kan være med til at skabe værdi i borgernes hverdag.'),
	('Valtteri Bottas', 'Event arrangør for DanEvent.'),
	('Zhou Gyanyo', 'De praktiske opgaver i beboernes lejligheder kan jeg tage mig af fra første dag. Dem har jeg erfaring med fra min tid som sommerferieafløser på Holbæks lokalcenter, hvor jeg har være de seneste år. Her blev jeg vant til at hjælpe med personlig hygiejne, betjening af personlift og rengøring, og det er jeg også klar til på Botilbuddet Hanehøj.'),
	('Mick Schumacher', 'Når en beboer på Hanehøj er trist, er det naturligt for mig at give plads og støtte f. eks. ved at sætte ord på og anerkende følelsen. Det er et af eksemplerne på, hvorfor jeg er en kompetent pædagog. Et andet eksempel er, at jeg respekterer, at weekender og aftentid er beboernes frirum. Her skal der være plads til afslapning eller aktiviteter alt efter humør.'),
	('Kevin Magnussen', 'I en tidligere stilling foretog jeg en rundspørge blandt over 8.000 kæledyrsejere. Det viste sig, at det ikke gør noget, om man ejer en tarantel eller en skildpadde: Hvad kæledyr har behov for og hvad deres ejere tror, at de har behov for, kan variere meget. En af mine store interesser er, hvordan kæledyr påvirker menneskers følelser. Det undersøger jeg på min ugentlige blog med 52.000 abonnenter.'),
	('Yuki Tsunoda', 'At forstå kunder (både dyr og mennesker) spiller en central rolle i min marketingsucces..'),
	('Pierre Gasly', 'Til stillingen som marketing koordinator til Petlife Media kræves der en person, som har erfaring med hver måned at levere nyt udstyr med engagerende kommunikation og viral markedsføring, nogen der kan skrive artikler, som kommer til at stå øverst på Googles resultatlister og som kan hjælpe kæledyrenes “forældre” med at realisere deres drømme om at gøre livet lidt mere behageligt for deres lille øjesten..'),
	('Nicholas Latifi', 'Jeg arbejdede i fem år hos Zooworld Dyrecenter i Herning. Det var en meget opløftende tid, hvor jeg samlede gode erfaringer. Nu flytter jeg til Herlev, og håber, at denne uopfordrede ansøgning og mit cv vil vække din interesse. Tag gerne et kik på de resultater, jeg har opnået, for at få et indtryk af mine færdigheder.'),
	('Alexander Albon', 'Analytisk beslutningstagning og grundig undersøgelse er nøglen til at skabe succes i en branche, hvor følelser kan tilsløre vurderingsevnen. Selvom jeg i hele min karriere har arbejdet inden for kæledyrspleje, har jeg ikke selv et kæledyr, fordi jeg tror, at objektivitet er grundlaget for at træffe gode markedsføringsbeslutninger. Ikke desto mindre har jeg en svaghed for kaniner.'),
	('Fernando Alonso', 'Hvis du er interesseret i at få mere at vide, vil jeg med glæde uddybe min ansøgning i en jobsamtale for at fortælle mere om, hvordan jeg vil inspirere dine kunder og gøre deres kæledyr glade.'),
	('Esteban Ocon', 'Jeg er verdens bedste parkeringsvagt');

INSERT INTO Events(Name, Description, Address, StartTime, EndTime, OrganizerID_FK) VALUES
	('Velkommen til 90erne!','Efter fattigfirserne blev 90erne på mange måder optimismens årti med den endelige afslutning af Den Kolde Krig og en teknologisk udvikling, der gav mulighed for at klone fåret Dolly, spille Snake på Nokias mobiltelefoner og udforske verden online på det hastigt voksende World Wide Web.','Vejle Musikteater, Ved Rundkørslen 1, 7100 Vejle','2022-10-01 19:00:00','2022-10-01 23:00:00', 5),
	('Demonstration for mere hjernekapacitet blandt folk','Store dyr har normalt store hjerner. For at sammenligne hjernen mellem store og små dyr bruger man den relative hjernestørrelse. Den relative hjernestørrelse beskrives tit med den såkaldte encefaliseringskoefficient (EQ), der er en funktion af hjernens og kroppens vægt. Der er foreslået flere forskellige formler for EQ, for eksempel af Jerison i 1973','Christiansborg','2022-10-04 10:00:00','2022-10-05 20:00:00', 9),
	('Ølsmagning BLAS','I Danmark kan vi godt lide øl. Det betyder også, at vi godt kan lide gaver med øl. Ølgaver kan være øl i sig selv, men det kan også være en oplevelsesgave, i form af en ølsmagning. En ølsmagnings oplevelse er den perfekte gave til øl entusiasten. Her bliver der ikke kun smagt på en række gode øl. Ofte får du også rundvisning på bryggeriet, og indblik i, hvordan man smager på øl, samt fortællinger om øllets historie og brygningsmetoder.','Ahornvej 1, 7183 Randbøl','2022-11-20 15:00:00','2022-11-20 20:00:00', 10),
	('Borgermøde om ny vindmøllepark','Iskolde vinde susede gennem lokalet, da Andel holdt borgermøde om vindmølleplanerne ved Klintebjerg. Modstanderne var højlydte og greb fat i alt lige fra børnetallet i Pakistan til skønhedsværdien ved mørket over havet.','Ammitsbøl Forsamlingshus, Koldingvej 246, 6852 Ny Højen','2022-11-30 19:00:00','2022-11-30 22:30:00', 5);

INSERT INTO Assignments(Name, Description, VolunteersRequested, StartTime, EndTime, EventId_FK) VALUES
	('Bartjans', 'Servering i baren', 5, '2022-10-01 18:00:00','2022-10-02 00:00:00',1),
	('Sikkerhedvagt ved indgang', 'Sikkerhedvagt ved indgang', 2, '2022-10-01 18:00:00','2022-10-01 19:30:00',1),
	('Lyd og lys', 'AV teknik o.a.', 1, '2022-10-01 12:00:00','2022-10-02 00:00:00',1),
	('Ordstyrer','Talerækkefølge m.m.',1,'2022-11-30 19:00:00','2022-11-30 22:30:00', 4);

