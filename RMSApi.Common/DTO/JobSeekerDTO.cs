namespace RMSApi.Common.DTO
{
    public class JobSeekerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Language { get; set; }

        public string Qualification { get; set; }

        public int PassingYear { get; set; }

        public string Category { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int Exprience { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
