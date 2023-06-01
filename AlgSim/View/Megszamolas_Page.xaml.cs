using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class Megszamolas_Page : ContentPage
{
    public Megszamolas_Page()
    {
        InitializeComponent();

        XmlDocument megszamolasDoc = new XmlDocument();
        megszamolasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Megszamolas_Content.xml"));

        explanation_label.Text = megszamolasDoc.SelectSingleNode("Task/Explanation").InnerText;
        explanation_label.TextColor = Colors.Black;

        tasks_label.Text = megszamolasDoc.SelectSingleNode("Task/Tasks").InnerText;
        tasks_label.TextColor = Colors.Black;

        task_line_1.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;
        task_line_7.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line07").InnerText;
        task_line_8.Text = megszamolasDoc.SelectSingleNode("Task/TaskLines/Line08").InnerText;

        task_line_1.TextColor = Colors.Black;
        task_line_2.TextColor = Colors.Black;
        task_line_3.TextColor = Colors.Black;
        task_line_4.TextColor = Colors.Black;
        task_line_5.TextColor = Colors.Black;
        task_line_6.TextColor = Colors.Black;
        task_line_7.TextColor = Colors.Black;
        task_line_8.TextColor = Colors.Black;
    }
}