namespace RMSApi.Common.DTO
{
    public class JobAppliedDTO
    {
        public int Id { get; set; }

        public int JobSeekerId { get; set; }

        public int JobPostId { get; set; }

        public DateTime DateApplied { get; set; }

        //public virtual JobSeekerDTO JobSeeker { get; set; }

        //public virtual JobPostDTO JobPost { get; set; }
    }
}
