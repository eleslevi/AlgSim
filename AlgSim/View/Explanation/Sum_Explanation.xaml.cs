using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Sum_Explanation : ContentPage
{
	public Sum_Explanation()
	{
        InitializeComponent();

        XmlDocument SumDoc = new XmlDocument();
        SumDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Sum_Content.xml"));

        explanation_label.Text = SumDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}