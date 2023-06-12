using System.Xml;

namespace AlgSim.View;

public partial class Swap_Page : ContentPage
{
	public Swap_Page()
	{
		InitializeComponent();

        XmlDocument SwapDoc = new XmlDocument();
        SwapDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Swap_Content.xml"));

        task_line_1.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = SwapDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
    }
}