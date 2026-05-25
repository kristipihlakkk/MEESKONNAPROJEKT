# GymSystem-  Jõusaali haldussüsteem

See on meie ISA II aine raames valminud meeskonnaprojekt. Tegime Blazor veebirakenduse jõusaali igapäevaseks haldamiseks, kus saab lisada liikmeid, osta neile liikmesusi, logida külastusi ja broneerida ruume.

## Mis see teeb

Rakendus teab kes on jõusaali liikmed, mis liikmesus neil on, millal nad käisid ja millised ruumid on olemas. Treener saab broneerida saali kindlaks ajaks. Admin haldab kõike.

## Käivitamine

Ava .slnx fail Visual Studios. Vali ülevalt rippmenüüst GymSystem (mitte GymSystem.Client) ja tõmbra projekt käime kas debugi kaudu, rebuildimisega või F5 või run nupuga. Brauser avaneb ise.

## Kuidas kood on üles ehitatud

Jagasime koodi 4 kihti nii et iga osa teab ainult sellest mis talle kuulub:

**Code/Data** on kõige tähtsamad klassid - Person, Room, Visit, Membership jne. Siin ei ole andmebaasi ega UI-d, ainult puhas C# kood.

**Code/Infra** ühendab need klassid andmebaasiga. Siin on EF Core repositooriumid ja SQLite migratsioonid.

**GymSystem** on server mis käivitab kõik. Program.cs registreerib kõik teenused.

**GymSystem.Client** on see mida kasutaja näeb- Blazor lehed, nupud, vormid.

**Tests** on ühiktestid, mis kontrollivad, et peamine äriloogika töötab õigesti.

## Miks kood on selline nagu ta on

Igal arhitektuurilikul otsusel on põhjus-  kõik otsused tulevad raamatutest mida kursusel lugesime.

**Arlow** andis meile Party Pattern idee. Probleem oli lihtne: treener on ka inimene, liige on ka inimene. Kui hoida neid eraldi tabelites, peaks sama Mari Tamme andmed olema kirjas kahes kohas. Arlowi lahendus on üks Person, mitu rolli. GymMember ja Trainer pärivad mõlemad PartyRole-st ja viitavad samale Person kirjele.

**Silverston** selgitas miks aadress peab olema eraldi tabelis. Üks inimene võib olla registreeritud mitme aadressiga-kodu, töö, suvila aadress. Kui panna aadress otse Person-i, saab olla ainult üks. Seetõttu on meil Party.Addresses kogumik.

**Martin** ütles et korduvat koodi ei tohi olla. Kõigil meie klassidel on Id, ValidFrom ja ValidTo ning need on BaseEntity-s. IRepo<T> on üldine liides mis töötab iga entiteediga, ei pea iga kord uuesti kirjutama.

**Evans** õpetas et äriloogika kuulub klassi, mitte lehele. IsActive() ja DaysRemaining() on Membership klassis, mitte Blazor lehel. HEhk siis EVnasi sõnade kohaselt mudel teab ise kas ta on kehtiv.

**Liberty** näidisprojekti järgi tegime kõik CRUD lehed ühtse mustriga- EditForm, OnValidSubmit, DataAnnotationsValidator. MyNavLink on üks komponent mis kordub 9 korda navmenüüs.

## Andmebaas

SQLite fail app.db. EF Core Code-First tähendab et kood defineerib andmebaasi struktuuri- kirjutad C# klassi, EF teeb tabeli. Migratsioonid jäädvustavad muudatused ajas, nagu Git commits andmebaasi jaoks.

## EDASIARENDUSED
Usume et projekt ei saagi kunagi vamis, kuna laati saab teha töökindamaks, kasutajasõbralikumaks ja turvalisemaks. Projektil on paljuu edasiarendusvõimalusi ja suur potentsiaal. Hetkel autentimist pole ning kõik kasutajad näevad kõike adminni vaates. Visioonis oli 3 rolli:
Klient  näeb ainult oma andmeid
Treener broneerib ruume, näeb oma broneeringuid
Admin haldab kõike
Vajaks ASP.NET Identity või JWT autentimist
samuti peaks lisama rohkem teste, et olla kindel programmi töökindluses
