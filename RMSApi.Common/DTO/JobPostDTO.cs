namespace RMSApi.Common.DTO
{
    public class JobPostDTO
    {
        public int Id { get; set; }

        public DateTime RequiredDate { get; set; }

        public string Category { get; set; }

        public int NoOfPosts { get; set; }

        public string Location { get; set; }

        public string Qualification { get; set; }

        public int Salary { get; set; }

        public int Experience { get; set; }

        public int CompanyId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedDate { get; set; }

        //public virtual CompanyDTO Company { get; set; }
    }
}
