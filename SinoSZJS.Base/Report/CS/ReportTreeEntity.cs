
namespace SinoSZJS.Base.Report.CS
{
	public class ReportTreeEntity
	{
		public string TreeNodeID { set; get; }

		public string TreeNodeText { set; get; }

		public TreeNodeType TreeNodeType { set; get; }

		public override string ToString()
		{
			return TreeNodeText;
		}
	}
}
