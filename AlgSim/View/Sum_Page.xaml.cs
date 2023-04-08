using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class Sum_Page : ContentPage
{
	public Sum_Page()
	{
		InitializeComponent();

		XmlDocument sumDoc = new XmlDocument();
        sumDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Sum_Content.xml"));

		explanation_label.Text = sumDoc.SelectSingleNode("Task/Explanation").InnerText;
		explanation_label.TextColor = Colors.Black;

		tasks_label.Text = sumDoc.SelectSingleNode("Task/Tasks").InnerText;
		tasks_label.TextColor = Colors.Black;

		task_line_1.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;

		task_line_1.TextColor = Colors.Black;
        task_line_2.TextColor = Colors.Black;
        task_line_3.TextColor = Colors.Black;
        task_line_4.TextColor = Colors.Black;
        task_line_5.TextColor = Colors.Black;
        task_line_6.TextColor = Colors.Black;
    }
}