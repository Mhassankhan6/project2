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

    public partial class Beneficiary
    {
        [DisplayName("Beneficiary ID")]
        public int BeneficiaryID { get; set; }

        [Required(ErrorMessage = "Beneficiary Name is required.")]
        [StringLength(100, ErrorMessage = "Beneficiary Name cannot exceed 100 characters.")]
        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        [StringLength(20, ErrorMessage = "Account Number cannot exceed 20 characters.")]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Type is required.")]
        [StringLength(50, ErrorMessage = "Account Type cannot exceed 50 characters.")]
        [DisplayName("Account Type")]
        public string AccountType { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [DisplayName("User ID")]
        public Nullable<int> UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}
