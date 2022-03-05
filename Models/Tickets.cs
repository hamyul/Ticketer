using System;

namespace Models
{
    public class Ticket
    {
        public Ticket(int id, string title, string description, User owner, Project project)
        {
            Id = id;
            Title = title;
            Description = description;
            Owner = owner;
            Status = TicketStatus.Created;
            Project = project;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public User Owner { get; set; }
        public User AssignedTo { get; set; }
        public TicketStatus Status { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}