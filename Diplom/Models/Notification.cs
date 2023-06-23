namespace Diplom.Models
{
    public class Notification
    {
        public Notification() { }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }
        public User User { get; set; }
    }
}
