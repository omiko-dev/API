using API.Models;

namespace API.Repository.Statistic
{
    public interface IStatisticRepository
    {

        public List<StatisticItem> GetAllStatisticItem();
        public StatisticItem GetStatisticItem(int id);

    }
}
