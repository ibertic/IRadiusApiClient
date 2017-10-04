using System.Windows.Documents;
using System.Windows.Controls;
using Ibertic.Iradius.Api.Client;

namespace WpfIRadiusClient
{
    public  class Printing
    {

        private FlowDocument CreateFlowDocument(GenerateCredentialsResult Credentials)
        {
            // Create a FlowDocument
            FlowDocument doc = new FlowDocument();

            foreach (var c in Credentials.CredentialsResults)
                AddCredential(doc, c);
            return doc;
        }


        private void AddCredential(FlowDocument doc,  GenerateCredentialResult Credential)
        {
            var ff= new System.Windows.Media.FontFamily("Segoe UI, Verdana, Arial");
            // Create a Section
            Section sec = new Section();
            Paragraph p1 = new Paragraph();
            p1.FontFamily = ff;
            Span s = new Span(new Run("Usuario: "));
            p1.Inlines.Add(s);
            Bold bld = new Bold();
            bld.Inlines.Add(new Run(Credential.UserName));
            p1.Inlines.Add(bld);


            Paragraph p2 = new Paragraph();
            p2.FontFamily = ff;
            Span sp = new Span(new Run("Password: "));
            p2.Inlines.Add(sp);
            bld = new Bold();
            bld.Inlines.Add(new Run(Credential.Password));
            p2.Inlines.Add(bld);
            sec.Blocks.Add(p1);
            sec.Blocks.Add(p2);
            doc.Blocks.Add(sec);
        }



        public void PrintCredential(GenerateCredentialsResult Credentials)
        {
            //// Create a PrintDialog
            //PrintDialog printDlg = new PrintDialog();

            //// Create a FlowDocument dynamically.
            //FlowDocument doc = CreateFlowDocument(Credentials);
            //doc.Name = "FlowDoc";

            //// Create IDocumentPaginatorSource from FlowDocument
            //IDocumentPaginatorSource idpSource = doc;
            //// Call PrintDocument method to send document to printer
            ////printDlg.PrintVisual(idpSource.DocumentPaginator, "Hello WPF Printing.");
            //if (printDlg.ShowDialog() == true)
            //    printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");

            var w = new PrintPreview();
            foreach (var c in Credentials.CredentialsResults)
            {
                w.AddCredential(c);
            }
            w.Show();
        }
    }
}
