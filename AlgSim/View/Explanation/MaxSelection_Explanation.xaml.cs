using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class MaxSelection_Explanation : ContentPage
{
	public MaxSelection_Explanation()
	{
        InitializeComponent();

        XmlDocument MaxSelDoc = new XmlDocument();
        MaxSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MaxSelection_Content.xml"));

        explanation_label.Text = MaxSelDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}