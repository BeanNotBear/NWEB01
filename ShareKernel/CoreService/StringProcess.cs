using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.CoreService
{
	public static class StringProcess
	{
		public static string EncodingUTF8(this string str)
		{
			byte[] bytes = Encoding.Default.GetBytes(str);
			string result = Encoding.UTF8.GetString(bytes);
			return result;
		}
	}
}
