controller -> a C# class that inherits from Controller class

http://localhost:702 7 /home/index

return View() will return the view with the action method name
return View("someViewName") return the view with other name




Views in MVC are called Razor view with cshtml extension --> combine c# html page

HTTP Request -> 
Get  top 30 movies, get user by id, get ,pvoes for genre is 3
Post  register user, login
Put edit profile
Delete delete account

Get User Info
Get https://localhost:7232/user/details/1
1. UserController -> controllers
2. Create Details action method -> Get
3. User fold inside views
4. Create details.cshtml

Entities represents your Database tables
Movie table => movie class will be mapped with properties
Genre table => genre class

View Models/DTO (Data Transfer Objects) => Views 
Home Page => MovieCardModel => PosterUrl, Id, Title
You create model classes based on the rquirement of the view

Repositories class/interfaces they deal with Entity classes
Services classese/interfaces they deal with Model classes


Every veiw before rendering, it will inherit view from the layout page
Home/index -> MovieCard
User/purchases => MovieCard
user/Favorites -> MovieCard

Partial View => MovieCardPartial and then u can reuse it across multiple views


Design Pattern that enables you to write loosely coupled code

tightly coupled code vs loosely coupled 

easy to maintain/test/change the functionality without changin much of the code


method(int x, IMovieService service);

any class/type that implements that interface can be its input

var movieService = new MovieService();

method(5, movieService)


### EF Core Code First Approach using Migrations

1. Create an Entity that you need based on Table requirement
1. Establish the connection string, where you want the database to be created
1. Install required libraries from NuGet
1. DbContext -> Represents your database and DbSet -> represents table
1. Create Custom DbContext class that inherits from DbContext base class
1. Inject DbContextOptions from Program.cs with connection string into DbContext
1. Create DbSet<Entity> property inside the Dbcontext
1. Add-migration
1. Update-database
1. Check the SQL Server if the database is in there
1. Do not change the Database schema manually, always go from code and apply new migration
1. Two ways to model our code first design
	1. Data Annotations
	1. Fluent API (takes precedence)

Sync vs Async

ASP.NET => when a request come in 
get => http://movieshop.come/movies/details/22

ASP.Net will have Threadpool => Collection of thread => 10 threads

T1 T2...T10 a collection of threads
20 requests at the same time for the same URL or different URL
t1 to t10 to process each request

11 the request => 503 error
prevent thread starcation senario

I/O =>
async/await => go together, only await a method that returns a task

write async modifier to the method
always return a task

wrapping datatypes into Task
sync			async
int				Task<int>
ActionResult	Task<ActionResult>
void			Task

Server side Pagination

you wanna get Movies by genre, but you do not wanna get all of them together

UI => not good UI EXP
Takes lots of time => SQL server needs to get all the data

http://moviesop.com/movies/genre/1 => get all the movies for genre 1


http://moviesop.com/movies/genre/1?pageSize=30&pageNumber=2

Movie, MovieGenre

select m.id, m.posterUrul, m.Title
from 
movie m join MovieGenre mg on m.id = mg.movieid
where mg.genreId = 1
order by m.id desc


// 5000

<nav aria-label="Page navigation example">
  <ul class="pagination">
  foreach(var movie in )
    <li class="page-item"><a class="page-link" href="#">Previous</a></li>
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item"><a class="page-link" href="#">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item"><a class="page-link" href="#">Next</a></li>
  </ul>
</nav>

Authentication & Authorization
public pages/annonymous user
1. Home
1. Movie Details
1. Cast Details
1. Login Page
1. Register Page


User Functionality
1. Buy Movie
1. Favorite Movie
1. Review Movie
1. Get Movies Purchased by user
1. Get Movies Favorited by user

Admin Functionality - Role of Admin
1. Create Movie
1. Create Cast
1. Get Popular Movies from and to dates -> Report data

### Create Register 
1. Create Links for Register and Login

Model Binding (Case insensitive)
HttpContext => it will give you all the info regarding the http context

Passworkds should always be hashed with Salt
Salt is a random generated words that is added to your password before hashing
U1 -> abc@abc.com  (ABC123! + sfadfdafdsf)  Hash1Alg ->  saasdfasdfasdfasdfasdf
U2 -> xyx@xyx.com  (Abc123! + sfdfsddfdfdfdf)  Hash1Alg ->  saasdfasdfasdfasdfasdf

Encryption (two way)  -> Credit Cards, Secretanswwers, SSN, DL

Hashing (one way) -> Passwords


Login
U1 -> abc@abc.com (Abc123!! + sfadfdafdsf) -> (hashed) == hash stored in database
compare hashes

// 9

Dev OPS

Developer + Operations 

Deploy the application => ASP.NET Core

Comapny A
Team MovieShop

Environments 
Dev -> Developer have access/test
QA -> Testers will test
Staging -> UAT()
Production/Live -> Actual Users


Windows Machine/server => IIS
Linus Server -> Ngix

Data Centers => Operations team that wll manage those servers

Cloud Providers
Azure => 

IaaS -> Infrastructure as a Service VM => Windows Server with 128G RAM core

IIS => MovieShop App

PaaS -> Platform as a Service
Azure App Service => Deploy the App
Azure SQL
Azure Blob Storage
Azure CI/CD
Azure Functions
Azure Cognitive Services

Saas -> 

//10 API

API => so that other teams/languages can understand that API
HTTP Protocal
JSON Data

2 Catagories of API
old school Web services -> SOAP Protocol
REST API -> Architecture pattern, HTTP HTTP GET, PUT, POST, DELETE 
HTTP Status Codes

URL => 

GET http://movieshop.com/api/movies/2
POST http://movieshop.com/api/account/register

Documentation => Swagger Documentation

1 Mobile APP
    iOS -> iOS Team Swift
    Antroid -> Team Java
