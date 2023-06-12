using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Megszamolas_Task : ContentPage
{
    public Megszamolas_Task()
    {
        InitializeComponent();

        XmlDocument MegszamolasDoc = new XmlDocument();
        MegszamolasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Megszamolas_Content.xml"));

        tasks_label.Text = MegszamolasDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}