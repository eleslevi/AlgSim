using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class BubbleOrder_Task : ContentPage
{
    public BubbleOrder_Task()
    {
        InitializeComponent();

        XmlDocument BubbleOrderDoc = new XmlDocument();
        BubbleOrderDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.BubbleOrder_Content.xml"));

        tasks_label.Text = BubbleOrderDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}