using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// Multi-user Coursemo application for UIC course registrations.
//
// Patrick Welch
// U. of Illinois, Chicago
// CS480, Summer 2018
// Project #4
//

namespace welch9Project4App
{

  public partial class Form1 : Form
  {

    int timeInMs;

    //private CoursemoDataContext db;
    public Form1()
    {
      InitializeComponent();
      
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //Create Linq to SQL context object
      //db = new CoursemoDataContext();
      timeInMs = 0;
      ListStudentsButton_Click(sender, e);
      ListCoursesButton_Click(sender, e);
    }

    private void ListStudentsButton_Click(object sender, EventArgs e)
    {


      this.StudentListBox.Items.Clear();
      this.StudentListBox.Refresh();



      this.StudentTwoList.Items.Clear();
      this.StudentTwoList.Refresh();

      this.StudentDetailsListbox.Items.Clear();
      this.StudentDetailsListbox.Refresh();

      try
      {
        using (var db = new CoursemoDataContext())
        {
          var query = from s in db.Students
                      orderby s.LastName, s.LastName, s.NetID
                      select s;
          foreach (Student s in query)
          {
            this.StudentListBox.Items.Add(s);
            this.StudentTwoList.Items.Add(s);
          }

          
        }

      }

      catch
      {
        MessageBox.Show("Error in retreiving students");
      }






    }

    private void StudentListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.StudentDetailsListbox.Items.Clear();
      this.StudentDetailsListbox.Refresh();

      Student student = (Student)StudentListBox.SelectedItem;
      try
      {
        using (var db = new CoursemoDataContext())
        {
          var queryEnroll = from en in db.Enrolleds
                            orderby en.CRN
                            where en.NetID == student.NetID && en.Active == true
                            select en;
          var queryWait = from w in db.Waitlists
                          orderby w.CRN
                          where w.NetID == student.NetID && w.Active == true
                          select w;

          this.StudentDetailsListbox.Items.Add("Courses Enrolled: ");
          foreach (Enrolled en in queryEnroll)
          {
            this.StudentDetailsListbox.Items.Add(" " + en.CRN);
          }
          this.StudentDetailsListbox.Items.Add(" ");
          this.StudentDetailsListbox.Items.Add("Courses Waitlisted: ");
          foreach (Waitlist w in queryWait)
          {
            this.StudentDetailsListbox.Items.Add(" " + w.CRN);
          }
          //MessageBox.Show("end");
        }//using

      }

      catch
      {
        MessageBox.Show("Error in retreiving student details");
      }


    }

    private void ListCoursesButton_Click(object sender, EventArgs e)
    {
      this.CourseListBox.Items.Clear();
      this.CourseListBox.Refresh();

      this.CourseTwoList.Items.Clear();
      this.CourseTwoList.Refresh();

      this.CourseDetailsListBox.Items.Clear();
      this.CourseDetailsListBox.Refresh();

      try
      {
        using (var db = new CoursemoDataContext())
        {
          var query = from c in db.Courses
                      orderby c.Department, c.CourseNumber ascending, c.CRN
                      select c;

          foreach (Course c in query)
          {
            this.CourseListBox.Items.Add(c);
            this.CourseTwoList.Items.Add(c);

          }
        }
          
      }

      catch
      {
        MessageBox.Show("Error in retreiving Courses");
      }


    }

    private void resetTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {

      try
      {
        using (var db = new CoursemoDataContext())
        {
          var TxOptions = new System.Transactions.TransactionOptions();
          TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var Tx = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, TxOptions))
          {

            var query = from en in db.Enrolleds
                        select en;

            foreach (Enrolled en in query)
            {
              db.Enrolleds.DeleteOnSubmit(en);
            }

            //db.Enrolleds.DeleteAllOnSubmit(query);

            var query2 = from w in db.Waitlists
                         select w;

            foreach (Waitlist w in query2)
            {
              db.Waitlists.DeleteOnSubmit(w);
            }
            //db.Waitlists.DeleteAllOnSubmit(query2);

            db.SubmitChanges();

            Tx.Complete();
            
          }//Using tx
        }//Using db

