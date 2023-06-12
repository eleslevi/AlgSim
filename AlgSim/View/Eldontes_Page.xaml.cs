using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public partial class Eldontes_Page : ContentPage
{
    public Eldontes_Page()
    {
        InitializeComponent();
        
        XmlDocument EldontesDoc = new XmlDocument();
        EldontesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Eldontes_Content.xml"));

        task_line_1.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;
        task_line_7.Text = EldontesDoc.SelectSingleNode("Task/TaskLines/Line07").InnerText;

        picker_SelectedIndexChanged(picker, EventArgs.Empty);
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker.SelectedIndex == -1)
        {
            picker.SelectedIndex = 0;
        }
        EldontesPage_ViewModel.selectedStatement = picker.SelectedIndex;
        picker.SelectedItem = picker.Items[EldontesPage_ViewModel.selectedStatement];
        EldontesPage_ViewModel.Statement = picker.SelectedItem.ToString();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            EldontesPage_ViewModel.userValue = Convert.ToInt32(userValue.Text);
        }
        catch (Exception ex)
        {
            //suppress
        }
    }
}