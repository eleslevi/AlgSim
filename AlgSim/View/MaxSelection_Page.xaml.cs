using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class MaxSelection_Page : ContentPage
{
	public MaxSelection_Page()
	{
		InitializeComponent();

        XmlDocument maxSel_Doc = new XmlDocument();
        maxSel_Doc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MaxSelection_Content.xml"));

        explanation_label.Text = maxSel_Doc.SelectSingleNode("Task/Explanation").InnerText;
        explanation_label.TextColor = Colors.Black;

        tasks_label.Text = maxSel_Doc.SelectSingleNode("Task/Tasks").InnerText;
        tasks_label.TextColor = Colors.Black;

        task_line_1.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = maxSel_Doc.SelectSingleNode("Task/TaskLines/Line7").InnerText;

        task_line_1.TextColor = Colors.Black;
        task_line_2.TextColor = Colors.Black;
        task_line_3.TextColor = Colors.Black;
        task_line_4.TextColor = Colors.Black;
        task_line_5.TextColor = Colors.Black;
        task_line_6.TextColor = Colors.Black;
        task_line_7.TextColor = Colors.Black;
    }
}