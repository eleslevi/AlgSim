using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Eldontes_Task : ContentPage
{
    public Eldontes_Task()
    {
        InitializeComponent();

        XmlDocument EldontesDoc = new XmlDocument();
        EldontesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Eldontes_Content.xml"));

        tasks_label.Text = EldontesDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}