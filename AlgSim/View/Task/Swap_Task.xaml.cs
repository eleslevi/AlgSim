using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Swap_Task : ContentPage
{
    public Swap_Task()
    {
        InitializeComponent();

        XmlDocument SwapDoc = new XmlDocument();
        SwapDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Swap_Content.xml"));

        tasks_label.Text = SwapDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}