        MessageBox.Show("Deletes successful");
      }

      catch (Exception ex)
      {
        MessageBox.Show("Delete failed + " + ex.Message);
      }
      finally
      {
        StudentListBox_SelectedIndexChanged(sender, e);
        CourseListBox_SelectedIndexChanged(sender, e);
      }
      
    }

    private void EnrollButton_Click(object sender, EventArgs e)
    {
      Student student = (Student)this.StudentListBox.SelectedItem;
      Course course = (Course)this.CourseListBox.SelectedItem;

      

      try
      {
        using (var db = new CoursemoDataContext())
        {
          var TxOptions = new System.Transactions.TransactionOptions();
          TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var Tx = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, TxOptions))
          {



            var queryEnroll = from en in db.Enrolleds
                        where en.CRN == course.CRN && en.Active == true
                        select en;


            System.Threading.Thread.Sleep(timeInMs);
            //int count = 0;
            bool studentFound = false;
            int priorityKey = 0;

            foreach(Enrolled en in queryEnroll)
            {
              //count++;
              if (en.NetID == student.NetID)
              {
                studentFound = true;
              }
              priorityKey = en.Priority;
            }

            if (studentFound)
            {
              MessageBox.Show("Student is already enrolled");
              return;
            }

            //else, check numbers
            if (queryEnroll.Count() < course.ClassSize)
            {
              //can be enrolled
              priorityKey++;
              Enrolled enroll = new Enrolled();
              //enroll.Priority = priorityKey;
              enroll.CRN = course.CRN;
              enroll.NetID = student.NetID;
              enroll.Active = true;

              db.Enrolleds.InsertOnSubmit(enroll);
              db.SubmitChanges();
              Tx.Complete();
              MessageBox.Show("Enrolled: " + enroll.NetID + " into " + enroll.CRN);

              //return;
            }

            else
            {
              //class full, go to wait list
              var queryWait = from w in db.Waitlists
                              where w.CRN == course.CRN && w.Active == true && w.NetID == student.NetID
                              select w;

              //if already on waitlist
              if (queryWait.Any())
              {
                MessageBox.Show("Already on waitlist");
                return;
              }
              //Adding to waitlist
              else
              {
                foreach (Waitlist w in queryWait)
                {
                  w.Priority = priorityKey; 
                }
                priorityKey++;

                Waitlist wait = new Waitlist();
                //wait.Priority = priorityKey;
                wait.CRN = course.CRN;
                wait.NetID = student.NetID;
                wait.Active = true;

                db.Waitlists.InsertOnSubmit(wait);

                db.SubmitChanges();
                Tx.Complete();
                MessageBox.Show("Adding to waitlist:  " + wait.NetID + " for " + wait.CRN);

              }

            }//end else




            //MessageBox.Show("Should not reach here...");

            //db.SubmitChanges();

            //Tx.Complete();

          }//Using tx
        }//Using db


      }

      catch (Exception ex)
      {
        MessageBox.Show("Enroll failed: " + ex.Message);
      }

      finally
      {
        StudentListBox_SelectedIndexChanged(sender, e);
        CourseListBox_SelectedIndexChanged(sender, e);
        //course list
      }

    }//end enroll button

    private void StudentDetailsListbox_SelectedIndexChanged(object sender, EventArgs e)
    {
      

    }

    private void CourseListBox_SelectedIndexChanged(object sender, EventArgs e)
    {


      this.CourseDetailsListBox.Items.Clear();
      this.CourseDetailsListBox.Refresh();

      Course course = (Course)CourseListBox.SelectedItem;
      try
      {
        using (var db = new CoursemoDataContext())
        {
          var queryEnroll = from en in db.Enrolleds
                            orderby en.CRN
                            where en.CRN == course.CRN && en.Active == true
                            select en;
          var queryWait = from w in db.Waitlists
                          orderby w.CRN
                          where w.CRN == course.CRN && w.Active == true
                          select w;

          this.CourseDetailsListBox.Items.Add("Course Info: ");
          this.CourseDetailsListBox.Items.Add(course.CRN + ": " + course.Department);
          this.CourseDetailsListBox.Items.Add(course.Semester + " " + course.Year);
          this.CourseDetailsListBox.Items.Add(course.Type + ": " + course.ClassTime);
          this.CourseDetailsListBox.Items.Add("Class size:" + course.ClassSize);

          this.CourseDetailsListBox.Items.Add("Enrolled: " + queryEnroll.Count());

          foreach (Enrolled en in queryEnroll)
          {
            this.CourseDetailsListBox.Items.Add(" " + en.NetID);
          }

          this.CourseDetailsListBox.Items.Add("Waitlisted:  " + queryWait.Count());
          foreach (Waitlist w in queryWait)
          {
            this.CourseDetailsListBox.Items.Add(" " + w.NetID);
          }
          //MessageBox.Show("end");
        }//using

      }

      catch
      {
        MessageBox.Show("Error in retreiving course details details");
      }

    }

    private void DropButton_Click(object sender, EventArgs e)
    {
      Student student = (Student)this.StudentListBox.SelectedItem;
      Course course = (Course)this.CourseListBox.SelectedItem;



      try
      {
        using (var db = new CoursemoDataContext())
        {
          var TxOptions = new System.Transactions.TransactionOptions();
          TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var Tx = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, TxOptions))
          {


            var queryEnroll = from en in db.Enrolleds
                              where en.CRN == course.CRN && en.NetID == student.NetID && en.Active == true
                              select en;

            System.Threading.Thread.Sleep(timeInMs);
            //if found to be enrolled
            if (queryEnroll.Any())
            {
              foreach(Enrolled en in queryEnroll)
              {
                en.Active = false;
              }

              //next, put waitlist individual in class
              Waitlist temp;

              var queryWait = from w in db.Waitlists
                              where w.CRN == course.CRN && w.Active == true
                              select w;
              temp = queryWait.First();

              Enrolled enroll = new Enrolled();
              enroll.CRN = course.CRN;
              enroll.NetID = temp.NetID;
              enroll.Active = true;

              db.Enrolleds.InsertOnSubmit(enroll);

              queryWait.First().Active = false;
        
              db.SubmitChanges();
              Tx.Complete();
              MessageBox.Show("Dropped: " + student.NetID + " from " + course.CRN);

            }//end to be enrolled block

            //else drop from waitlist
            else
            {
              var queryWait = from w in db.Waitlists
                              where w.CRN == course.CRN && w.NetID == student.NetID && w.Active == true
                              select w;

              if (queryWait.Any())
              {
                foreach (Waitlist w in queryWait)
                {
                  w.Active = false;
                }
                db.SubmitChanges();
                Tx.Complete();
                MessageBox.Show("Dropped: " + student.NetID + " from waitlist for " + course.CRN);
              }
              else
              {
                MessageBox.Show("Invalid, student not enrolled in class nor on waitlist");
              }
              
            }

            //MessageBox.Show("Should not reach here...");

            //db.SubmitChanges();

            //Tx.Complete();

          }//Using tx
        }//Using db


      }

      catch (Exception ex)
      {
        MessageBox.Show("Enroll failed: " + ex.Message);
      }

      finally
      {
        StudentListBox_SelectedIndexChanged(sender, e);
        CourseListBox_SelectedIndexChanged(sender, e);
        //course list
      }
    }

    private void SwapButton_Click(object sender, EventArgs e)
    {

      try
      {
        Student studentOne = (Student)this.StudentListBox.SelectedItem;
        Course courseOne = (Course)this.CourseListBox.SelectedItem;
        
        Student studentTwo = (Student)this.StudentTwoList.SelectedItem;
        Course courseTwo = (Course)this.CourseTwoList.SelectedItem;



        using (var db = new CoursemoDataContext())
        {
          var TxOptions = new System.Transactions.TransactionOptions();
          TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

          using (var Tx = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, TxOptions))
          {

            var queryOne = from en in db.Enrolleds
                              where en.CRN == courseOne.CRN && en.NetID == studentOne.NetID && en.Active == true
                              select en;

            System.Threading.Thread.Sleep(timeInMs);

            //if found to be enrolled
            if (!queryOne.Any())
            {
              MessageBox.Show("Student: " + studentOne.NetID + "is not enrolled in this class");
              return;
            }

            var queryTwo = from en in db.Enrolleds
                           where en.CRN == courseTwo.CRN && en.NetID == studentTwo.NetID && en.Active == true
                           select en;

            if (!queryTwo.Any())
            {
              MessageBox.Show("Student: " + studentTwo.NetID + "is not enrolled in this class");
              return;
            }

            //else, both are enrolled in their selected class, proceed to swap
            foreach(Enrolled en in queryOne)
            {
              en.CRN = courseTwo.CRN;
            }

            foreach (Enrolled en in queryTwo)
            {
              en.CRN = courseOne.CRN;
            }

            db.SubmitChanges();
            Tx.Complete();


            MessageBox.Show("Two students successfully swapped");

          }//Using tx
        }//Using db




      }

      catch (Exception ex)
      {
        MessageBox.Show("Swap failed: " + ex.Message);
      }

      finally
      {
        StudentListBox_SelectedIndexChanged(sender, e);
        CourseListBox_SelectedIndexChanged(sender, e);
      }


      
    }

    private void StudentTwoList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.StudentTwoDetails.Items.Clear();
      this.StudentTwoDetails.Refresh();

      Student student = (Student)StudentTwoList.SelectedItem;
      try
      {
        using (var db = new CoursemoDataContext())
        {
          var queryEnroll = from en in db.Enrolleds
                            orderby en.CRN
                            where en.NetID == student.NetID && en.Active == true
                            select en;
          var queryWait = from w in db.Waitlists
                          orderby w.CRN
                          where w.NetID == student.NetID && w.Active == true
                          select w;

          this.StudentTwoDetails.Items.Add("Courses Enrolled: ");
          foreach (Enrolled en in queryEnroll)
          {
            this.StudentTwoDetails.Items.Add(" " + en.CRN);
          }
          this.StudentTwoDetails.Items.Add(" ");
          this.StudentTwoDetails.Items.Add("Courses Waitlisted: ");
          foreach (Waitlist w in queryWait)
          {
            this.StudentTwoDetails.Items.Add(" " + w.CRN);
          }
          //MessageBox.Show("end");
        }//using

      }

      catch
      {
        MessageBox.Show("Error in retreiving student details");
      }


    }

    private void CourseTwoList_SelectedIndexChanged(object sender, EventArgs e)
    {


      this.CourseTwoDetails.Items.Clear();
      this.CourseTwoDetails.Refresh();

      Course course = (Course)CourseTwoList.SelectedItem;
      try
      {
        using (var db = new CoursemoDataContext())
        {
          var queryEnroll = from en in db.Enrolleds
                            orderby en.CRN
                            where en.CRN == course.CRN && en.Active == true
                            select en;
          var queryWait = from w in db.Waitlists
                          orderby w.CRN
                          where w.CRN == course.CRN && w.Active == true
                          select w;

          this.CourseTwoDetails.Items.Add("Course Info: ");
          this.CourseTwoDetails.Items.Add(course.CRN + ": " + course.Department);
          this.CourseTwoDetails.Items.Add(course.Semester + " " + course.Year);
          this.CourseTwoDetails.Items.Add(course.Type + ": " + course.ClassTime);
          this.CourseTwoDetails.Items.Add("Class size:" + course.ClassSize);

          this.CourseTwoDetails.Items.Add("Enrolled: " + queryEnroll.Count());

          foreach (Enrolled en in queryEnroll)
          {
            this.CourseTwoDetails.Items.Add(" " + en.NetID);
          }

          this.CourseTwoDetails.Items.Add("Waitlisted:  " + queryWait.Count());
          foreach (Waitlist w in queryWait)
          {
            this.CourseTwoDetails.Items.Add(" " + w.NetID);
          }
          //MessageBox.Show("end");
        }//using

      }

      catch
      {
        MessageBox.Show("Error in retreiving course details details");
      }

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (Int32.TryParse(this.TimeDelayBox.Text, out timeInMs) == true) ;
      else
        timeInMs = 0;
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }//end form
}
