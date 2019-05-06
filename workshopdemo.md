#Workshop stappen

Het doel is om een webapi te maken, die werkt met EF.
We gaan database first een applicatie scaffolden.
Daarna passen we het repository pattern toe en implementeren we de api.

https://codeshare.io/aYOlkm

[1] Deel het create script met de klas: https://we.tl/t-0qOM1WqEMi

[2] Maak een dotnet webapi 

```bash
dotnet new webapi
```

[3] Installeer de ef-core commandline tool

```bash
ef-core dotnet tool install --global dotnet-ef --version 3.0.0-preview4.19216.3
```

[4] Voeg de packages toe. Zie link voor de correcte packages: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.0.0-preview3.19153.1

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0-preview3.19153.
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.0.0-preview3.19153.1
```

[5] Scaffold de database in de applicatie

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=WorkshopDB;User ID=sa;Password=Password1" Microsoft.EntityFrameworkCore.SqlServer -o Entities
```

[6] Dotnet heeft nu de connectiestring in de DBContext gezet. Dit is sensitive data exposure. Om dit op te lossen moet je het in je settings zetten.

```json
"ConnectionStrings": {
 "Database": "Server=localhost;Database=WorkshopDB;User ID=sa;Password=Password1"
}
```

[7] Inject de setting in je applicatie en haal de oude code weg.

```c#
services.AddDbContext<WorkshopDBContext>(options =>
   options.UseSqlServer(Configuration.GetConnectionString("Database")));
```

[8] We hebben nu een database first applicatie gemaakt.

[9] Nu gaan we het repository pattern toepassen.

```c#
public interface IRepository <T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        
    }
    
public class ProductRepository : IRepository<Products>
    {
        private readonly WorkshopDBContext _context;

        public ProductRepository(WorkshopDBContext context)
        {
            _context = context;
        }
        
        public Products GetById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        
        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();
        }
    }
```

[10] Dit moeten we ook injecten in de applicatie.

```C#
services.AddTransient<IRepository<Products>, ProductRepository>();
```

[11] Nu gaan we de controller maken.

```c#
[Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Products> _repository;

        public ProductController(IRepository<Products> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_repository.GetById(Id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
       
    }
```

[12] Run de applicatie.




