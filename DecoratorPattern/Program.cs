// See https://aka.ms/new-console-template for more information
using DecoratorPattern.Classes;
using System.IO;

Console.WriteLine("Hello, World!");


// Constructor
Video video = new Video("Peter Jackson", "Lord of the Rings", 19, 99);
Book book = new Book("Terry Pratchettt", "Guards!", 10);
Borrowable borrowable = new Borrowable(book);
//borrowable.ReturnItem("Return Omar");
borrowable.BorrowItem("Borrow Omar");
video.Display();
book.Display();

borrowable.Display();

