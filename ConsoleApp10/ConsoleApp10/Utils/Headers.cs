using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Utils
{
    public class Headers
    {
        public String Header { get; set; }
        public List<String> SubHeader { get; set; }

        public Headers(String _Header, List<String> _SubHeader) 
        {
            Header = _Header;
            SubHeader = _SubHeader;
        }

    }
}
