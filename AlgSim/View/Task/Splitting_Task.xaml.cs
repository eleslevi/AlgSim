using System.IO;
using System.Xml;

namespace AlgSim.View.Task;

public partial class Splitting_Task : ContentPage
{
    public Splitting_Task()
    {
        InitializeComponent();

        XmlDocument SplittingDoc = new XmlDocument();
        SplittingDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Splitting_Content.xml"));

        tasks_label.Text = SplittingDoc.SelectSingleNode("Task/Tasks").InnerText;
    }
}