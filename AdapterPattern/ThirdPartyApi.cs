using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class ThirdPartyApi
    {
        public int Count { get; set; }
        public List<string> values { get; set; } = new List<string>();


		public ThirdPartyApi()
		{
            values.Add("ALPHA");
            values.Add("BETHA");
            values.Add("DELTA");
            values.Add("DELTA-01");
            values.Add("BETHA-02");
            values.Add("ALPHA-33");
            values.Add("ALPHA-18");
            values.Add("BETHA-44");
            Count = values.Count;
        }
    }
}
