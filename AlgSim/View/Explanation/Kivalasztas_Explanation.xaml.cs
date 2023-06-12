using System.IO;
using System.Xml;


namespace AlgSim.View.Explanation;

public partial class Kivalasztas_Explanation : ContentPage
{
	public Kivalasztas_Explanation()
	{
        InitializeComponent();

        XmlDocument KivalasztasDoc = new XmlDocument();
        KivalasztasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kivalasztas_Content.xml"));

        explanation_label.Text = KivalasztasDoc.SelectSingleNode("Task/Explanation").InnerText;
    }
}