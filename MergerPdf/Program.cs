namespace MergePdf;

public class Program
{
    public static void Main(string[] args)
    {
        string outputfile = args[0];

        if (args.Length >= 2)
        {
            Console.WriteLine("début de la fusion des PDFs");
            string folderWithPdf = @"" + args[1];
            string[] files = (Directory.GetFiles(folderWithPdf)).Concat(Directory.GetDirectories(folderWithPdf)).ToArray();
            var pdfs = new List<string>();
            //Console.WriteLine("\nfolderWithPdf: " + folderWithPdf + "\n");
            foreach (string file in files)
            {
                pdfs = addPdfToList(file, pdfs);

            }
            //Console.WriteLine("\nFichier d'output: " + outputfile);
            var record = new PdfRecord(pdfs);
            
            record.Merged = outputfile;

            record.Merge();
            
            record.Out();
            Console.WriteLine("fin de la fusion des PDFs");
            System.Diagnostics.Process.Start("explorer.exe", folderWithPdf + "\\_MergedPdf\\");
        }
    }

    public static List<string> addPdfToList(string path, List<string> pdfs)
    {
        //Console.WriteLine(path);
        //Console.WriteLine(Directory.Exists(path));
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                //Console.WriteLine("its a directory");
                pdfs = addPdfToList(file, pdfs);
            }
        }
        else
        {
            if (path.EndsWith(".pdf"))
            {
                //Console.WriteLine("its a file");
                pdfs.Add(path);
            }
        }

        return pdfs;
    }
}