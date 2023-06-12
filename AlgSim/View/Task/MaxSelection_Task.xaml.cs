using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class MaxSelection_Task : ContentPage
{
    public MaxSelection_Task()
    {
        InitializeComponent();

        XmlDocument MaxSelDoc = new XmlDocument();
        MaxSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MaxSelection_Content.xml"));

        tasks_label.Text = MaxSelDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}