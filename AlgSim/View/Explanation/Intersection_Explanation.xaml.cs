using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Intersection_Explanation : ContentPage
{
	public Intersection_Explanation()
	{
        InitializeComponent();

        XmlDocument IntersectionDoc = new XmlDocument();
        IntersectionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Intersection_Content.xml"));

        explanation_label.Text = IntersectionDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}