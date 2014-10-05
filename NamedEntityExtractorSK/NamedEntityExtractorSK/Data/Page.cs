using System.Collections.Generic;

namespace NamedEntityExtractorSK.Data
{
	public class Page
	{
		#region Properties

		public List<Infobox> Infoboxes { get; set; }

		#endregion

		#region Constructors

		public Page(string content)
		{
			var startIndex = content.IndexOf("<text");
			var endIndex = content.IndexOf("</text");

			if (startIndex != -1 && endIndex != -1)
			{
				content = content.Substring(startIndex, endIndex - startIndex + 1);
				Infoboxes = new List<Infobox>();
				SetInfoboxes(content);
			}
		}

		#endregion

		#region Methods

		private void SetInfoboxes(string text)
		{
			var indexes = AllIndexesOf(text, @"{{Infobox ");
			indexes.AddRange(AllIndexesOf(text, @"{{Citácia "));
			
			indexes.ForEach(x => GetInfobox(text, x));
		}

		private void GetInfobox(string text, int startIndex)
		{
			var endIndex = text.Substring(startIndex).IndexOf("}}");
			Infoboxes.Add(new Infobox() { Content = text.Substring(startIndex, endIndex +2) });
		}

		private List<int> AllIndexesOf(string str, string value)
		{
			List<int> indexes = new List<int>();
			for (int index = 0; ; index += value.Length)
			{
				index = str.IndexOf(value, index);
				if (index == -1)
					return indexes;
				indexes.Add(index);
			}
		}

		#endregion
	}
}
