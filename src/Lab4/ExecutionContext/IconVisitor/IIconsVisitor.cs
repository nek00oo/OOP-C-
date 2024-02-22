namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.IconVisitor;

public interface IIconsVisitor
{
    string VisitFolderIcon();
    string VisitFileIcon();
    string VisitNoAccessIcon();
}