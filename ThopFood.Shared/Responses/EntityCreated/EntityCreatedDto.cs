namespace ThopFood.Shared.Responses.EntityCreated
{
    public class EntityCreateResponse
    {
        public int Id { get; set; }

        public EntityCreateResponse(int id)
        {
            Id = id;
        }
    }
}
