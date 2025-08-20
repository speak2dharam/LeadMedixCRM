namespace LeadMedixCRM.DTOs
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string Alpha2Code { get; set; } = string.Empty;
        public string Alpha3Code { get; set; } = string.Empty;
        public string? NumericCode { get; set; }
        public string? PhoneCode { get; set; }
    }
}
