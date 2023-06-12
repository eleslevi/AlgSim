using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class MinSelection_Task : ContentPage
{
    public MinSelection_Task()
    {
        InitializeComponent();

        XmlDocument MinSelDoc = new XmlDocument();
        MinSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MinSelection_Content.xml"));

        tasks_label.Text = MinSelDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}