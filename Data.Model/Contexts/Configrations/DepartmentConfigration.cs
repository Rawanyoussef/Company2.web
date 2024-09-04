using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Contexts.Configrations
{
    public class DepartmentConfigration : IEntityTypeConfigration<Department>
    
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(10,10);
            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
