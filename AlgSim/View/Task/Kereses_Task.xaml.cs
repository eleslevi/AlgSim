using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Kereses_Task : ContentPage
{
    public Kereses_Task()
    {
        InitializeComponent();

        XmlDocument KeresesDoc = new XmlDocument();
        KeresesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kereses_Content.xml"));

        tasks_label.Text = KeresesDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}