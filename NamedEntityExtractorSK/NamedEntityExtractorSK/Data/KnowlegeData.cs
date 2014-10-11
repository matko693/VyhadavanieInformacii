using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NamedEntityExtractorSK.Utilities;

namespace NamedEntityExtractorSK.Data
{
	public class KnowlegeData
	{
		#region Fields

		private readonly Lazy<Dictionary<string, string>> _Items;
		
		#endregion

		#region Properties

		public string Content { get; set; }

		public Dictionary<string, string> Items
		{
			get
			{
				return this._Items.Value;
			}
		}

		#endregion

		#region Methods

		public KnowlegeData()
		{
			this._Items = new Lazy<Dictionary<string, string>>(LoadItems);
		}

		private Dictionary<string, string> LoadItems()
		{
			var items = new Dictionary<string, string>();

			Regex.Split(this.Content, @"\| ")
						.Where(word => word.Contains("=")).ToList()
						.ForEach(item =>
						{
							var word = Regex.Split(item, " =");
							var key = WordUtils.TrimWhiteSpaces(word[0]);
							var value = WordUtils.TrimWhiteSpaces(word[1]);

							if(!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
								items.Add(key, value);
						});

			return items;
		}

		#endregion
	}
}
