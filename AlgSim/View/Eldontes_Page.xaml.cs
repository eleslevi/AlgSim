using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class Eldontes_Page : ContentPage
{
    public Eldontes_Page()
    {
        InitializeComponent();
        
        XmlDocument eldontesDoc = new XmlDocument();
        eldontesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Eldontes_Content.xml"));

        explanation_label.Text = eldontesDoc.SelectSingleNode("Task/Explanation").InnerText;
        explanation_label.TextColor = Colors.Black;

        tasks_label.Text = eldontesDoc.SelectSingleNode("Task/Tasks").InnerText;
        tasks_label.TextColor = Colors.Black;

        task_line_1.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;
        task_line_7.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line07").InnerText;
        task_line_8.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line08").InnerText;
        task_line_9.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line09").InnerText;
        task_line_10.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line10").InnerText;
        task_line_11.Text = eldontesDoc.SelectSingleNode("Task/TaskLines/Line11").InnerText;

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
        task_line_11.TextColor = Colors.Black;

        var legordulo = new List<string>();
        legordulo.Add("Páros szám");
        legordulo.Add("Páratlan szám");
        legordulo.Add("Konkrét érték");

        Picker picker = new Picker { Title = "" };
        picker.ItemsSource = legordulo;

        Label kivalasztott = new Label();
        kivalasztott.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
    }
}