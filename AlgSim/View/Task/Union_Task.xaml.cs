using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Union_Task : ContentPage
{
    public Union_Task()
    {
        InitializeComponent();

        XmlDocument UnionDoc = new XmlDocument();
        UnionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Union_Content.xml"));

        tasks_label.Text = UnionDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}