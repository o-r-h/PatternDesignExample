// See https://aka.ms/new-console-template for more information
using DecoratorPattern.Abstracts;
using DecoratorPattern.Classes;
using System.IO;

Console.WriteLine("Hello, World!");


// Constructor
Video video = new Video("Peter Jackson", "Lord of the Rings", 19, 99);
Book book = new Book("Terry Pratchettt", "Guards!", 10);

//assign decorator to a item
Borrowable borrowable = new Borrowable(book);
borrowable.BorrowItem(" Omar");
borrowable.BorrowItem(" Jack");
borrowable.BorrowItem(" Diana");
borrowable.BorrowItem(" Phil");
borrowable.ReturnItem(" Diana");


video.Display();
book.Display();


Console.WriteLine(" ");
Console.WriteLine("--- borrowers: -------------- " );
borrowable.Display();

