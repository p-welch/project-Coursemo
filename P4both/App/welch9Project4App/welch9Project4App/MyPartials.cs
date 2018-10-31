using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welch9Project4App
{

  public partial class Student
  {

    public override string ToString()
    {
      return string.Format(@"{0}, {1}: ({2})", this.LastName, this.FirstName, this.NetID);
      
    }

  }

  public partial class Course
  {

    public override string ToString()
    {
      return string.Format(@"{0} {1}: ({2})", this.Department, this.CourseNumber, this.CRN);

    }

  }

}
