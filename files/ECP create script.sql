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
	('Max Verstappen', 'God til at st� vagt, har gjort det mange gange.'),
	('Sergio Perez', 'jeg kan lave pandekager.'),
	('Lewis Hamilton', 'Jeg har ti �rs erfaring i at st� i bar.'),
	('George Russel', 'Lydmand gennem 18 �r.'),
	('Daniel Ricciardo', 'AV mand'),
	('Lando Norris', 'Event koordinator.'),
	('Charles Leclerc', 'reng�ring og oprydning.'),
	('Carlos Sainz', 'Koordination internt og eksternt.'),
	('Sebastian Vettel', 'Mulighederne for at f� praktisk erfaring med arbejdet p� det socialp�dagogiske omr�de betyder, at jeg meget gerne vil v�re jeres nye kollega. Som uddannet p�dagog p� Den Sociale H�jskole, har jeg allerede en del erfaring og viden om regler og muligheder for udviklingsh�mmede, men jeg savner at f� endnu mere erfaring og viden, og jeg har en masse at give beboerne p� Haneh�j. '),
	('Lance Stroll', 'T�lmodighed, konsekvens og omsorg er mine kernev�rdier, der har f�rt mig ind i p� det sociale fagomr�de, og de v�rdier vil Haneh�js beboerne ogs� f� gl�de af. Jeg vil is�r gerne arbejde p� Haneh�j, fordi jeg fra bekendte har h�rt, at I arbejder med beboernes personlige udvikling. Det omr�de er jeg ogs� optaget af, og ved at jeg kan v�re med til at skabe v�rdi i borgernes hverdag.'),
	('Valtteri Bottas', 'Event arrang�r for DanEvent.'),
	('Zhou Gyanyo', 'De praktiske opgaver i beboernes lejligheder kan jeg tage mig af fra f�rste dag. Dem har jeg erfaring med fra min tid som sommerferieafl�ser p� Holb�ks lokalcenter, hvor jeg har v�re de seneste �r. Her blev jeg vant til at hj�lpe med personlig hygiejne, betjening af personlift og reng�ring, og det er jeg ogs� klar til p� Botilbuddet Haneh�j.'),
	('Mick Schumacher', 'N�r en beboer p� Haneh�j er trist, er det naturligt for mig at give plads og st�tte f. eks. ved at s�tte ord p� og anerkende f�lelsen. Det er et af eksemplerne p�, hvorfor jeg er en kompetent p�dagog. Et andet eksempel er, at jeg respekterer, at weekender og aftentid er beboernes frirum. Her skal der v�re plads til afslapning eller aktiviteter alt efter hum�r.'),
	('Kevin Magnussen', 'I en tidligere stilling foretog jeg en rundsp�rge blandt over 8.000 k�ledyrsejere. Det viste sig, at det ikke g�r noget, om man ejer en tarantel eller en skildpadde: Hvad k�ledyr har behov for og hvad deres ejere tror, at de har behov for, kan variere meget. En af mine store interesser er, hvordan k�ledyr p�virker menneskers f�lelser. Det unders�ger jeg p� min ugentlige blog med 52.000 abonnenter.'),
	('Yuki Tsunoda', 'At forst� kunder (b�de dyr og mennesker) spiller en central rolle i min marketingsucces..'),
	('Pierre Gasly', 'Til stillingen som marketing koordinator til Petlife Media kr�ves der en person, som har erfaring med hver m�ned at levere nyt udstyr med engagerende kommunikation og viral markedsf�ring, nogen der kan skrive artikler, som kommer til at st� �verst p� Googles resultatlister og som kan hj�lpe k�ledyrenes �for�ldre� med at realisere deres dr�mme om at g�re livet lidt mere behageligt for deres lille �jesten..'),
	('Nicholas Latifi', 'Jeg arbejdede i fem �r hos Zooworld Dyrecenter i Herning. Det var en meget opl�ftende tid, hvor jeg samlede gode erfaringer. Nu flytter jeg til Herlev, og h�ber, at denne uopfordrede ans�gning og mit cv vil v�kke din interesse. Tag gerne et kik p� de resultater, jeg har opn�et, for at f� et indtryk af mine f�rdigheder.'),
	('Alexander Albon', 'Analytisk beslutningstagning og grundig unders�gelse er n�glen til at skabe succes i en branche, hvor f�lelser kan tilsl�re vurderingsevnen. Selvom jeg i hele min karriere har arbejdet inden for k�ledyrspleje, har jeg ikke selv et k�ledyr, fordi jeg tror, at objektivitet er grundlaget for at tr�ffe gode markedsf�ringsbeslutninger. Ikke desto mindre har jeg en svaghed for kaniner.'),
	('Fernando Alonso', 'Hvis du er interesseret i at f� mere at vide, vil jeg med gl�de uddybe min ans�gning i en jobsamtale for at fort�lle mere om, hvordan jeg vil inspirere dine kunder og g�re deres k�ledyr glade.'),
	('Esteban Ocon', 'Jeg er verdens bedste parkeringsvagt');

