using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dkeshri.McpServer.Dto
{
    internal class PersonAgeDto
    {
        [Description("The calculated age of the person in whole years.")]
        public int Years { get; set; }
        [Description("The calculated age of the person in months.")]
        public int Months { get; set; }
        [Description("The calculated age of the person in days.")]
        public int Days { get; set; }
    }
}
