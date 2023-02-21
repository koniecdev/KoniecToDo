# KoniecToDo
Zadanie rekrutacyjne - TELDAT - Artur Koniec - Junior .NET Developer
Instrukcja uruchomienia

Solucja składa się z dwóch części, klienta .NET 6 MVC "KoniecToDoApp", oraz Web API "KoniecToDo" opartego o architekturę cebuli.
Po pobraniu kodu, należy otworzyć i uruchomić projekt w Visual Studio, bądź uruchomić w cmd/ps poprzez .NET CLI przechodząc do folderu głównego
i posłużyć się komendą:

dotnet restore

w Folderze KoniecToDo, gdzie znajduje się KoniecToDo.csproj,
oraz w folderze KoniecToDoApp z projektem KoniecToDoApp.csproj

Należy utworzyć w SSMS SQLExpress utworzyć bazę danych nazywającą się dokładnie "ArturKoniecZadanie"
Można też użyć sqlcmd

CREATE DATABASE ArturKoniecZadanie;

w przypadku braku SQLExpress należy je zainstalować/zmienić connectionstring bazy danych znajdujący się 
w folderze projektu Web API "KoniecToDo" w pliku appsettings.json

następnie w folderze "Persistance" należy uruchomić komendę: 

dotnet ef database update

Co utworzy wymagane tabele i rekordy w bazie danych.

Następnie należy w dwóch oknach cmd uruchomić oba projekty, mvc i web api
Komende
dotnet run
należy uruchomić zarówno w folderze "KoniecToDo", jak i "KoniecToDoApp"

Adres Aplikacji MVC: https://localhost:7294/
Adres Web API: https://localhost:7127/swagger


W przypadku błędu związanego z certyfikatami, należy w trzecim osobnym oknie cmd użyć komend:

dotnet dev-certs https --clean
dotnet dev-certs https
dotnet dev-certs https --trust

Zrestartować projekty, zamknąć okno przeglądarki, uruchomić wszystko na nowo.
Błąd nie powinien się wyświetlić jeżeli zamiast przez .NET CLI uruchomimy projekty przez Visual Studio
Nie należy używać aplikacji po http, gdyż polityka CORS Web API zezwala tylko na połączenie po porcie https klienta.

OPIS PROJEKTU:
Wszystkie wytyczne zostały zrealizowane. Powiadomienia są zaimplementowane biblioteką SignalR.
Działają one na zasadzie: Gdy do "Deadline" zadania pozostaje minuta, na dole ekranu aplikacji klienckiej wyświetlany jest pasek z powiadomieniem:
Task $taskName is going to expire in a moment!
Cała implementacja SignalR znajduje się w warstwie Infrastructure

Projekt wykorzystuje wzorce Mediator, z wykorzystaniem biblioteki Mediator, z dołożeniem wzorca CQRS. 
Projekt testowałem jednostkowo frameworkiem xUnit.

Aplikacja kliencja to projekt .NET 6 MVC, z wspomaganiem się biblioteką jQuery dla osiągnięcia niektórych funkcjonalności.

Aplikacja działa na zasadzie tworzenia zadań, przypisując je do określonych list. Można filtrować wszystkie zadania/zadania z danej listy według określonego dnia, polem input na prawo od pola select do wyboru listy. Warto nadmienić że przycisk ten staje się dostępny dopiero po dodaniu przynajmniej jednego zadania do listy/jednego aktywnego zadania z istniejących list w przypadku braku zaznaczenia wyświetlania zadań z konkretnej listy.

Cały projekt został stworzony przeze mnie samego od zera w cztery dni.

