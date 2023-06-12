using AlgSim.ViewModel;
using System.Xml;

namespace AlgSim.View;

public partial class CopyPage : ContentPage
{
	public CopyPage()
	{
		InitializeComponent();
        XmlDocument CopyDoc = new XmlDocument();
        CopyDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Copy_Content.xml"));

        task_line_1.Text = CopyDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = CopyDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = CopyDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = CopyDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = CopyDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        CopyPage_ViewModel.Function = !CopyPage_ViewModel.Function;
    }
}