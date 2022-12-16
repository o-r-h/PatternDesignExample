using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternFileHandler.Classes
{
	public class File
	{
		public string Name { get; set; }
		
		public string Extension { get; set; }
		
		public decimal Size { get; set; }

		public string  Path { get; set; }

		public DateTime CreationDate { get; set; }


		public bool IsDirectory { 
		  get { return Directory.Exists(Path); }
		}

		public string GetFullName
		{
		  
			get { 
			  if (string.IsNullOrEmpty (Name) ||  string.IsNullOrEmpty(Extension) )
			  {
					return "";
			  }
			  return Name + "." + Extension;
			}
		}
		public string GetFullPath{
			get
			{
				if (string.IsNullOrEmpty(Path))
				{

					return "";
				}
				return Path + "/" + GetFullName;
			}

		}

		public string FileValidation
		{
			get
			{
				StringBuilder result = new StringBuilder();
				result.Append("");
				if (Size <=0){
					result.Append("- File size equals 0 ");
				}
				if (string.IsNullOrEmpty(Path)){
					result.Append("- Path is null or empty");
				}
				if (string.IsNullOrEmpty(Name))
				{
					result.Append("- Name is null or Empty");
				}

				return result.ToString();
			}

		}


	}

}
