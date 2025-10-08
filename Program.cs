LinqQueries queries = new LinqQueries(); // instancia de la clase LinqQueries

bool ciclo = true; // variable para controlar el ciclo del menu
int opcion; // variable para almacenar la opcion del usuario
while (ciclo)
{
    // Menu
    Console.WriteLine("\nSeleccione una opcion del menu:");
    Console.WriteLine("1. Toda la coleccion");
    Console.WriteLine("2. Libros publicados despues del 2000");
    Console.WriteLine("3. Libros que tengan mas de 250 paginas y contengan 'in Action' en el titulo");
    Console.WriteLine("4. Todos los libros tienen status?");
    Console.WriteLine("5. Algun libro fue publicado en 2005?");
    Console.WriteLine("6. Libros de Python");
    Console.WriteLine("7. Libros de Java por orden ascendente");
    Console.WriteLine("8. Libros que tienen mas de 450 paginas ordenados por numero de paginas descendente");
    Console.WriteLine("9. Los 3 libros mas recientes de Java");
    Console.WriteLine("10. Tercer y cuarto con mas de 400 paginas");
    Console.WriteLine("11. Tres primeros libros filtrados con Select");
    Console.WriteLine("12. Cantidad de libros que tienen entre 200 y 500 paginas");
    Console.WriteLine("13. Fecha de publicacion menor de todos los libros");
    Console.WriteLine("14. Numero de paginas del libro con mayor Numero de paginas");
    Console.WriteLine("15. Libro con menor Numero de paginas");
    Console.WriteLine("16. Libro con fecha publicacion mas reciente");
    Console.WriteLine("17. Suma de paginas de libros entre 0 y 500");
    Console.WriteLine("18. Libros publicados despues del 2015 concatenados");
    Console.WriteLine("19. Promedio de caracteres del los titulos de los libros");
    Console.WriteLine("20. Libros publicados a partir del 2000 agrupados por año");
    Console.WriteLine("21. Diccionario de libros agrupados por primera letra del titulo");
    Console.WriteLine("22. Libros filtrados con la clausula join");
    Console.WriteLine("0. Salir");



    // Leer opcion del usuario
    try{ // manejo de excepcion si el usuario ingresa un valor no numerico
        Console.Write("\nOpcion: ");
        opcion = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    }
    catch (FormatException){ // si el usuario ingresa un valor no numerico
        Console.WriteLine("\nError: Debe ingresar un numero entero.");
        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        continue; // volver al inicio del ciclo
    }
    
    // Ejecutar la opcion seleccionada
    switch (opcion)
    {
        case 1: // Toda la coleccion
            ImprimirValores(queries.TodaLaColeccion());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 2: // Libros publicados despues del 2000
            ImprimirValores(queries.LibrosDespuesde2000());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 3: // Libros con mas de 250 paginas y que contengan 'in Action' en el titulo
            ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 4: // Todos los libros tienen status
            Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 5: // Algun libro fue publicado en 2005
            Console.WriteLine($"Algun libro fue publicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 6: // Libros de Python
            ImprimirValores(queries.LibrosdePython());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 7: // Libros de Java por orden ascendente
            ImprimirValores(queries.LibrosdeJavaPorAscendente());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 8: // Libros con mas de 450 paginas ordenados por num de paginas descendente
            ImprimirValores(queries.Librosdemasde450pagOrdenadosPorNumPagDescendente());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 9: // Tres libros mas recientes de Java
            ImprimirValores(queries.TresPrimerosLibrosJavaOrdenadosPorFecha());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 10: // Tercer y cuarto con mas de 400 paginas
            ImprimirValores(queries.TerceryCuartoLibroDeMas400pag());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 11: // Tres primeros libros filtrados con Select
            ImprimirValores(queries.TresPrimerosLibrosDeLaColeccion());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 12: // Cantidad de libros que tienen entre 200 y 500 paginas
            Console.WriteLine($"Cantidad de libros que tiene entre 200 y 500 pag. {queries.CantidadDeLibrosEntre200y500Pag()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 13: // Fecha de publicacion menor de todos los libros
            Console.WriteLine($"Fecha de publicacion menor: {queries.FechaDePublicacionMenor()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 14: // Numero de paginas del libro con mayor Numero de paginas
            Console.WriteLine($"El libro con mayor numero de paginas tiene: {queries.NumeroDePagLibroMayor()} paginas. ");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 15: // Libro con menor Numero de paginas
            var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
            Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 16: // Libro con fecha publicacion mas reciente
            var libroFechaPubReciente = queries.LibroConFechaPublicacionMasReciente();
            Console.WriteLine($"{libroFechaPubReciente.Title} - {libroFechaPubReciente.PublishedDate.ToShortDateString()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 17: // suma de paginas de libros entre 0 y 500
            Console.WriteLine($"Suma total de paginas {queries.SumaDeTodasLasPaginasLibrosEntre0y500()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 18: // Libros publicados despues del 2015 concatenados
            Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 19: // Promedio de caracteres del los titulos de los libros
            Console.WriteLine($"Promedio caracteres de los titulos: {queries.PromedioCaracteresTitulo()}");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 20: // Libros publicados a partir del 2000 agrupados por año
            ImprimirGrupo(queries.LibrosDespuesdel2000AgrupadosporAno());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 21: // Diccionario de libros agrupados por primera letra del titulo
            var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
            ImprimirDiccionario(diccionarioLookup, 'Z');
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 22: // Libros filtradaor con la clausula join 
            ImprimirValores(queries.LibrosDespuesdel2005conmasde500Pags());
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case 0: // salir
            ciclo = false;
            Console.Clear();
            break;
        default: // si el usuario ingresa una opcion no valida
            Console.WriteLine("Opcion no valida. Intente de nuevo.");
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
    }
}


// IEnumerable es una interfaz que define un metodo GetEnumerator que devuelve un enumerador que itera a traves de una coleccion
void ImprimirValores(IEnumerable<Book> listadelibros)
{
    // Imprimir los valores de la coleccion
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listadelibros)
    {
        // Imprimir el titulo, numero de paginas y fecha de publicacion de cada libro
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

// IGrouping es una interfaz que representa una coleccion de objetos que comparten una clave comun
void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros) // recorrer cada grupo
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}"); // imprimir la clave del grupo (año de publicacion)
        // Imprimir los valores del grupo
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo) // recorrer cada libro del grupo
        {
            // Imprimir el titulo, numero de paginas y fecha de publicacion de cada libro
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

// ILookup es una interfaz que representa una coleccion de objetos que pueden ser accedidos por una clave
void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    // Imprimir los valores del diccionario para la letra especificada
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in ListadeLibros[letra])
    {
        // Imprimir el titulo, numero de paginas y fecha de publicacion de cada libro
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}