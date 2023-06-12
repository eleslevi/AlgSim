using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Selection_Task : ContentPage
{
    public Selection_Task()
    {
        InitializeComponent();

        XmlDocument SelectionDoc = new XmlDocument();
        SelectionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Selection_Content.xml"));

        tasks_label.Text = SelectionDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}