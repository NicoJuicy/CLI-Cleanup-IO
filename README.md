CLI-Cleanup-IO
==============

CLI for removing temp files and folders (eg. after converting html files to pdf for invoices)


Usage
=====

CleanupIO.exe -Folder="C:\MyApp\Logs" -Pattern="*.log" -Days="10" // Cleans up all log files older than 10 days
CleanupIO.exe -Folder="D:\MyApp\Devxpress\Source" -Pattern="licenses.licx" -EmptyContents -SubDir //Empty the contents of all licenses.licx files

If you want to use this in a recurring way, you can easily use this in the Task Scheduler, which is a standard tool in Windows. Execute the Task Scheduler with Taskschd.msc in the Start Menu - Run (Ctrl + R)

Arguments 
=====

* -Folder : Which folder needs to be iterated
* -Pattern: Delete which fileSearchPattern? (Eg. *.* = all, *.pdf = all pdf files)
* -Days: The minimal age of the file in days
* -Subdir: Searches through all directories, leaving this only deletes the matched files in the top directory
* -EmptyContents: Replace the value in those files with an empty string