using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Sum_Task : ContentPage
{
    public Sum_Task()
    {
        InitializeComponent();

        XmlDocument SumDoc = new XmlDocument();
        SumDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Sum_Content.xml"));

        tasks_label.Text = SumDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}