using FactoryPatternFileHandler.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternFileHandler.Classes
{
	public interface IExtractFileData
	{
		void SelectTypeExtract(File file);
	}

	internal class ExcelFileData: IExtractFileData
	{
		public void SelectTypeExtract(File file)
		{
			Console.WriteLine($"-----------------------------");
			Console.WriteLine($"Starting file:{file.Name} ");
			GetDataExcelFileFactory getDataExcelFileFactory = new();
			getDataExcelFileFactory.SetDataFromFile(file);
			Console.WriteLine($"Finish file:{file.Name} ");
		}
	}

	internal class TxtFileData : IExtractFileData
	{
		public void SelectTypeExtract(File file)
		{
			Console.WriteLine($"-----------------------------");
			Console.WriteLine($"Starting file:{file.Name} ");
			GetDataTxtFileFactory getDataTxtFileFactory = new GetDataTxtFileFactory();
			getDataTxtFileFactory.SetDataFromFile(file);
			Console.WriteLine($"Finish file:{file.Name} ");
		}
	}

	internal class CsvFileData : IExtractFileData
	{
		public void SelectTypeExtract(File file)
		{
			Console.WriteLine($"-----------------------------");
			Console.WriteLine($"Starting file:{file.Name} ");
			GetDataCsvFileFactory getDataCsvFileFactory = new GetDataCsvFileFactory();
			getDataCsvFileFactory.SetDataFromFile(file);
			Console.WriteLine($"Finish file:{file.Name} ");
		}
	}

	public interface IGetDataFactory 
	{
		IExtractFileData SetDataFromFile(File file);
	}

	internal class GetDataExcelFileFactory : IGetDataFactory
	{
		public IExtractFileData SetDataFromFile(File file)
		{
			//validations
			if (!string.IsNullOrEmpty(file.FileValidation))
			{

				Console.WriteLine($" -- Can't process error: {file.FileValidation}");
			}
			//Call logic to extract data from file

			return new ExcelFileData(); 
		}
	}

	internal class GetDataCsvFileFactory : IGetDataFactory
	{
		public IExtractFileData SetDataFromFile(File file)
		{
			//validations
			if (!string.IsNullOrEmpty(file.FileValidation))
			{
				Console.WriteLine($" -- Can't process error: { file.FileValidation }");
			}
			//Call logic to extract data from file

			return new CsvFileData();
		}
	}

	internal class GetDataTxtFileFactory : IGetDataFactory
	{
		public IExtractFileData SetDataFromFile(File file)
		{
			//validations
			if (!string.IsNullOrEmpty(file.FileValidation))
			{
				Console.WriteLine($" -- Can't process error: {file.FileValidation}");
			}
			//Call logic to extract data from file

			return new TxtFileData();
		}
	}








}
