using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    public class SerializableTreeNode
    {
        public string Text { get; set; }
        public object Tag { get; set; }
        public List<SerializableTreeNode> Nodes { get; set; }
    }
}
