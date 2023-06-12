using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Copy_Explanation : ContentPage
{
	public Copy_Explanation()
	{
        InitializeComponent();

        XmlDocument CopyDoc = new XmlDocument();
        CopyDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Copy_Content.xml"));

        explanation_label.Text = CopyDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}