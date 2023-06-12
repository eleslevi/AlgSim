using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public partial class Megszamolas_Page : ContentPage
{
    public Megszamolas_Page()
    {
        InitializeComponent();

        XmlDocument MegszamolasDoc = new XmlDocument();
        MegszamolasDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Megszamolas_Content.xml"));

        task_line_1.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = MegszamolasDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;

        Picker_SelectedIndexChanged(picker, EventArgs.Empty);
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            MegszamolasPage_ViewModel.userValue = Convert.ToInt32(userValue.Text);
        }
        catch (Exception ex)
        {
            //suppress
        }
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker.SelectedIndex == -1)
        {
            picker.SelectedIndex = 0;
        }
        MegszamolasPage_ViewModel.selectedStatement = picker.SelectedIndex;
        picker.SelectedItem = picker.Items[MegszamolasPage_ViewModel.selectedStatement];
        MegszamolasPage_ViewModel.Statement = picker.SelectedItem.ToString();
    }
}