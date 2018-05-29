namespace CutieShop.Models.Entities
{
    public partial class JoinXx
    {
        public string IdJoin { get; set; }
        public string IdReport { get; set; }
        public string IdTdk { get; set; }
        public string IdNtk { get; set; }
        public string IdXtk { get; set; }
        public string IdTck { get; set; }

        public ReportDetails IdJoinNavigation { get; set; }
        public NhapTrongKy IdNtkNavigation { get; set; }
        public Report IdReportNavigation { get; set; }
        public TonCuoiKy IdTckNavigation { get; set; }
        public TonDauKy IdTdkNavigation { get; set; }
        public XuatTrongKy IdXtkNavigation { get; set; }
    }
}
