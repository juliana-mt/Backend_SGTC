using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Infra.Pdf
{
    public class CertificadoPdfGenerator
    {
        public byte[] Gerar(CertificadoDTO dto)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(40);
                    page.PageColor("#FFFFFF");

                    page.Header().AlignCenter().Column(col =>
                    {
                        col.Item().Text("CERTIFICADO DE CONCLUSÃO")
                            .FontSize(32).Bold().FontColor("#2c3e50");

                        col.Item().Text("Sistema de Gestão de Treinamentos Corporativos")
                            .FontSize(16).FontColor("#555");
                    });

                    page.Content().PaddingVertical(30).Column(col =>
                    {
                        col.Item().Text($"Certificamos que ")
                            .FontSize(18).FontColor("#444");

                        col.Item().Text(dto.NomeUsuario)
                            .FontSize(36).Bold().FontColor("#000").Underline();

                        col.Item().Text("concluiu com êxito o curso:")
                            .FontSize(18).FontColor("#444").PaddingTop(20);

                        col.Item().Text(dto.NomeCurso)
                            .FontSize(30).Bold().FontColor("#000");

                        col.Item().Text($"Carga horária: {dto.CargaHoraria} horas")
                            .FontSize(18).FontColor("#444").PaddingTop(20);

                        col.Item().Text($"Data de emissão: {dto.DataEmissao:dd/MM/yyyy}")
                            .FontSize(16).FontColor("#666").PaddingTop(10);

                        col.Item().PaddingTop(30).BorderBottom(1).BorderColor("#AAA");

                        col.Item().PaddingTop(20).AlignCenter().Text($"Código de validação: {dto.CodigoValidacao}")
                            .FontSize(14).FontColor("#777");
                    });

                    page.Footer().AlignCenter().Column(col =>
                    {
                        col.Item().Height(50).Image(Placeholders.Image(300, 60));
                        col.Item().Text("Assinatura Digital")
                            .FontSize(12).FontColor("#777");
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
