namespace RMSApi.Data.Models
{
    public class JobApplied
    {
        public int Id { get; set; }

        public int JobSeekerId { get; set; }

        public int JobPostId { get; set; }

        public DateTime DateApplied { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }

        public virtual JobPost JobPost { get; set; }
    }
}
