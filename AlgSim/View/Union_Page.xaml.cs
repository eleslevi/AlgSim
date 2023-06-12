using System.Xml;

namespace AlgSim.View;

public partial class Union_Page : ContentPage
{
	public Union_Page()
	{
		InitializeComponent();

        XmlDocument UnionDoc = new XmlDocument();
        UnionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Union_Content.xml"));

        task_line_1.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_10.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line10").InnerText;
        task_line_11.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line11").InnerText;
        task_line_12.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line12").InnerText;
        task_line_13.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line13").InnerText;
        task_line_14.Text = UnionDoc.SelectSingleNode("Task/TaskLines/Line14").InnerText;
    }
}