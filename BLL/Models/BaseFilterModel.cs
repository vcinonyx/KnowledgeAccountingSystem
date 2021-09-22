namespace BLL.Models
{
    public abstract class BaseFilterModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public BaseFilterModel()
        {
            Page = 1;
            Limit = 20;
        }
    }
}
