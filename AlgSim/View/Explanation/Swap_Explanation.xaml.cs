using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Swap_Explanation : ContentPage
{
	public Swap_Explanation()
	{
        InitializeComponent();

        XmlDocument SwapDoc = new XmlDocument();
        SwapDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Swap_Content.xml"));

        explanation_label.Text = SwapDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}