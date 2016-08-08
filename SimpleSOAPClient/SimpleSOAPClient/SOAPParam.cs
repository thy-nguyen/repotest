using System;
namespace SimpleSOAPClient
{
	public class SOAPParam
	{
		public enum dataType { stringParam, boolParam, intParam };
		public dataType DataType { get; private set; }
		public string Name { get; private set; }
		public object Value { get; private set; }


		public SOAPParam(string name, string value)
		{
			Init(name, dataType.stringParam, value);
		}

		public SOAPParam(string name, bool value)
		{
			Init(name, dataType.boolParam, value);
		}

		public SOAPParam(string name, int value)
		{
			Init(name, dataType.intParam, value);
		}

		public string GetValueAsString()
		{
			if (DataType == dataType.boolParam)
				return ((bool)Value ? "true" : "false");

			return Value.ToString();
		}

		private void Init(string name, dataType dt, object value)
		{
			DataType = dt;
			Name = name;
			Value = value;
		}
	}
}
