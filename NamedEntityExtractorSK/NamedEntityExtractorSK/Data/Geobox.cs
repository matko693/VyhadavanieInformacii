using System.Diagnostics;

namespace NamedEntityExtractorSK.Data
{
	[DebuggerDisplay("Content = {Content}")]
	public class Geobox : KnowlegeData
	{
		#region Properties

		//locations
		//mayor → person
		public string[] Patterns = new string[] { "[Mm]eno[0-9]*", "[nN]ame", "[oO]ther_name", "[Cc]ountry", "[rR]egi[oó]n", "[mM]ayor"};

		#endregion
	}
}
