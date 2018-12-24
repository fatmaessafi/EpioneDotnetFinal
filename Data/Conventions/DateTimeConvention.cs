using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Conventions
{
    public class DateTimeConvention : Convention
    {   //Date
        public DateTimeConvention()
        {
            this.Properties<DateTime>().Configure(t => t.HasColumnType("DateTime2"));
        }
    }
}
