using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLParsing
{
	public class Input
	{
		#region Properties

		public enum DataTypes { Validated, Text, Numeric, Boolean } //care for

		public string InputId { get; private set; }
		public string ElementId { get; private set; }
		public DataTypes DataType { get; private set; }

		// Rich client has a multiline flag for Text prompts. Currently, CherwellService does not pass through.
		public bool MultiLine { get; private set; }
		public string DisplayText { get; private set; }
		public bool Required { get; private set; }

		// Ignore mask. Only used by iCherwell to deal with server-side handling of date/time localization.
		public string Mask { get; private set; }

		// Default value to use for prompt.
		public string DefaultValue { get; private set; }

		// Ignore for now. iCherwell assumes true and so should Android for now. Indicates whether or
		// not the user is forced to select from promptValues collection or can enter a alternate value.
		public bool Enforced { get; private set; }

		// Option list of allowed values for prompt.
		public List<string> PromptValues { get; set; } //care for

		#endregion



		#region Constructors

		public Input(string inputId, string elementId, DataTypes dataType, bool multiLine, string displayText,
			bool required, string mask, string defaultValue, bool enforced, List<string> promptValues)
		{
			InputId = inputId;
			ElementId = elementId;
			DataType = dataType;
			MultiLine = multiLine;
			DisplayText = displayText;
			Required = required;
			Mask = mask;
			DefaultValue = defaultValue;
			Enforced = enforced;
			PromptValues = promptValues;
		}

		#endregion



		#region Constants

		public static string ImageData = "imagedata";
		public static string Binary = "binary";

		#endregion
	}
}
