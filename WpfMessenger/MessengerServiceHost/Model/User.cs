using MessengerServiceHost.Model.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [DataMember]
        public string Login { get; set; }
        [Required]
        [DataMember]
        public byte[] Password { get; set; }
        [Required]
        [DataMember]
        public string FirstName { get; set; }
        [Required]
        [DataMember]
        public string LastName { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public ICollection<Group> Groups { get; set; }

        public static explicit operator ViewUser(User u)
        {
            return new ViewUser
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Login = u.Login,
                Image = u.Image,
                Password = u.Password,
                Phone = u.Phone,
                Email = u.Email,
            };
        }
        public static explicit operator User(ViewUser u)
        {
            return new User
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Login = u.Login,
                Image = u.Image,
                Password = u.Password,
                Phone = u.Phone,
                Email = u.Email,
            };
        }
    }
}