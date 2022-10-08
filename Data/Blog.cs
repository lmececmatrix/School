namespace KinderGarten.Data
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Class Class { get; set; }
        public List<Comment> Comments { get; set; } 
        public User User { get; set; }

        public Blog()
        {
            Id = -1;
            Name = "";
            Description = "";
            Class = new Class();
            Comments = new List<Comment>();
            User = new User();
        }
    }
}
