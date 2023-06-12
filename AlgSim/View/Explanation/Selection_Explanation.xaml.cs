using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Selection_Explanation : ContentPage
{
	public Selection_Explanation()
	{
        InitializeComponent();

        XmlDocument SelectionDoc = new XmlDocument();
        SelectionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Selection_Content.xml"));

        explanation_label.Text = SelectionDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}