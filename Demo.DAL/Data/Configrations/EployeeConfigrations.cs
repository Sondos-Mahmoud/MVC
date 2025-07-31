using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configrations
{
   public class EployeeConfigrations:BaseEntityConfigrations<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.Gender).HasConversion((empGender) => empGender.ToString(),
                                           ( ReturnedEmpGender)=>(Gender)Enum.Parse(typeof(Gender), ReturnedEmpGender));


            builder.Property(E => E.EmployeeType).HasConversion((empType) => empType.ToString(),
                               (ReturnedEmpType) => (EmployeeType)Enum.Parse(typeof(Gender), ReturnedEmpType));

            base.Configure(builder);
        }


    }
}
