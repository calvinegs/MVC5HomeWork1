namespace MVC5HomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ValidationAttribute;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            using (var db = new 客戶資料Entities())
            {
                int custID = ((MVC5HomeWork1.Models.客戶聯絡人)validationContext.ObjectInstance).客戶Id;
                string email = ((MVC5HomeWork1.Models.客戶聯絡人)validationContext.ObjectInstance).Email;
                int cnt = db.客戶聯絡人.Count(p => p.客戶Id == custID && p.Email == email);
                if (cnt > 1) yield return new ValidationResult("Email 不能重複", new string[] { "Email" }); ;
            }
            yield break;
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string Email { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [手機號碼格式(ErrorMessage ="手機號碼格式不符")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
