//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Customer : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Products = new HashSet<Product>();
        }
    

        public int regid { get; set; }
        [Display(Name ="First Name")]
        [Required]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string last_name { get; set; }

        [Display(Name = "User Name")]
        [Required][MinLength(3)]
        public string user_name { get; set; }


        [Display(Name = "Password")]
        [Required][MinLength(8)][DataType(DataType.Password)]
        public string pass_word { get; set; }


        [Display(Name = "Phone Number")]
        [Required][DataType(DataType.PhoneNumber)]
        public string phone { get; set; }


        [Display(Name = "Division")]
        [Required]
        public string division { get; set; }


        [Display(Name = "Email")]
        [Required][DataType(DataType.EmailAddress)]
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
