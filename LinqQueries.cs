public class LinqQueries // clase para manejar las consultas Linq
{
    private List<Book> librosCollection = new List<Book>(); // lista de libros

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json")) // lee el archivo JSON
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaLaColeccion() // devuelve toda la coleccion de libros
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesde2000() // devuelve los libros publicados despues del 2000
    {
        // Extension de metodo
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        // Query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction() // devuelve los libros con mas de 250 paginas y que contengan 'in Action' en el titulo
    {
        // Extension de metodo
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        // Query expresion
        return from l in librosCollection
               where l.PageCount > 250 && l.Title.Contains("in Action")
               select l;
    }

    public bool TodosLosLibrosTienenStatus() // devuelve true si todos los libros tienen status
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SiAlgunLibroFuePublicado2005() // devuelve true si algun libro fue publicado en 2005
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosdePython() // devuelve los libros de Python
    {
        // Extension de metodo
        //return librosCollection.Where(p => p.Categories.Contains("Python"));

        // Query expresion
        return from l in librosCollection
               where l.Categories.Contains("Python")
               select l;
    }

    public IEnumerable<Book> LibrosdeJavaPorAscendente() // devuelve los libros de Java por orden ascendente
    {
        // Extension de metodo
        //return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p=> p.Title);

        // Query expresion
        return from l in librosCollection
               where l.Categories.Contains("Java")
               orderby l.Title ascending
               select l;
    }

    public IEnumerable<Book> Librosdemasde450pagOrdenadosPorNumPagDescendente() // devuelve los libros con mas de 450 paginas ordenados por num de paginas descendente
    {
        // Extension de metodo
        //return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);

        // Query expresion
        return from l in librosCollection
               where l.PageCount > 450
               orderby l.PageCount descending
               select l;
    }

    public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha() // devuelve los tres libros mas recientes de Java
    {

        return librosCollection
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p => p.PublishedDate)
        .Take(3);
    }

    public IEnumerable<Book> TerceryCuartoLibroDeMas400pag() // devuelve el tercer y cuarto libro con mas de 400 paginas
    {
        return librosCollection
        .Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion() // devuelve los tres primeros libros filtrados con Select
    {
        return librosCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }

    // Clases del 17 a 26 con LINQ

    public long CantidadDeLibrosEntre200y500Pag() // cantidad de libros que tienen entre 200 y 500 paginas
    {
        return librosCollection.LongCount(p=> p.PageCount>=200 && p.PageCount<=500); //
    }

    // fecha de publicacion menor de todos los libros
    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p=> p.PublishedDate); // 
    }

    // Numero de paginas del libro con mayor Numero de paginas
    public int NumeroDePagLibroMayor()
    {
        return librosCollection.Max(p=> p.PageCount);
    }

    // Libro con menor numero de paginas
    public Book LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(p=> p.PageCount>0).MinBy(p=> p.PageCount);
    }

    // Libro con fecha publicacion mas reciente
    public Book LibroConFechaPublicacionMasReciente()
    {
        return librosCollection.MaxBy(p=> p.PublishedDate);
    }

    // Suma de todas las paginas de libros entre 0 y 500
    public int SumaDeTodasLasPaginasLibrosEntre0y500()
    {
        return librosCollection.Where(p=> p.PageCount >= 0 && p.PageCount <=500).Sum(p=> p.PageCount);
    }

    // Titulos de libros despues del 2015 concatenados
    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosCollection 
                .Where(p=> p.PublishedDate.Year > 2015)
                .Aggregate("", (TitulosLibros, next) =>
                { // Accumulador y siguiente elemento
                    if (TitulosLibros != string.Empty)
                        TitulosLibros += " - " + next.Title; // Concatenar con " - " si no es el primer titulo
                    else
                        TitulosLibros += next.Title;

                    return TitulosLibros; // Retornar el acumulador
                });
    }

    // Promedio de caracteres del los titulos de los libros
    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p=> p.Title.Length);
    }

    // Libros publicados a partir del 2000 agrupados por año
    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year);
    }

    // Diccionario de libros agrupados por primera letra del titulo
    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }

    // Libros publicados despues del 2005 con mas de 500 paginas usando Join
    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        // Libros publicados despues del 2005
        var LibrosDepuesdel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);
        // Libros con mas de 500 paginas
        var LibrosConMasde500pag = librosCollection.Where(p=> p.PageCount > 500);
        // Join entre las dos colecciones por el titulo del libro
        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p=> p.Title, x=> x.Title, (p, x) => p);
    }
}