using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using AlgSim;
using System.Collections.ObjectModel;

namespace AlgSim.View;

public partial class Sum_Page : ContentPage
{
	public Sum_Page()
	{
		InitializeComponent();

		XmlDocument SumDoc = new XmlDocument();
        SumDoc.Load(this.GetType().Assembly.GetManifestResourceStream("AlgSim.Resources.ContentXMLs.Sum_Content.xml"));
        
		task_line_1.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line1").InnerText;
        task_line_2.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line2").InnerText;
        task_line_3.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line3").InnerText;
        task_line_4.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line4").InnerText;
        task_line_5.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line5").InnerText;
        task_line_6.Text = SumDoc.SelectSingleNode("Task/TaskLines/Line6").InnerText;
    }
}