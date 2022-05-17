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
1. 