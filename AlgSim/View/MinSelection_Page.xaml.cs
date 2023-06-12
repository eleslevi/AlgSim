using System.Xml;

namespace AlgSim.View;

public partial class MinSelection_Page : ContentPage
{
	public MinSelection_Page()
	{
		InitializeComponent();

        XmlDocument MinSelDoc = new XmlDocument();
        MinSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MinSelection_Content.xml"));

        task_line_1.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_10.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line10").InnerText;
        task_line_11.Text = MinSelDoc.SelectSingleNode("Task/TaskLines/Line11").InnerText;
    }
}