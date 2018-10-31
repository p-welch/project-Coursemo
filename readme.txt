Patrick Welch

Two parts:

CreateDBApp contains a program that will create a relational SQL database using a ‘Coursemo.sql’ file. 
This database is then populated by reading in data from two csv files: ‘courses.csv’ and ‘students.csv’

Welch9Project4App contains a program that uses a windows form app to allow a user to interface with this 
database with the ability to add courses to the enroll lists of students, to drop classes, to swap classes 
between two individuals, and to waitlist students. This form updates a sqlServer database created by the 
first app and can handle concurrent access.

