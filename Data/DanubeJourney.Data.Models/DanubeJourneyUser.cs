﻿// ReSharper disable VirtualMemberCallInConstructor
namespace DanubeJourney.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DanubeJourney.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class DanubeJourneyUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public DanubeJourneyUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Comments = new HashSet<Comment>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string RoleId { get; set; }

        public virtual DanubeJourneyRole Role { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
