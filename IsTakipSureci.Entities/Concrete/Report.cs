using IsTakipSureci.Entities.Interfaces;

namespace IsTakipSureci.Entities.Concrete
{
    public class Report:ITable
    {
        public int Id { get; set; }

        public string ReportTitle { get; set; }

        public string ReportDescription { get; set; }

        // Raporun 1 görevi olacak
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}
