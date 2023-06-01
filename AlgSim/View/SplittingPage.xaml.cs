using AlgSim.ViewModel;
using System.Xml;

namespace AlgSim.View;

public partial class SplittingPage : ContentPage
{
	public SplittingPage()
	{
		InitializeComponent();
        XmlDocument sumDoc = new XmlDocument();
        sumDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Splitting_Content.xml"));

        explanation_label.Text = sumDoc.SelectSingleNode("Task/Explanation").InnerText;

        tasks_label.Text = sumDoc.SelectSingleNode("Task/Tasks").InnerText;

        task_line_1.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
        task_line_8.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line8").InnerText;
        task_line_9.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_10.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_11.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        task_line_12.Text = sumDoc.SelectSingleNode("Task/TaskLines/Line9").InnerText;
        picker_SelectedIndexChanged(picker, EventArgs.Empty);
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker.SelectedIndex == -1)
        {
            picker.SelectedIndex = 0;
        }
        SplittingPage_ViewModel.selectedStatement = picker.SelectedIndex;
        picker.SelectedItem = picker.Items[SplittingPage_ViewModel.selectedStatement];
        SplittingPage_ViewModel.Statement = picker.SelectedItem.ToString();
    }

    private void userValue_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            SplittingPage_ViewModel.userValue = Convert.ToInt32(userValue.Text);
        }
        catch (Exception ex)
        {
            //suppress
        }
    }
}