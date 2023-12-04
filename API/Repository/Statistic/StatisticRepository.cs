using API.Models;

namespace API.Repository.Statistic
{
    public class StatisticRepository : IStatisticRepository
    {

        private List<StatisticItem> allStatisticItem = new List<StatisticItem>
        {
            new StatisticItem
            {
                Id = 1,
                Name = "Test1",
                Description = "Test",
                Rating = 3.4f
            },
            new StatisticItem
            {
                Id = 2,
                Name = "Test2",
                Description = "Test",
                Rating = 3.4f
            },
            new StatisticItem
            {
                Id = 3,
                Name = "Test3",
                Description = "Test",
                Rating = 3.4f
            },
            new StatisticItem
            {
                Id = 4,
                Name = "Test4",
                Description = "Test",
                Rating = 3.4f
            },
        };

        public List<StatisticItem> GetAllStatisticItem()
        {
            return allStatisticItem;
        }

        public StatisticItem GetStatisticItem(int id)
        {
            return allStatisticItem.Find(item => item.Id == id);
        }
    }
}
