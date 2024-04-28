using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeVisitor : ITreeVisitor
{
    public void VisitFolder(Folder folder, int depth)
    {
        if (depth <= 0)
        {
            return;
        }

        ArgumentNullException.ThrowIfNull(folder);
        var d = new DirectoryInfo(folder.Name);

        FileInfo[] files = Array.Empty<FileInfo>();

        try
        {
            files = d.GetFiles(".");
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        if (files.Length > 0)
        {
            foreach (FileInfo file in files)
            {
                VisitFile(new File(file.FullName, file.Name), folder);
            }
        }

        DirectoryInfo[] folders = d.GetDirectories();
        depth--;
        foreach (DirectoryInfo directory in folders)
        {
            var currentFolder = new Folder(directory.FullName, directory.Name);
            folder.AddComponent(currentFolder);
            VisitFolder(currentFolder, depth);
        }
    }

    public void VisitFile(File file, Folder currentFolder)
    {
        ArgumentNullException.ThrowIfNull(currentFolder);
        currentFolder.AddComponent(file);
    }
}