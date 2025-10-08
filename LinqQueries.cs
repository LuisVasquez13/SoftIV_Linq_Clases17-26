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

    // METODO: Toda la coleccion de libros
    // Este metodo lo que hace es devolver toda la coleccion de libros 
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    // METODO: Libros publicados despues del 2000
    // Este metodo lo que hace es devolver los libros publicados despues del 2000
    public IEnumerable<Book> LibrosDespuesde2000()
    {
        // Query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }
    // METODO: Libros con mas de 250 paginas y que contengan 'in Action' en el titulo
    // Este metodo lo que hace es devolver los libros con mas de 250 paginas
    // y que contengan 'in Action' en el titulo 
    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction() 
    {
        return from l in librosCollection
               where l.PageCount > 250 && l.Title.Contains("in Action")
               select l;
    }
    // METODO: Todos los libros tienen status
    // Este metodo lo que hace es comprobar si todos los libros tienen un status asignado 
    // y devuelve true si todos los libros tienen status, false en caso contrario
    public bool TodosLosLibrosTienenStatus() 
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    // METODO: Alguno de los libros fue publicado en 2005
    // Este metodo lo que hace es comprobar si algun libro fue publicado en 2005
    // y devuelve true si algun libro fue publicado en 2005, false en caso contrario
    public bool SiAlgunLibroFuePublicado2005() 
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    // METODO: Libros de Python
    // Este metodo lo que hace es devolver los libros de Python que contienen "Python" en su categoria
    public IEnumerable<Book> LibrosdePython() // devuelve los libros de Python
    {
        return from l in librosCollection
               where l.Categories.Contains("Python")
               select l;
    }
    // METODO: Libros de Java por orden ascendente
    // Este metodo lo que hace es devolver los libros de Java por orden ascendente segun el titulo
    public IEnumerable<Book> LibrosdeJavaPorAscendente() 
    {
        return from l in librosCollection
               where l.Categories.Contains("Java")
               orderby l.Title ascending
               select l;
    }
    // METODO: Libros con mas de 450 paginas ordenados por num de paginas descendente
    // Este metodo lo que hace es devolver los libros con mas de 450 paginas ordenados 
    // por num de paginas en orden descendente
    public IEnumerable<Book> Librosdemasde450pagOrdenadosPorNumPagDescendente() 
    {
        return from l in librosCollection
               where l.PageCount > 450
               orderby l.PageCount descending
               select l;
    }
    // METODO: Tres primeros libros de Java ordenados por fecha
    // Este metodo lo que hace es devolver los tres libros mas recientes de Java ordenados por fecha
    public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha() 
    {
        return librosCollection
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p => p.PublishedDate)
        .Take(3);
    }
    // METODO: Tercer y cuarto libro con mas de 400 paginas
    // Este metodo lo que hace es devolver el tercer y cuarto libro con mas de 400
    public IEnumerable<Book> TerceryCuartoLibroDeMas400pag() 
    {
        // Skip y Take para saltar los dos primeros y tomar los dos siguientes
        return librosCollection
        .Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }
    // METODO: Tres primeros libros de la coleccion con Select
    // Este metodo lo que hace es devolver los tres primeros libros de la coleccion
    // pero solo con el titulo y el numero de paginas usando Select
    public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion() 
    {
        return librosCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }



    // Clases del 17 a 26 con LINQ

    // METODO: Cantidad de libros entre 200 y 500 paginas
    // Este metodo lo que hace es contar la cantidad de libros que tienen entre 200 y 500 paginas
    // y devolver el resultado como un long
    public long CantidadDeLibrosEntre200y500Pag() 
    {
        return librosCollection.LongCount(p=> p.PageCount>=200 && p.PageCount<=500); // LongCount para contar
    }

    // METODO: Fecha de publicacion menor de todos los libros
    // Este metodo lo que hace es buscar la fecha de publicacion menor de todos los libros
    // y devolverla como un DateTime
    public DateTime FechaDePublicacionMenor()
    {
        // Min para obtener la fecha minima
        return librosCollection.Min(p=> p.PublishedDate);
    }

    // METODO: Numero de paginas del libro con mayor Numero de paginas
    // Este metodo lo que hace es buscar el libro con el mayor numero de paginas
    // y devolver el numero de paginas como un int
    public int NumeroDePagLibroMayor()
    {
        // Max para obtener el numero maximo de paginas
        return librosCollection.Max(p=> p.PageCount);
    }

    // METODO: Libro con menor numero de paginas
    // Este metodo lo que hace es buscar el libro con el menor numero de paginas
    // y devolverlo como un objeto Book 
    public Book LibroConMenorNumeroDePaginas()
    {
        // MinBy para obtener el libro con el menor numero de paginas
        return librosCollection.Where(p=> p.PageCount>0).MinBy(p=> p.PageCount); 
    }

    // Libro con fecha publicacion mas reciente
    public Book LibroConFechaPublicacionMasReciente()
    {
        // MaxBy para obtener el libro con la fecha de publicacion mas reciente
        return librosCollection.MaxBy(p=> p.PublishedDate); 
    }

    // METODO: Suma de todas las paginas de libros entre 0 y 500
    // Este metodo lo que hace es sumar todas las paginas de los libros que tienen entre 0 y 500 paginas
    // y devolver el resultado como un int 
    public int SumaDeTodasLasPaginasLibrosEntre0y500()
    {
        // Sum para sumar
        return librosCollection.Where(p=> p.PageCount >= 0 && p.PageCount <=500).Sum(p=> p.PageCount); // Suma
    }

    // METODO: Titulos de libros despues del 2015 concatenados
    // Este metodo lo que hace es concatenar los titulos de los libros publicados despues del 2015
    // separados por " - " y devolverlos en un solo string
    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosCollection 
                .Where(p=> p.PublishedDate.Year > 2015) // Se usa Where para filtrar
                .Aggregate("", (TitulosLibros, next) => // Se usa Aggregate para concatenar
                { // Accumulador y siguiente elemento
                    if (TitulosLibros != string.Empty) // Si no es el primer titulo
                        TitulosLibros += " - " + next.Title; // Concatenar con " - " si no es el primer titulo
                    else // Si es el primer titulo
                        TitulosLibros += next.Title;

                    return TitulosLibros; // Retornar el acumulador
                });
    }

    // METODO: Promedio de caracteres del los titulos de los libros
    // Este metodo lo que hace es calcular el promedio de caracteres en los titulos de los libros
    // y devolverlo como un double 
    public double PromedioCaracteresTitulo()
    {
        // Se usa Average para calcular el promedio
        return librosCollection.Average(p=> p.Title.Length); // Promedio
    }

    // METODO: Libros publicados a partir del 2000 agrupados por año
    // Este metodo lo que hace es agrupar los libros publicados a partir del año 2000 por año de publicacion
    // y devolverlos en una coleccion de grupos
    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
    {
        // // GroupBy para agrupar por año de publicacion
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year); 
    }

    // METODO: Diccionario de libros agrupados por primera letra del titulo
    // Este metodo lo que hace es agrupar los libros por la primera letra del titulo y devolver un diccionario
    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        // Se usa ToLookup para crear un diccionario
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }

    // METODO: Libros publicados despues del 2005 con mas de 500 paginas usando Join
    // Este metodo lo que hace es unir dos colecciones de libros, una con los libros publicados
    // despues del 2005 y otra con los libros con mas de 500 paginas y devolver los libros
    // que cumplen ambas condiciones usando Join
    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        // Libros publicados despues del 2005
        var LibrosDepuesdel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005); // Where para filtrar
        // Libros con mas de 500 paginas
        var LibrosConMasde500pag = librosCollection.Where(p=> p.PageCount > 500); // Where para filtrar
        // Join entre las dos colecciones por el titulo del libro
        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p=> p.Title, x=> x.Title, (p, x) => p); // Join
    }
}