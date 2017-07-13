using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agencies.Models
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "State Of Origin")]
        [Required]
        public StateOfOrigin StateOfOrigin { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required]
        public string DateOfBirth { get; set; }
        [Display(Name = "Tetiary Institution Attended")]
        [Required]
        public string TetiaryInstitutionAttended { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        public DateTime? DateApplied = DateTime.Now;
        [Display(Name = "Mobile Number")]
        [Required]
        public string MobileNo { get; set; }


        [Display(Name = "Gender")]
        [Required]
        public Gender Gender { get; set; }
        [Display(Name = "Marital Status")]
        [Required]
        public MaritalStatus MaritalStatus { get; set; }
        [Display(Name = "Religion")]
        [Required]
        public Religion Religion { get; set; }
        [Display(Name = "Qualification")]
        [Required]
        public string Quallification { get; set; }



    }
    public enum Gender
    {
        Male, Female
    }
    public enum MaritalStatus
    {
        Single, Married, Divorced, Widowed
    }
    public enum StateOfOrigin
    {
        ABIA, ANAMBRA, AKWAIBOM, BAUCHI, OYO, PLATEAU, ADAMAWA, DELTA, EDO, CROSSRIVER, ONDO, OSUN, OGUN, EKITI, NASARAWA, GOMBE, RIVERS, ENUGU, IMO, YOBE, BORNO, TARABA, SOKOTO, KANO, KADUNA, LAGOS, KATSINA
    }
    public enum Qualification
    {
        BTECH, BSC, HND, ND, NCE
    }
    public enum Religion
    {
        Christianity, Islam
    }

}

