//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class AccountHolderType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountHolderType()
        {
            this.Accounts = new HashSet<Account>();
        }

        [DisplayName("Account Holder Type ID")]
        public int HolderTypeID { get; set; }

        [Required(ErrorMessage = "Holder Type Name is required.")]
        [StringLength(100, ErrorMessage = "Holder Type Name cannot exceed 100 characters.")]
        [DisplayName("Account Holder Type")]
        public string HolderTypeName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
