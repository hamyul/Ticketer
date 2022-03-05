namespace Models
{
    public class Comment
    {
        public Comment(int id, User createdBy, DateTime createdOn, string text)
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            Text = text;
        }

        public int Id { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Text { get; set; }
    }
}