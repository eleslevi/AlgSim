using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Kivalasztas_Task : ContentPage
{
    public Kivalasztas_Task()
    {
        InitializeComponent();

        XmlDocument KivalasztasDoc = new XmlDocument();
        KivalasztasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kivalasztas_Content.xml"));

        tasks_label.Text = KivalasztasDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}