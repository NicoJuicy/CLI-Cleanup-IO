CLI-Cleanup-IO
==============

CLI for removing temp files and folders (eg. after converting to html to pdf for invoices)


Usage
=====

CleanupIO.exe -Folder="C:\GeneratedPDF" -Pattern="*.*" -Days="10"

Arguments 
=====

-Folder : Which folder needs to be iterated
-Pattern: Delete which fileSearchPattern? (Eg. *.* = all, *.pdf = all pdf files)
-Days: How old must the file be
-Subdir: Searches through all directories (SearchOption.AllDirectories),  (default: SearchOption.TopDirectoryOnly)
