// See https://aka.ms/new-console-template for more information
using FactoryPatternFileHandler.Classes;

List<FactoryPatternFileHandler.Classes.File> files = new List<FactoryPatternFileHandler.Classes.File>{
new FactoryPatternFileHandler.Classes.File { Name= "doc_001" , Extension = "xls" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "doc_002" , Extension = "xls" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "doc_003" , Extension = "png" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "doc_005" , Extension = "txt" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "doc_007" , Extension = "csv" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "" , Extension = "csv" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100},
new FactoryPatternFileHandler.Classes.File { Name= "doc_037" , Extension = "csv" , Path ="C:/alfa", CreationDate = new DateTime(2022,10,28),Size = 100}
};

FileFactory fileFactory= new FileFactory();
	fileFactory.StartFileDataExtraccion(files);


