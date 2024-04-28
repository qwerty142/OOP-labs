using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CreateStringTree
{
    private string _folderSymbol;
    private string _fileSymbol;
    private char _indentation;

    public CreateStringTree(string folderSymbol, string fileSymbol, char indentation)
    {
        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
        _indentation = indentation;
    }

    public string CreateTree(Folder? folder, string result, int depth)
    {
        ArgumentNullException.ThrowIfNull(folder);
        ArgumentNullException.ThrowIfNull(result);
        result = result.PadRight(result.Length + depth, _indentation);
        result += folder.ShortName;
        result += _folderSymbol;
        result += '\n';
        depth += 3;
        foreach (IComponent comp in folder.In)
        {
            if (comp is Folder)
            {
                result += CreateTree(comp as Folder, string.Empty, depth);
            }
            else
            {
                result = result.PadRight(result.Length + depth, _indentation);
                result += comp.ShortName;
                result += _fileSymbol;
                result += '\n';
            }
        }

        return result;
    }
}