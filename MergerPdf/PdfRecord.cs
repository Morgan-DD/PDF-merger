
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MergePdf;

public class PdfRecord
{
    private List<string> _pdfs;

    public string Merged { get; set; }

    public PdfRecord(List<string> pdfs)
    {
        _pdfs = pdfs;
    }

    public void Merge()
    {
        var outPdf = new PdfDocument();

        foreach(string pdf in _pdfs)
        {
            var currentpdf = PdfReader.Open(pdf, PdfDocumentOpenMode.Import);

            Merge(outPdf, currentpdf);
        }

        outPdf.Save(Merged);
    }

    public void Merge(PdfDocument pdfout, PdfDocument pdfin)
    {
        for (int i = 0; i < pdfin.PageCount; i++)
        {
            pdfout.AddPage(pdfin.Pages[i]);
        }
    }

    public void Out()
    {
        //Console.WriteLine($"File merged {Merged}");
    }
}