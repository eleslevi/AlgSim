using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Splitting_Explanation : ContentPage
{
	public Splitting_Explanation()
	{
        InitializeComponent();

        XmlDocument SplittingDoc = new XmlDocument();
        SplittingDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Splitting_Content.xml"));

        explanation_label.Text = SplittingDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}