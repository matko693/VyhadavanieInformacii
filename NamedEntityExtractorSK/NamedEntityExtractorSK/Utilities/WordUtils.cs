using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamedEntityExtractorSK.Data;

namespace NamedEntityExtractorSK.Utilities
{
	public static class WordUtils
	{
		public static string[] Citacia = { "{{Citácia" };
		public static string[] Infobox = { "{{Infobox" };
		public static string[] Geobox = { "{{Geobox" };

		public static string[] SearchBoxes = { "{{Citácia", "{{Infobox", "{{Geobox" };

		private static char[] WhiteSpaces = new char[] { ' ', '\n', '\t' };

		public static string TrimWhiteSpaces(this string text)
		{
			text = text.TrimStart(WhiteSpaces);
			return text.TrimEnd(WhiteSpaces);
		}

		public static void TrimBoxes<T>(IEnumerable<string> splited, ref List<KnowlegeData> data)
			where T : KnowlegeData
		{
			foreach (var item in splited)
			{
				var index = item.IndexOf("}}");

				if (index != -1)
				{
					T instance = (T) Activator.CreateInstance(typeof(T));
					instance.Content = item.Remove(index);
					
					data.Add(instance);
				}
			}
		}
	}
}
