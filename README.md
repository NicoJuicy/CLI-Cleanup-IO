CLI-Cleanup-IO
==============

CLI for removing temp files and folders (eg. after converting html files to pdf for invoices)


Usage
=====

CleanupIO.exe -Folder="C:\GeneratedPDF" -Pattern="*.*" -Days="10"
If you want to run this daily, you can easily use this in the Task Executor, which is a standard tool in Windows

Arguments 
=====

-Folder : Which folder needs to be iterated
-Pattern: Delete which fileSearchPattern? (Eg. *.* = all, *.pdf = all pdf files)
-Days: How old must the file be
-Subdir: Searches through all directories (SearchOption.AllDirectories),  (default: SearchOption.TopDirectoryOnly)
