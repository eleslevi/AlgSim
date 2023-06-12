using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class BubbleOrder_Explanation : ContentPage
{
	public BubbleOrder_Explanation()
	{
        InitializeComponent();

        XmlDocument BubbleOrderDoc = new XmlDocument();
        BubbleOrderDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.BubbleOrder_Content.xml"));

        explanation_label.Text = BubbleOrderDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}