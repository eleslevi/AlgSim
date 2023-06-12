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

        XmlDocument MaxSelDoc = new XmlDocument();
        MaxSelDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.MaxSelection_Content.xml"));

        task_line_1.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
        task_line_7.Text = MaxSelDoc.SelectSingleNode("Task/TaskLines/Line7").InnerText;
    }
}