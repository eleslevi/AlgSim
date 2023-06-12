using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Megszamolas_Explanation : ContentPage
{
	public Megszamolas_Explanation()
	{
        InitializeComponent();

        XmlDocument MegszamolasDoc = new XmlDocument();
        MegszamolasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Megszamolas_Content.xml"));

        explanation_label.Text = MegszamolasDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}