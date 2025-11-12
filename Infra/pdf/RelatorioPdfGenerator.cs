using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TreinamentosCorp.API.DTOs.Responses;

public class RelatorioPdfGenerator
{
    public byte[] GerarUsuario(IEnumerable<RelatorioUsuarioDTO> relatorios)
    {
        var lista = relatorios.ToList();
        if (!lista.Any())
            return Array.Empty<byte>();

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(12));

                // Cabeçalho
                page.Header().Column(col =>
                {
                    col.Item().Text("Relatório — Usuário").FontSize(20).Bold();
                    col.Item().Text($"Nome: {lista.First().NomeUsuario}").FontSize(14);
                    col.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(10).FontColor(Colors.Grey.Darken1);
                });

                // Conteúdo (Tabela)
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1); 
                        columns.RelativeColumn(1); 
                    });

                    // Cabeçalho da tabela
                    table.Header(header =>
                    {
                        header.Cell().Text("Curso").Bold();
                        header.Cell().Text("Nota").Bold();
                        header.Cell().Text("Concluído").Bold();
                        header.Cell().Text("Conclusão").Bold();
                    });

                    // Linhas
                    foreach (var r in lista)
                    {
                        table.Cell().Text(r.Curso);
                        table.Cell().Text($"{r.Nota:N2}");
                        table.Cell().Text(r.Concluido ? "Sim" : "Não");
                        table.Cell().Text(r.DataConclusao.ToString("dd/MM/yyyy"));
                    }
                });

                // Rodapé
                page.Footer().AlignCenter().Text("TreinamentosCorp — Relatório Gerado Automaticamente");
            });
        }).GeneratePdf();
    }

    public byte[] GerarCurso(IEnumerable<RelatorioCursoDTO> relatorios)
    {
        var lista = relatorios.ToList();
        if (!lista.Any())
            return Array.Empty<byte>();

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(12));

                var curso = lista.First();

                // Cabeçalho
                page.Header().Column(col =>
                {
                    col.Item().Text("Relatório — Curso").FontSize(20).Bold();
                    col.Item().Text($"Curso: {curso.NomeCurso}").FontSize(14);
                    col.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(10).FontColor(Colors.Grey.Darken1);
                });

                // Conteúdo (Informações gerais)
                page.Content().Column(col =>
                {
                    col.Item().Text($"• Total de alunos: {curso.TotalAlunos}");
                    col.Item().Text($"• Concluintes: {curso.Concluintes}");
                    col.Item().Text($"• Nota Média: {curso.NotaMedia:N2}");

                    col.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Darken2);

                    col.Item().Text("Observações:")
                        .FontSize(14).Bold();

                    col.Item().Text("Este relatório contém as informações gerais do curso, permitindo acompanhamento do desempenho dos alunos.");
                });

                // Rodapé
                page.Footer().AlignCenter().Text("TreinamentosCorp — Relatório Gerado Automaticamente");
            });
        }).GeneratePdf();
    }
}
