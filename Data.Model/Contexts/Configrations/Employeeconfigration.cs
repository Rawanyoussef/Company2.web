using Company.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Contexts.Configrations
{
    public class Employeeconfigration :IEntityTypeConfigration<Employee>
    {
        public  void Configure (EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);

        }
    }
}
