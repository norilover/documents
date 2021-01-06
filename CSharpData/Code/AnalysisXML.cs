class AnalysisXML
{
    // 分割符
    static string empty = "  ";

    static void Main(string[] args)
    {
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        // 读取xml文件
        doc.Load(@"..\example.xml");

        // 获取最外层节点
        PrintChildNodes(doc.GetElementsByTagName("test"), string.Empty);

        // Test
        Console.Read();
    }

    /// <summary>
    /// 遍历所有节点的type、name、Attributes
    /// </summary>
    static void PrintChildNodes(XmlNodeList childnodelist, string gap)
    {
        foreach (XmlNode node in childnodelist)
        {
            // 1.如果是最后一个节点且不包含属性,只打印节点之间的内容
            if (node.NodeType == XmlNodeType.Text)
            {
                Console.WriteLine(gap + node.Name + " = " + node.Value);
                continue;
            }

            // 2.打印属性名称和值
            foreach (XmlAttribute atr in node.Attributes)
            {
                Console.WriteLine(gap + atr.Name + " = " + atr.Value);
            }

            // 3.如果存在孩子，递归遍历
            if (node.ChildNodes.Count > 0)
            {
                // gap宽度增加
                PrintChildNodes(node.ChildNodes, gap + empty);
            }
        }
    }
}
