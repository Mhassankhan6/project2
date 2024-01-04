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

    public partial class Notification
    {
        [DisplayName("Notification ID")]
        public int NotificationID { get; set; }

        [Required(ErrorMessage = "Notification Type is required.")]
        [StringLength(100, ErrorMessage = "Notification Type cannot exceed 100 characters.")]
        [DisplayName("Notification Type")]
        public string NotificationType { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Read Status is required.")]
        [StringLength(10, ErrorMessage = "Read Status cannot exceed 10 characters.")]
        [DisplayName("Read Status")]
        public string ReadStatus { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Date format.")]
        public Nullable<System.DateTime> Time { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [DisplayName("User ID")]
        public Nullable<int> UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}