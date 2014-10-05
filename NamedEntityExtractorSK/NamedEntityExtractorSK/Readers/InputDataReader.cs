using System.Collections.Generic;
using System.Xml;
using NamedEntityExtractorSK.Data;

namespace NamedEntityExtractorSK.Readers
{
	public class InputDataReader
	{
		#region Properties

		public List<Page> Pages { get; private set; }

		#endregion

		#region Methods

		public InputDataReader()
		{
			this.Pages = new List<Page>();
		}

		public void SetPagesFromInputFile(string inputFilePath)
		{
			using (var reader = XmlReader.Create(inputFilePath))
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("page"))
					{
						var outerXml = reader.ReadOuterXml();

						if (outerXml.Contains("{{Infobox") || outerXml.Contains("{{Citácia"))
							Pages.Add(new Page(outerXml));
					}
				}
			}
		}

		#endregion
	}
}
