using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Copy_Task : ContentPage
{
    public Copy_Task()
    {
        InitializeComponent();

        XmlDocument CopyDoc = new XmlDocument();
        CopyDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Copy_Content.xml"));

        tasks_label.Text = CopyDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}