using System.Diagnostics;

namespace NamedEntityExtractorSK.Data
{
	[DebuggerDisplay("Content = {Content}")]
	public class Citation : KnowlegeData
	{
		#region Properties

		public string[] Patterns = new string[] { "[Mm]eno[0-9]*", "[pP]riezvisko[0-9]*", "[vV]ydavate[lľ]", "[mM]iesto", "[mM]esto" };
				
		#endregion
	}
}
