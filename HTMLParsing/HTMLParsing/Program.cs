using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

		static void PopulatePromptValues(string htmlInput, List<Input> inputs)
		{
			// Validated inputs need their PromptValues collection updated from the passed in html.
			// Need to find the correct select tag by id and parse out the option values to build up the prompt collection.
			
			 
			
		} 
	}
}
