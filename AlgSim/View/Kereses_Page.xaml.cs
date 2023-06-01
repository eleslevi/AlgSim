using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class Kereses_Page : ContentPage
{
    public Kereses_Page()
    {
        InitializeComponent();

        XmlDocument keresesDoc = new XmlDocument();
        keresesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kereses_Content.xml"));

        explanation_label.Text = keresesDoc.SelectSingleNode("Task/Explanation").InnerText;
        explanation_label.TextColor = Colors.Black;

        tasks_label.Text = keresesDoc.SelectSingleNode("Task/Tasks").InnerText;
        tasks_label.TextColor = Colors.Black;

        task_line_1.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;
        task_line_7.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line07").InnerText;
        task_line_8.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line08").InnerText;
        task_line_9.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line09").InnerText;
        task_line_10.Text = keresesDoc.SelectSingleNode("Task/TaskLines/Line10").InnerText;

        task_line_1.TextColor = Colors.Black;
        task_line_2.TextColor = Colors.Black;
        task_line_3.TextColor = Colors.Black;
        task_line_4.TextColor = Colors.Black;
        task_line_5.TextColor = Colors.Black;
        task_line_6.TextColor = Colors.Black;
        task_line_7.TextColor = Colors.Black;
        task_line_8.TextColor = Colors.Black;
        task_line_9.TextColor = Colors.Black;
        task_line_10.TextColor = Colors.Black;
    }
}