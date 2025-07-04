using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020.DomainCode
{
    internal class CodeTesting
    {
        // This is a class used solely for testing pieces of code within the 
        // solution
public void CreateScatterPlot(WebBrowser wb, double[,] xvalues, double[,] yvalues)
    {
        // Validate input arrays
        if (xvalues == null || yvalues == null)
            throw new ArgumentException("X and Y value arrays cannot be null");

        if (xvalues.GetLength(0) != 8 || yvalues.GetLength(0) != 8)
            throw new ArgumentException("Arrays must have 8 lines (20% through 90%)");

        // Generate HTML content with embedded Chart.js
        string htmlContent = GenerateHtmlContent(xvalues, yvalues);

        // Load the HTML into the WebBrowser
        wb.DocumentText = htmlContent;
    }

    private string GenerateHtmlContent(double[,] xvalues, double[,] yvalues)
    {
        StringBuilder html = new StringBuilder();

        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html>");
        html.AppendLine("<head>");
        html.AppendLine("    <title>Scatter Plot</title>");
        html.AppendLine("    <script src='https://cdn.jsdelivr.net/npm/chart.js'></script>");
        html.AppendLine("    <style>");
        html.AppendLine("        body { margin: 20px; font-family: Arial, sans-serif; }");
        html.AppendLine("        #chartContainer { width: 100%; height: 600px; }");
        html.AppendLine("    </style>");
        html.AppendLine("</head>");
        html.AppendLine("<body>");
        html.AppendLine("    <div id='chartContainer'>");
        html.AppendLine("        <canvas id='scatterChart'></canvas>");
        html.AppendLine("    </div>");
        html.AppendLine("    <script>");

        // Generate JavaScript data
        html.AppendLine("        const ctx = document.getElementById('scatterChart').getContext('2d');");
        html.AppendLine("        const data = {");
        html.AppendLine("            datasets: [");

        // Define colors for each line
        string[] colors = {
        "rgb(255, 99, 132)",   // 20% - Red
        "rgb(54, 162, 235)",   // 30% - Blue
        "rgb(255, 205, 86)",   // 40% - Yellow
        "rgb(75, 192, 192)",   // 50% - Teal
        "rgb(153, 102, 255)",  // 60% - Purple
        "rgb(255, 159, 64)",   // 70% - Orange
        "rgb(199, 199, 199)",  // 80% - Grey
        "rgb(83, 102, 147)"    // 90% - Dark Blue
    };

        string[] percentages = { "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%" };

        // Generate datasets for each line
        for (int i = 0; i < 8; i++)
        {
            html.AppendLine($"                {{");
            html.AppendLine($"                    label: '{percentages[i]}',");
            html.AppendLine($"                    data: [");

            // Get the number of points for this line
            int pointCount = yvalues.GetLength(1);

            // Generate data points for this line
            for (int j = 0; j < pointCount; j++)
            {
                double x = xvalues[i, j];
                double y = yvalues[i, j];
                html.Append($"                        {{x: {x:F2}, y: {y:F3}}}");
                if (j < pointCount - 1) html.Append(",");
                html.AppendLine();
            }

            html.AppendLine($"                    ],");
            html.AppendLine($"                    borderColor: '{colors[i]}',");
            html.AppendLine($"                    backgroundColor: '{colors[i]}',");
            html.AppendLine($"                    showLine: true,");
            html.AppendLine($"                    fill: false,");
            html.AppendLine($"                    pointRadius: 4,");
            html.AppendLine($"                    pointHoverRadius: 6,");
            html.AppendLine($"                    tension: 0.1");
            html.Append($"                }}");
            if (i < 7) html.Append(",");
            html.AppendLine();
        }

        html.AppendLine("            ]");
        html.AppendLine("        };");

        // Chart configuration
        html.AppendLine("        const config = {");
        html.AppendLine("            type: 'scatter',");
        html.AppendLine("            data: data,");
        html.AppendLine("            options: {");
        html.AppendLine("                responsive: true,");
        html.AppendLine("                maintainAspectRatio: false,");
        html.AppendLine("                plugins: {");
        html.AppendLine("                    title: {");
        html.AppendLine("                        display: true,");
        html.AppendLine("                        text: 'Use Rate vs Runoff Volume'");
        html.AppendLine("                    },");
        html.AppendLine("                    legend: {");
        html.AppendLine("                        display: true,");
        html.AppendLine("                        position: 'right'");
        html.AppendLine("                    }");
        html.AppendLine("                },");
        html.AppendLine("                scales: {");
        html.AppendLine("                    x: {");
        html.AppendLine("                        type: 'linear',");
        html.AppendLine("                        position: 'bottom',");
        html.AppendLine("                        title: {");
        html.AppendLine("                            display: true,");
        html.AppendLine("                            text: 'Runoff Volume of Water (inches over EIA)'");
        html.AppendLine("                        },");
        html.AppendLine("                        min: 0,");
        html.AppendLine("                        max: 6,");
        html.AppendLine("                        ticks: {");
        html.AppendLine("                            stepSize: 1");
        html.AppendLine("                        }");
        html.AppendLine("                    },");
        html.AppendLine("                    y: {");
        html.AppendLine("                        title: {");
        html.AppendLine("                            display: true,");
        html.AppendLine("                            text: 'Use Rate (inches/day over EIA)'");
        html.AppendLine("                        },");
        html.AppendLine("                        min: 0,");
        html.AppendLine("                        max: 0.5,");
        html.AppendLine("                        ticks: {");
        html.AppendLine("                            stepSize: 0.1");
        html.AppendLine("                        }");
        html.AppendLine("                    }");
        html.AppendLine("                }");
        html.AppendLine("            }");
        html.AppendLine("        };");

        html.AppendLine("        const chart = new Chart(ctx, config);");
        html.AppendLine("    </script>");
        html.AppendLine("</body>");
        html.AppendLine("</html>");

        return html.ToString();
    }

    // Example usage method
    public void ExampleUsage()
    {
        // Example data - replace with your actual data
        double[,] xvalues = new double[8, 5]; // 8 lines, 5 points each
        double[,] yvalues = new double[8, 5]; // 8 lines, 5 points each

        // Fill with sample data (replace with your actual data)
        Random rand = new Random();
        for (int line = 0; line < 8; line++)
        {
            for (int point = 0; point < 5; point++)
            {
                xvalues[line, point] = point * 1.5; // X values 0 to 6
                yvalues[line, point] = (line + 1) * 0.05 + rand.NextDouble() * 0.1; // Y values with some variation
            }
        }

        // Assuming 'wb' is your WebBrowser control instance
        // CreateScatterPlot(wb, xvalues, yvalues);
    }

}
}
