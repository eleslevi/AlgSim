using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Union_Explanation : ContentPage
{
	public Union_Explanation()
	{
        InitializeComponent();

        XmlDocument UnionDoc = new XmlDocument();
        UnionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Union_Content.xml"));

        explanation_label.Text = UnionDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}