namespace SeaMODEPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Login()
        {
            this.Boat = new HashSet<Boat>();
        }

        public int LoginID { get; set; }
        public int BoatID { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        public string PassWord { get; set; }
        public Nullable<int> AccessLvl { get; set; }
        public string LoginErrorMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boat> Boat { get; set; }
    }
}