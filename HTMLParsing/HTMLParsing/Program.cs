using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace HTMLParsing
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Input> inputs = new List<Input>();
			inputs.Add(new Input("Input_1", "element_1", Input.DataTypes.Validated, false, "Please select a Cause Code:", true, "", "", true, null));
			inputs.Add(new Input("Input_2", "element_2", Input.DataTypes.Text, true, "Please enter the close description:", true, "", "", true, null));
			inputs.Add(new Input("Input_3", "element_3", Input.DataTypes.Validated, false, "Please select a Resolution Code:", true, "", "", true, null));

			string htmlInput = File.ReadAllText(@"Form.html");

			PopulatePromptValues(htmlInput, inputs);

			foreach (var input in inputs)
			{
				if (input.DataType == Input.DataTypes.Validated)
					Console.WriteLine(input.PromptValues.Aggregate((x, y) => x + ", " + y));
			}
		}

		static void PopulatePromptValues(string htmlInput, List<Input> inputs)
		{
			HtmlNode.ElementsFlags.Remove("option");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlInput);

            foreach (var input in inputs.Where(x => x.DataType == Input.DataTypes.Validated))
            {
				/*
                 * //select[@name='Input_1']
                 * All <select> elements in the context node which have a name attribute equal to InPut_1.
                 */
	            //string pattern = string.Format("//select[@name='{0}']", input.InputId);
	            string pattern = $"//select[@id='{input.InputId}'][1]/option";

	            var optionNodes = htmlDoc.DocumentNode.SelectNodes(pattern);
				if (optionNodes != null)
					input.PromptValues = new List<string>(optionNodes.Select(x => x.InnerText));
            }

			// Validated inputs need their PromptValues collection updated from the passed in html.
			// Need to find the correct select tag by id and parse out the option values to build up the prompt collection.
		} 
	}
}
