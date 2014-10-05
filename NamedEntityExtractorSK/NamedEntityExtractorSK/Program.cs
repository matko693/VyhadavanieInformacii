using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamedEntityExtractorSK.Readers;

namespace NamedEntityExtractorSK
{
	public class Program
	{
		static void Main(string[] args)
		{
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
			var directory = baseDirectory.Take(baseDirectory.Length - 3).Aggregate((a, b) => a + '\\' + b);
			string filePath = directory + @"\InputData\skwiki-latest-pages-articles.xml";

			var reader = new InputDataReader();
			reader.SetPagesFromInputFile(filePath);
		}
	}
}
