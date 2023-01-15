namespace DecoratorDemo.Decorated
{
    public class MemberRepository : IMemberRepository
    {
        public IdMapping GetById(int id)
        {
            return new List<IdMapping>
            {
                new IdMapping { Id = 1, DataValue = "a" },
                new IdMapping { Id = 2, DataValue = "b" },
                new IdMapping { Id = 3, DataValue = "c" }
            }.Where(x => x.Id == id).First();
        }
    }
}
