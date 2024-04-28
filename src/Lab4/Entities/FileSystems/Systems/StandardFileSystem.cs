using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Systems;

public class StandardFileSystem : IFileSystem
{
    private string _rootPath = string.Empty;
    public bool CheckPathOnExist(string path)
    {
        string fullPath = Path.GetFullPath(Path.Combine(_rootPath, path) + Path.DirectorySeparatorChar);
        if (!fullPath.StartsWith(_rootPath, StringComparison.CurrentCulture))
        {
            return false;
        }

        return true;
    }

    public bool Connect(string path)
    {
        // по поводу перехода с диска C на D это реализуется как
        // connect C ->
        // disconnect C ->
        // connect D
        if (CheckPathOnExist(path))
        {
            _rootPath = path;
            return true;
        }

        return false;
    }

    public string Disconnect()
    {
        _rootPath = string.Empty;
        return "Disconnected";
    }

    public bool FileCopy(string start, string destination)
    {
        if (!CheckPathOnExist(start) || !CheckPathOnExist(destination))
        {
            throw new NotExistingPathException();
        }

        System.IO.File.Copy(start, destination);
        return true;
    }

    public bool FileDelete(string path)
    {
        if (!CheckPathOnExist(path))
        {
            throw new NotExistingPathException();
        }

        System.IO.File.Delete(path);
        return true;
    }

    public bool FileMove(string start, string destination)
    {
        if (!CheckPathOnExist(start) || !CheckPathOnExist(destination))
        {
            throw new NotExistingPathException();
        }

        System.IO.File.Move(start, destination);
        return true;
    }

    public bool FileRename(string path, string name)
    {
        if (!CheckPathOnExist(path))
        {
            throw new NotExistingPathException();
        }

        System.IO.File.Move(
            path,
            Path.Combine(
                Directory.
                GetParent(path)?
                .FullName ?? string.Empty,
                name));
        return true;
    }

    [SuppressMessage("", "CA1307", Justification = "d")]
    public string FileShow(string path)
    {
        if (!CheckPathOnExist(path))
        {
            throw new NotExistingPathException();
        }

        string text = System.IO.File.ReadAllText(path);
        return text.Substring(text.IndexOf('\n') + 1); // не учитывая заголовок
    }

    public void ChangePath(string newPath, IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        if (CheckPathOnExist(newPath))
        {
            context.Path = newPath;
        }
        else
        {
            throw new NotExistingPathException();
        }
    }
}