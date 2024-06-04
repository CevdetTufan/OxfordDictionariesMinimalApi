using Newtonsoft.Json;

namespace OxfordDictionaries.Api.Models
{
	public class Construction
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class Entry
	{
		[JsonProperty("etymologies")]
		public List<string> Etymologies { get; set; }

		[JsonProperty("grammaticalFeatures")]
		public List<GrammaticalFeature> GrammaticalFeatures { get; set; }

		[JsonProperty("pronunciations")]
		public List<Pronunciation> Pronunciations { get; set; }

		[JsonProperty("senses")]
		public List<Sense> Senses { get; set; }

		[JsonProperty("inflections")]
		public List<Inflection> Inflections { get; set; }
	}

	public class Example
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class GrammaticalFeature
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}

	public class Inflection
	{
		[JsonProperty("inflectedForm")]
		public string InflectedForm { get; set; }
	}

	public class LexicalCategory
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class LexicalEntry
	{
		[JsonProperty("entries")]
		public List<Entry> Entries { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("lexicalCategory")]
		public LexicalCategory LexicalCategory { get; set; }

		[JsonProperty("phrases")]
		public List<Phrase> Phrases { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class Metadata
	{
		[JsonProperty("operation")]
		public string Operation { get; set; }

		[JsonProperty("provider")]
		public string Provider { get; set; }

		[JsonProperty("schema")]
		public string Schema { get; set; }
	}

	public class Phrase
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class Pronunciation
	{
		[JsonProperty("audioFile")]
		public string AudioFile { get; set; }

		[JsonProperty("dialects")]
		public List<string> Dialects { get; set; }

		[JsonProperty("phoneticNotation")]
		public string PhoneticNotation { get; set; }

		[JsonProperty("phoneticSpelling")]
		public string PhoneticSpelling { get; set; }
	}

	public class Region
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class Result
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("lexicalEntries")]
		public List<LexicalEntry> LexicalEntries { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("word")]
		public string Word { get; set; }
	}

	public class Root
	{
		[JsonProperty("metadata")]
		public Metadata Metadata { get; set; }

		[JsonProperty("query")]
		public string Query { get; set; }

		[JsonProperty("results")]
		public List<Result> Results { get; set; }
	}

	public class Sense
	{
		[JsonProperty("constructions")]
		public List<Construction> Constructions { get; set; }

		[JsonProperty("definitions")]
		public List<string> Definitions { get; set; }

		[JsonProperty("examples")]
		public List<Example> Examples { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("shortDefinitions")]
		public List<string> ShortDefinitions { get; set; }

		[JsonProperty("subsenses")]
		public List<Subsense> Subsenses { get; set; }

		[JsonProperty("synonyms")]
		public List<Synonym> Synonyms { get; set; }

		[JsonProperty("thesaurusLinks")]
		public List<ThesaurusLink> ThesaurusLinks { get; set; }

		[JsonProperty("regions")]
		public List<Region> Regions { get; set; }
	}

	public class Subsense
	{
		[JsonProperty("definitions")]
		public List<string> Definitions { get; set; }

		[JsonProperty("examples")]
		public List<Example> Examples { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("shortDefinitions")]
		public List<string> ShortDefinitions { get; set; }
	}

	public class Synonym
	{
		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class ThesaurusLink
	{
		[JsonProperty("entry_id")]
		public string EntryId { get; set; }

		[JsonProperty("sense_id")]
		public string SenseId { get; set; }
	}



}
