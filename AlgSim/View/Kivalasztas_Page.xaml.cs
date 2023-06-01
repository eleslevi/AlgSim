using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public partial class Kivalasztas_Page : ContentPage
{
    public Kivalasztas_Page()
    {
        InitializeComponent();

        XmlDocument kivalasztasDoc = new XmlDocument();
        kivalasztasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kivalasztas_Content.xml"));

        explanation_label.Text = kivalasztasDoc.SelectSingleNode("Task/Explanation").InnerText;

        tasks_label.Text = kivalasztasDoc.SelectSingleNode("Task/Tasks").InnerText;

        task_line_1.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line01").InnerText;
        task_line_2.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line02").InnerText;
        task_line_3.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line03").InnerText;
        task_line_4.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line04").InnerText;
        task_line_5.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line05").InnerText;
        task_line_6.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line06").InnerText;
        task_line_7.Text = kivalasztasDoc.SelectSingleNode("Task/Tasklines/Line07").InnerText;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            KivalasztasPage_ViewModel.userValue = Convert.ToInt32(userValue.Text);
        }
        catch (Exception ex)
        {
            //suppress
        }
    }
}