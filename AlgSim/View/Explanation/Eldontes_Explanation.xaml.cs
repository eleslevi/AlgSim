using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Eldontes_Explanation : ContentPage
{
	public Eldontes_Explanation()
	{
        InitializeComponent();

        XmlDocument EldontesDoc = new XmlDocument();
        EldontesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Eldontes_Content.xml"));

        explanation_label.Text = EldontesDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}