using System.IO;
using System.Xml;


namespace AlgSim.View;

public partial class Intersection_Page : ContentPage
{
	public Intersection_Page()
	{
        InitializeComponent();

        XmlDocument IntersectionDoc = new XmlDocument();
        IntersectionDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Intersection_Content.xml"));

        task_line_1.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_10.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line10").InnerText;
        task_line_11.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line11").InnerText;
        task_line_12.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line12").InnerText;
        task_line_13.Text = IntersectionDoc.SelectSingleNode("Task/TaskLines/Line13").InnerText;
    }
}