namespace PlanOfStudy.Models
{
    public class Plan
    {
        public List<PlanLine> Lines { get; set; } = new List<PlanLine>();
        public virtual void AddItem(Course course, int quantity)
        {
            PlanLine? line = Lines
                .Where(p => p.Course.CourseID == course.CourseID)
                .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new PlanLine
                {
                    Course = course,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Course course) =>
            Lines.RemoveAll(l => l.Course.CourseID == course.CourseID);
        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Course.Credits * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class PlanLine
    {
        public int PlanLineID { get; set; }
        public Course Course { get; set; } = new();
        public int Quantity { get; set; }
    }
}
