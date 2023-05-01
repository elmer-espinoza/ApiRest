namespace ApiRestService.Models

{
    public class Country
    {
        //public string CountryName; 
        public string? CountryName { get; set; } // = String.Empty;

        public Country(string countryname) { 
           this.CountryName = countryname;
        }    

    }
}
