
# Employment website

## Disclaimer
This project is built using MSSQL 2014 and Visual Studio 2019. An update from Microsoft Management Studio 2014 to 2019 might cause data migration errors. For your convenience, we have included a backup of the database. In case of any issues, please refer to the backup.

## How to Run
To run this project, you will need to install Visual Studio 2022 and MSSQL Management Studio 2019. Follow these steps:

1. Open Microsoft Management Studio.
2. Navigate to the "Database" folder.
3. Choose "Restore Database."
4. Select the option to restore from a backup.
5. Locate the backup file named `jobsDB.bak`.
6. Alternatively, you can run the following SQL command in a new query window:
   
   ```sql
   RESTORE DATABASE [YourDatabaseName] FROM DISK = 'PathToJobsDB.bak'

