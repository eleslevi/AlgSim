using System.Xml;

namespace AlgSim.View;

public partial class BubbleOrderPage : ContentPage
{
	public BubbleOrderPage()
	{
		InitializeComponent();
        XmlDocument BubbleOrderDoc = new XmlDocument();
        BubbleOrderDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.BubbleOrder_Content.xml"));

        task_line_1.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = BubbleOrderDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
    }
}