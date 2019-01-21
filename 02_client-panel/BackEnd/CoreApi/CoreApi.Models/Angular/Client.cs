using CoreApi.Models.Common;

namespace CoreApi.Models.Angular
{
    public class Client : EntityBase
    {
        public decimal Balance { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
