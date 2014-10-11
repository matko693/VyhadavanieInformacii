using System.Collections.Generic;
using System.Diagnostics;

namespace NamedEntityExtractorSK.Data
{
	[DebuggerDisplay("Content = {Content}")]
	public class Infobox : KnowlegeData
	{
		#region Properties

		public string[] Types = new string[] {	"([oO]sobnos[tť])*([oO]soba)*([sS]v[aä]tec)*([sS]pisovate[lľ])*([dD]uchovn[yý])*([aA]tl[eé]t)*([hH]erec)*([kK]ozmonaut)*(.*[uU]melec)", 
												"[Jj]azyk", 
												"([Zz]aniknutý)*.*[SŠsš]t[aá]t", 
												"([pP]olitik)*([vV]l[aá]dca)*([pP]anovn[ií]k)*", 
												".*obec", 
												"[fF]ilozof", 
												"[kK]ontinent", 
												"([sS]oftv[eé]r)*([vV]ideoghra)*", 
												"[fF]utbalista", 
												"([sS]ingel)*([aA]lbum)*",
												"([fF]utbalov[yý])*([hH]okejov[yý])* klub", 
												"[sS]polo[cč]nos[tť]",
												"[fF]ilm",
												"([aA]uto(mobil)*(bus)*)*([lL]ietadlo)"};

		public Dictionary<string, string[]> TypeAttributes { get; set; }

		#endregion

		#region Constructors

		public Infobox()
		{
			TypeAttributes = new Dictionary<string, string[]>();

			//person, location
			TypeAttributes.Add(Types[0], new string[] { "[mM]eno", "[mM]iesto (narodenia)*([uú]mrtia)*" });
			//location
			TypeAttributes.Add(Types[1], new string[] { "[SŠsš]t[aá]ty" });
			//location
			TypeAttributes.Add(Types[2], new string[] { "[Dlhý]*[Krátky]* miestny n[aá]zov", "[hH]lavn[eé] mesto", "[nN]ajv[aä][cč][sš]ie mesto", "[sS]usedia", "[cC]el[yý] n[aá]zov" });
			//premier, nastupca, predchodca → [[meno]][[meno2]]
			//politicka strana → organizacia
			TypeAttributes.Add(Types[3], new string[] { "[pP]remi[eé]r[0-9]*", "[Nn][aá]stupca[0-9]*", "[pP]redchodca[0-9]*", "[mM]iesto [narodenia]*[uú]*[mrtia]*", "[pP]olitick[aá] strana", "[mM]an[zž]el[ka]*" });
			//location, location, location, location, location, person
			TypeAttributes.Add(Types[4], new string[] { "[nN][aá]zov", "[pP]rez[yý]vka", "[kK]raj", "[oO]kres", "[rR]egi[oó]n", "[sS]tarosta" });
			//plne meno → person
			//ovplyvneny kym → [[meno|alternativa]],[meno2|alternativa]....
			TypeAttributes.Add(Types[5], new string[] { "([pP]ln[eé])* *[mM]eno", "[Oo]vplyvnen[yý] *(k[yý]m)*" });
			//locations
			//regiony → [[meno]][[meno2]]
			TypeAttributes.Add(Types[6], new string[] { "[kK]ontinent", "[sSšŠ]t[aá]ty", "[rR]egi[oó]ny" });
			//organization → [[organizacia1]], [[organizacia2]], [[organizacia3]]
			TypeAttributes.Add(Types[7], new string[] { "[vV][yý]voj[aá]r", "[vV]ydavate[lľ]" });
			//person, location, location, organization
			TypeAttributes.Add(Types[8], new string[] { "([cC]el[eé] )*[mM]eno", "[mM]iesto (narodenia)*([uú]mrtia)*", "[SŠsš]t[aá]t", "[sS][uú][cč]asn[ýy] klub", "[kK]luby" });
			//organization, perosn → [[meno1]] [[meno2]], organization
			TypeAttributes.Add(Types[9], new string[] { "[vV]ydavate[lľ]", "[pP]roducent", "[iI]nterpret" });
			//organization, location → [[nazov1|nazov1alternativa]][[nazov2|nazov2alternativa]]
			TypeAttributes.Add(Types[10], new string[] { "[nN][aá]zov(klubu)*", "[cC]el[yý] n[aá]zov", "[SŠsš]tadi[oó]n" });
			//organization, person, location, location, organization
			TypeAttributes.Add(Types[11], new string[] { "[nN][aá]zov( [Ss]polo[cč]nosti)*", "[zZ]akladate[lľ]", "[sS][ií]dlo", "[SŠsš]t[aá]t [sS][ií]dla", "[Dd]c[eé]rske spolo[cč]nosti" });
			//location, organization, person............
			TypeAttributes.Add(Types[12], new string[] { "[kK]rajina", "[Ss]polo[cč]nos[tť]", "[rR][eé][zž]ia", "[sS]cen[aá]r", "[pP]rodukcia", "[hH]udba", "[kK]amera", "[oO]bsadenie" });
			//organization
			TypeAttributes.Add(Types[13], new string[] { "[Vv][yý]robca", "[kK]rajina.*"});
		}

		#endregion
	}
}
