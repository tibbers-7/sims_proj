using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.FileHandler
{
    internal interface FileHandlerInterface
    {
        public List<object> Read();
        public void Write(string[] newLines);
    }
}
