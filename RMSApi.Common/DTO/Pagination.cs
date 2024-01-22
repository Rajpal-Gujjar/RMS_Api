namespace RMSApi.Common.DTO
{
    public class Pagination
    {
        public int TotalCount { get; set; }

        public List<JobPostDTO> JobPosts { get; set; }
    }
}
