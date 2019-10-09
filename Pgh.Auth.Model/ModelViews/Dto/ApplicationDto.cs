using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pgh.Auth.Model.ModelViews.Dto
{
    public class ApplicationDtoCreate
    {
        [Required,MaxLength(15)]
        [JsonProperty("Application Code")]
        public string AppCode { get; set; }
        [Required,MaxLength(40)]
        [JsonProperty("Application Name")]
        public string AppName { get; set; }
        [Required,MaxLength(50)]
        [JsonProperty("Application Display Name")]
        public string AppDisplayName { get; set; }
        [JsonProperty("Application Description")]
        public string AppDescription { get; set; }
        [JsonProperty("Application State")]
        public bool AppState { get; set; }
    }

    public class ApplicationDtoRead
    {
        [Required]
        [JsonProperty("Application ID")]
        public Guid AppId { get; set; }
        [JsonProperty("Application Code")]
        public string AppCode { get; set; }
        [JsonProperty("Application Name")]
        public string AppName { get; set; }
        [JsonProperty("Application Display Name")]
        public string AppDisplayName { get; set; }
        //Might hide this informations
        [JsonProperty("Application Description")]
        public string AppDescription { get; set; }
        [JsonProperty("Application State")]
        public bool AppState { get; set; }
    }
    
    public class ApplicationUsersDto
    {
        [Required]
        [JsonProperty("Application ID")]
        public Guid AppId { get; set; }
        [JsonProperty("Application Code")]
        public string AppCode { get; set; }
        [JsonProperty("Application Name")]
        public string AppName { get; set; }
        [JsonProperty("Application Display Name")]
        public string AppDisplayName { get; set; }
        //Might hide this informations
        [JsonProperty("Application Description")]
        public string AppDescription { get; set; }
        [JsonProperty("Application State")]
        public bool AppState { get; set; }

        [JsonProperty("Liste Utilisateurs")]
        public IEnumerable<ApplicationUsersDtoRead> Users { get; set; } = new List<ApplicationUsersDtoRead>();
    }

    public class AppUsersDto
    {
        [Required]
        [JsonProperty("User ID")]
        public Guid IdUser { get; set; }
        [Required]
        [JsonProperty("User Password")]
        public string Password { get; set; }
    }
    
    public class ApplicationUsersDtoRead
    {
        [Required]
        [JsonProperty("User ID")]
        public Guid UsersId { get; set; }
        [Required,MaxLength(8)]
        [JsonProperty("User CIN")]
        public string UsersCode { get; set; }
        [JsonProperty("User Name")]
        public string UsersFullName { get; set; }
        [JsonProperty("User State")]
        public string UsersState { get; set; }
        [JsonProperty("User Mail")]
        public string UsersMail { get; set; }
        [JsonProperty("User Mail Intern")]
        public string UsersMailIntern { get; set; }
        [JsonProperty("User Post Name")]
        public string UsersPosteName { get; set; }
        [JsonProperty("User Office Number")]
        public string UsersPhoneNumber { get; set; }
        [JsonProperty("User Personal Number")]
        public string UsersPersonalNumber { get; set; }
        [JsonProperty("User Gender")]
        public string UsersGenderCode { get; set; }
        [JsonProperty("User Subsidiary Name")]
        public string UsersFilialeName { get; set; }
        [JsonProperty("User Subsidiary Code")]
        public string UsersFilialeCode { get; set; }
        [JsonProperty("User Birth Date")]
        public DateTime UsersBirthDate { get; set; }
        [JsonProperty("User Join Date")]
        public DateTime UsersJoinDate { get; set; }
        [JsonProperty("User Leave Date")]
        public DateTime UsersDateLeave { get; set; }
        [JsonProperty("User Password")]
        public string Password { get; set; }
    }

}