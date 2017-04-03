//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoStore.Business.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Roles = new HashSet<Role>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte[] Revision { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual LoginCredential LoginCredential { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
