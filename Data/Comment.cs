namespace KinderGarten.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
