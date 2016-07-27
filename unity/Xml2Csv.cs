using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;

public class Xml2Csv : MonoBehaviour 
{
    StringBuilder builder = new StringBuilder();
	void Start () 
    {
        XmlDocument xmlDoc = new XmlDocument();
        if (System.IO.File.Exists(GetInputFile()))
        {
            xmlDoc.LoadXml(System.IO.File.ReadAllText(GetInputFile()));
        }

        for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
        {
            XmlNode node = xmlDoc.DocumentElement.ChildNodes[i];

            if (i == 0)
            {
                //第一行
                for (int k = 0; k < node.Attributes.Count; k++)
                {
                    builder.Append(node.Attributes[k].Name.ToLower());
                    if (k != node.Attributes.Count - 1)
                    {
                        builder.Append(",");
                    }
                }
                builder.Append("\r\n");
                //第二行
                for (int k = 0; k < node.Attributes.Count; k++)
                {
                    if (k == 0)
                    {
                        builder.Append("int");
                    }
                    else
                    {
                        builder.Append("string");
                    }
                    if (k != node.Attributes.Count - 1)
                    {
                        builder.Append(",");
                    }
                }
                builder.Append("\r\n");
                //第三行
                for (int k = 0; k < node.Attributes.Count; k++)
                {
                    if (k == 0)
                    {
                        builder.Append("Key");
                    }
                    else
                    {
                        builder.Append("语言");
                    }
                    if (k != node.Attributes.Count - 1)
                    {
                        builder.Append(",");
                    }
                }
                builder.Append("\r\n");
            }

            for (int k = 0; k < node.Attributes.Count; k++)
            {
                if (k == 0)
                {
                }
                string val = node.Attributes[k].Value;
                val = val.Replace(',', '#');
                builder.Append(val);
                if (k != node.Attributes.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append("\r\n");
        }

        using (StreamWriter sw = new StreamWriter(File.Open(GetOutputFile(), FileMode.Create), Encoding.UTF8))
        {
            sw.WriteLine(builder.ToString());
        }
        Debug.Log("Convert Over!");
    }

    string GetInputFile()
    {
        string path = Application.dataPath + "/Lcl/LanguageConfig.xml";
        return path;
    }

    string GetOutputFile()
    {
        string path = Application.dataPath + "/config/languageconfig.csv";
        return path;
    }
}
