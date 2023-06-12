using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Kereses_Explanation : ContentPage
{
	public Kereses_Explanation()
	{
        InitializeComponent();

        XmlDocument KeresesDoc = new XmlDocument();
        KeresesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kereses_Content.xml"));

        explanation_label.Text = KeresesDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}