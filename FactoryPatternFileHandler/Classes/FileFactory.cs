using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternFileHandler.Classes
{
	public  class FileFactory
	{

		public void StartFileDataExtraccion(IList<File> listFile)
		{
			foreach (File item in listFile)
			{
				switch (item.Extension.ToUpper())
				{
					case "XLS":
						ExcelFileData excelFileData = new ExcelFileData();
						excelFileData.SelectTypeExtract(item);
						break;
					case "CSV":
						CsvFileData csvFileData = new CsvFileData();
						csvFileData.SelectTypeExtract(item);
						break;
					case "TXT":
						TxtFileData txtFileData = new TxtFileData();
						txtFileData.SelectTypeExtract(item);
						break;
					default:
						Console.WriteLine($"-----------------------------");
						Console.WriteLine($"Wrong File Extension{item.GetFullPath}");
						break;
				}

			}

		}

	}
}
