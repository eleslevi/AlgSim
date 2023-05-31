using System.Xml;

namespace AlgSim.View;

public partial class CopyPage : ContentPage
{
	public CopyPage()
	{
		InitializeComponent();
        XmlDocument copyDoc = new XmlDocument();
        copyDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Copy_Content.xml"));

        explanation_label.Text = copyDoc.SelectSingleNode("Task/Explanation").InnerText;

        tasks_label.Text = copyDoc.SelectSingleNode("Task/Tasks").InnerText;

        task_line_1.Text = copyDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = copyDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = copyDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = copyDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = copyDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
    }
}