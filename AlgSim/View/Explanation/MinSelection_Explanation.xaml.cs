using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class MinSelection_Explanation : ContentPage
{
	public MinSelection_Explanation()
	{
        InitializeComponent();

        XmlDocument MinSelDoc = new XmlDocument();
        MinSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MinSelection_Content.xml"));

        explanation_label.Text = MinSelDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}