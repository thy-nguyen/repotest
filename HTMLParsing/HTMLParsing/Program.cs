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

            Console.WriteLine(string.Join(System.Environment.NewLine, PopulatePromptValues(htmlInput, inputs)));
		}

		static List<string> PopulatePromptValues(string htmlInput, List<Input> inputs)
		{

            List<string> listRecords = new List<string>();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlInput);

            foreach (var input in inputs)
            {
                if (input.DataType != Input.DataTypes.Validated)
                    continue;

                /*
                 * //select[@name='Input_1']
                 * All <select> elements in the context node which have a name attribute equal to InPut_1.
                 */
                foreach (HtmlAgilityPack.HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//select[@name='Input_1']"))
                {
                    string record = string.Empty;

                    /*
                     * .//option
                     * All<option> elements one or more levels deep in the current context.
                     * option[@value]
                     * All <option> elements with value attributes, of the current context.
                     */
                    foreach (HtmlNode node2 in node.SelectNodes(".//option[@value]"))
                    {
                        string optionValue = node2.GetAttributeValue("value", "");
                        record = node2.InnerText;
                        listRecords.Add(record);
                 
                    }
                    

                }

            }

            return listRecords;

			// Validated inputs need their PromptValues collection updated from the passed in html.
			// Need to find the correct select tag by id and parse out the option values to build up the prompt collection.
			
			 
			
		} 
	}
}
