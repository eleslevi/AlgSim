using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Intersection_Task : ContentPage
{
    public Intersection_Task()
    {
        InitializeComponent();

        XmlDocument IntersectionDoc = new XmlDocument();
        IntersectionDoc.Load(GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Intersection_Content.xml"));

        tasks_label.Text = IntersectionDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}