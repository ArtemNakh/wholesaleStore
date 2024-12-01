namespace wholesaleStore.Models
{
    public class EnterpriceViewModel
    {
        // Параметри для FieldActivity
        public string FieldActivityName { get; set; }
        public string FieldActivityDescription { get; set; }

        // Параметри для Addresses
        public string Country { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public int NumberStreet { get; set; }

        // Параметри для Enterprice
        public string EnterpriceTitle { get; set; }
        public DateTime DateCreate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        // Параметри для Administrator
        public string AdministratorName { get; set; }
        public string AdministratorSurname { get; set; }
        public int? AdministratorPhone { get; set; }
        public string AdministratorLogin { get; set; }
        public string AdministratorPassword { get; set; }
    }
}
