using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlInput);

            foreach (var input in inputs)
            {
                if (input.DataType != Input.DataTypes.Validated)
                    continue;

				List<string> listRecords = new List<string>();

				/*
                 * //select[@name='Input_1']
                 * All <select> elements in the context node which have a name attribute equal to InPut_1.
                 */
	            //string pattern = string.Format("//select[@name='{0}']", input.InputId);
	            string pattern = $"//select[@name='{input.InputId}']";

				foreach (HtmlAgilityPack.HtmlNode node in htmlDoc.DocumentNode.SelectNodes(pattern))
                {
	                /*
                     * .//option
                     * All<option> elements one or more levels deep in the current context.
                     * option[@value]
                     * All <option> elements with value attributes, of the current context.
                     */

					foreach (HtmlNode node2 in node.SelectNodes(".//option[@value]"))
                    {
                        var record = node2.InnerText;
                        listRecords.Add(record);
                 
                    }
	                input.PromptValues = listRecords;

                }

            }

			// Validated inputs need their PromptValues collection updated from the passed in html.
			// Need to find the correct select tag by id and parse out the option values to build up the prompt collection.
			
			 
			
		} 
	}
}
