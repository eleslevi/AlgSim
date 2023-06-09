using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public partial class Kereses_Page : ContentPage
{
    public Kereses_Page()
    {
        InitializeComponent();

        XmlDocument KeresesDoc = new XmlDocument();
        KeresesDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Kereses_Content.xml"));

        task_line_1.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line01").InnerText;
        task_line_2.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line02").InnerText;
        task_line_3.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line03").InnerText;
        task_line_4.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line04").InnerText;
        task_line_5.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line05").InnerText;
        task_line_6.Text = KeresesDoc.SelectSingleNode("Task/TaskLines/Line06").InnerText;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            KeresesPage_ViewModel.userValue = Convert.ToInt32(userValue.Text);
        }
        catch (Exception ex)
        {
            // suppress
        }
    }
}