INSERT INTO Events(Name, Description, Address, StartTime, EndTime, OrganizerID_FK) VALUES
	('Velkommen til 90erne!','Efter fattigfirserne blev 90erne p� mange m�der optimismens �rti med den endelige afslutning af Den Kolde Krig og en teknologisk udvikling, der gav mulighed for at klone f�ret Dolly, spille Snake p� Nokias mobiltelefoner og udforske verden online p� det hastigt voksende World Wide Web.','Vejle Musikteater, Ved Rundk�rslen 1, 7100 Vejle','2022-10-01 19:00:00','2022-10-01 23:00:00', 5),
	('Demonstration for mere hjernekapacitet blandt folk','Store dyr har normalt store hjerner. For at sammenligne hjernen mellem store og sm� dyr bruger man den relative hjernest�rrelse. Den relative hjernest�rrelse beskrives tit med den s�kaldte encefaliseringskoefficient (EQ), der er en funktion af hjernens og kroppens v�gt. Der er foresl�et flere forskellige formler for EQ, for eksempel af Jerison i 1973','Christiansborg','2022-10-04 10:00:00','2022-10-05 20:00:00', 9),
	('�lsmagning BLAS','I Danmark kan vi godt lide �l. Det betyder ogs�, at vi godt kan lide gaver med �l. �lgaver kan v�re �l i sig selv, men det kan ogs� v�re en oplevelsesgave, i form af en �lsmagning. En �lsmagnings oplevelse er den perfekte gave til �l entusiasten. Her bliver der ikke kun smagt p� en r�kke gode �l. Ofte f�r du ogs� rundvisning p� bryggeriet, og indblik i, hvordan man smager p� �l, samt fort�llinger om �llets historie og brygningsmetoder.','Ahornvej 1, 7183 Randb�l','2022-11-20 15:00:00','2022-11-20 20:00:00', 10),
	('Borgerm�de om ny vindm�llepark','Iskolde vinde susede gennem lokalet, da Andel holdt borgerm�de om vindm�lleplanerne ved Klintebjerg. Modstanderne var h�jlydte og greb fat i alt lige fra b�rnetallet i Pakistan til sk�nhedsv�rdien ved m�rket over havet.','Ammitsb�l Forsamlingshus, Koldingvej 246, 6852 Ny H�jen','2022-11-30 19:00:00','2022-11-30 22:30:00', 5);

INSERT INTO Assignments(Name, Description, VolunteersRequested, StartTime, EndTime, EventId_FK) VALUES
	('Bartjans', 'Servering i baren', 5, '2022-10-01 18:00:00','2022-10-02 00:00:00',1),
	('Sikkerhedvagt ved indgang', 'Sikkerhedvagt ved indgang', 2, '2022-10-01 18:00:00','2022-10-01 19:30:00',1),
	('Lyd og lys', 'AV teknik o.a.', 1, '2022-10-01 12:00:00','2022-10-02 00:00:00',1),
	('Ordstyrer','Taler�kkef�lge m.m.',1,'2022-11-30 19:00:00','2022-11-30 22:30:00', 4);

INSERT INTO AssignmentVolunteers VALUES
	(1,4,0),
	(7,4,0),
	(17,1,1),
	(13,1,1),
	(15,1,1);