public class Book{ // clase que representa un libro
    public string Title {get; set;} // propiedad que representa el titulo del libro
    public int PageCount {get; set;} // propiedad que representa el numero de paginas del libro
    public string Status {get; set;} // propiedad que representa el estado del libro

    public DateTime PublishedDate {get; set;} // propiedad que representa la fecha de publicacion del libro
    public string[] Authors {get; set;} // propiedad que representa los autores del libro
    public string[] Categories {get; set;} // propiedad que representa las categorias del libro
}