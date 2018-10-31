
//
// Console app to create a database, e.g. Coursemo
//
// Patrick Welch
// U. of Illinois, Chicago
// CS480, Summer 2018
// Project #4
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDBApp
{
  class Program
  {

    static void Main(string[] args)
    {
      

      Console.WriteLine();
      Console.WriteLine("** Create Database Console App **");
      Console.WriteLine();

      //string baseDatabaseName = "BikeHike";

      string baseDatabaseName = "Coursemo";
      string sql;

      try
      {
        //
        // 1. Make a copy of empty MDF file to get us started:
        //
        Console.WriteLine("Copying empty database to {0}.mdf and {0}_log.ldf...", baseDatabaseName);

        CopyEmptyFile("__EmptyDB", baseDatabaseName);

        Console.WriteLine();

        //
        // 2. Now let's make sure we can connect to SQL Server on local machine:
        //
        DataAccessTier.Data data = new DataAccessTier.Data(baseDatabaseName + ".mdf");

        Console.Write("Testing access to database: ");

        if (data.TestConnection())
          Console.WriteLine("success");
        else
          Console.WriteLine("failure?!");

        Console.WriteLine();

        //
        // 3. Create tables by reading from .sql file and executing DDL queries:
        //
        Console.WriteLine("Creating tables by executing {0}.sql file...", baseDatabaseName);

        string[] lines = System.IO.File.ReadAllLines(baseDatabaseName + ".sql");

        sql = "";

        for (int i = 0; i < lines.Length; ++i)
        {
          string next = lines[i];

          if (next.Trim() == "")  // empty line, ignore...
          {
          }
          else if (next.Contains(";"))  // we have found the end of the query:
          {
            sql = sql + next + System.Environment.NewLine;

            Console.WriteLine("** Executing '{0}'...", sql.Substring(0, 32));

            data.ExecuteActionQuery(sql);

            sql = "";  // reset:
          }
          else  // add to existing query:
          {
              sql = sql + next + System.Environment.NewLine;
          }
        }

        Console.WriteLine();

        //
        // 4. Insert data by parsing data from .csv files:
        //
        Console.WriteLine("Inserting data...");

        //
        // 4 a. Inserting data: students
        //
        Console.WriteLine("**Insert student info...");

        using (var file = new System.IO.StreamReader("students.csv"))
        {
          while (!file.EndOfStream)
          {
            string line = file.ReadLine();
            string[] values = line.Split(',');
            string lastname = values[0];
            string firstname = values[1];
            string netid = values[2];

            //stupid o'connell
            lastname = lastname.Replace("'", "''");
            firstname = firstname.Replace("'", "''");
            
            string sqlq = string.Format(@"
      INSERT INTO Students(NetID, FirstName, Lastname) 
      Values('{0}', '{1}', '{2}');
      ", 
      netid, firstname, lastname);

            data.ExecuteActionQuery(sqlq);
          }
        }

        //
        // 4 b. Inserting data: courses
        //
        Console.WriteLine("**Insert course info...");

        using (var file = new System.IO.StreamReader("courses.csv"))
         {
          while (!file.EndOfStream)
          {
            string line = file.ReadLine();
            string[] values = line.Split(',');

            string dept = values[0];
            int number = Convert.ToInt32(values[1]);
            string semester = values[2];
            int year = Convert.ToInt32(values[3]);
            int crn = Convert.ToInt32(values[4]);
            string type = values[5];
            string days = values[6];
            string time = values[7];
            int size = Convert.ToInt32(values[8]); 


            string sqlq = string.Format(@"
INSERT INTO Courses(CRN, Department, CourseNumber, Type, ClassSize, Days, ClassTime, Semester, Year)
Values({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}', '{7}', {8});
", crn, dept, number, type, size, days, time, semester, year);

            data.ExecuteActionQuery(sqlq);
          }
         }

        

        //
        // Done
        //
      }
      catch (Exception ex)
      {
        Console.WriteLine("**Exception: '{0}'", ex.Message);
      }

      Console.WriteLine();
      Console.WriteLine("** Done **");
      Console.WriteLine();
    }//Main


    /// <summary>
    /// Makes a copy of an existing Microsoft SQL Server database file 
    /// and log file.  Throws an exception if an error occurs, otherwise
    /// returns normally upon successful copying.  Assumes files are in
    /// sub-folder bin\Debug or bin\Release --- i.e. same folder as .exe.
    /// </summary>
    /// <param name="basenameFrom">base file name to copy from</param>
    /// <param name="basenameTo">base file name to copy to</param>
    static void CopyEmptyFile(string basenameFrom, string basenameTo)
    {
      string from_file, to_file;

      //
      // copy .mdf:
      //
      from_file = basenameFrom + ".mdf";
      to_file = basenameTo + ".mdf";

      if (System.IO.File.Exists(to_file))
      {
        System.IO.File.Delete(to_file);
      }

      System.IO.File.Copy(from_file, to_file);

      // 
      // now copy .ldf:
      //
      from_file = basenameFrom + "_log.ldf";
      to_file = basenameTo + "_log.ldf";

      if (System.IO.File.Exists(to_file))
      {
        System.IO.File.Delete(to_file);
      }

      System.IO.File.Copy(from_file, to_file);
    }

  }//class
}//namespace

