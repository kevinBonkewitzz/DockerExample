using IronPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AgencyDownload()
        {
            // Inserts the HTML content (from form) into the HTML template
            var htmlContent = Template("#000000", "#ffffff").Replace("{{HtmlContent}}", "<h1>Testing Content</h1>");

            var Renderer = new ChromePdfRenderer();
            Renderer.RenderingOptions.Title = "Agency Report - for " + DateTime.Now.ToString("d MMMM yyyy");
            Renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;

            var content = await Renderer.RenderHtmlAsPdfAsync(htmlContent);

            // Return the PDF to the browser
            return new FileContentResult(content.BinaryData, "application/pdf") { FileDownloadName = "google.pdf" };
        }

        private static string Template(string primaryColor, string primaryTextColor)
        {
            string template = @"<!DOCTYPE html>
                <html class='p-report'>
                    <head>
                        <style>
                            html.p-report {
                                font-family: 'Arial'
                            }

                            div {
                                font-size: 13px;
                            }

                            .grid {
                                display: grid;
                            }

                            .grid-cols-12 {
                                grid-template-columns: repeat(12, minmax(0, 1fr));
                            }

                            .col-span-1 {
                                grid-column: span 1 / span 1;
                            }

                            .col-span-2 {
                                grid-column: span 2 / span 2;
                            }

                            .col-span-10 {
                                grid-column: span 10 / span 10;
                            }

                            .col-span-11 {
                                grid-column: span 11 / span 11;
                            }

                            .w-7cm {
                                width: 11cm;
                            }

                            .w-full {
                                width: 100%;
                            }

                            .w-1/2 {
                                width: 50%;
                            }

                            .w-2/12 {
                                width: 16.666667%;
                            }

                            .w-3/4 {
                                width: 75%;
                            }

                            .w-1/4 {
                                width: 25%;
                            }

                            .w-1cm {
                                width: 2.5cm !important;
                            }
                            .py-2 {
                                padding-top: 0.5rem;
                                padding-bottom: 0.5rem;
                            }

                            table {
                                text-indent: 0;
                                border-collapse: collapse;
                                font-size: 13px;
                            }
    
                            .text-right {
                                text-align: right;
                            }

                            .relative {
                                position: relative;
                            }

                            .absolute {
                               position: absolute;
                            }

                            .mb-8 {
                                margin-bottom: 2rem;
                            }

                            .text-sm {
                                font-size: 0.875rem;
                            }
                            
                            .break-word {
                                word-break: break-word;
                            }

                            .p-0 {
                                padding: 0px;
                            }

                            .addresees {
                                font-size: 13px;
                            }

                            .mb-4 {
                                margin-bottom: 1rem;
                            }

                            .float-left {
                                float: left;
                            }

                            .float-right {
                                float: right;
                            }

                            .clear-both {
                                clear: both;
                            }
                            
                            .p-1 {
                                padding: 0.25rem;
                            }

                            .px-1 {
                                padding-left: 0.25rem;
                                padding-right: 0.25rem;
                            }

                            .px-2 {
                                padding-left: 0.5rem;
                                padding-right: 0.5rem;
                            }

                            .z-0 {
                                z-index: 0;
                            }

                            .z-10 {
                                z-index: 10;
                            }

                            .block {
                                display: block;
                            }

                            .hidden {
                                display: none;
                            }

                            .text-vertical {
                                left: 0;
                                top: 50%;
                                transform: translateY(-50%);
                                width: 100%;
                                transform: rotate(-90deg);

                                font-size: 15px;
                            }

                            .m-auto {
                                margin: auto;
                            }

                            .grid {
                                display: grid;
                            }

                            .items-center {
                                align-items: center;
                            }

                            .flex {
                                display: flex;
                            }

                            .items-center { 
                                align-items: center;
                            }

                            .table {
                                display: table;
                            }

                            .table-cell {
                                display: table-cell;
                            }

                            .-rotate-90 {
                                transform: rotate(270deg);
                            }

                            .block {
                                display: block;
                            }
                            .mb-1 {
                                margin-bottom: 0.25rem;
                            }

                            .leading-snug {
                                line-height: 1.375;
                            }

                            .text-left {
                                text-align: left;
                            }

                            .text-center {
                                text-align: center;
                            }

                            tr, .avoid-break {
                                page-break-inside: avoid;
                            }

                            .border-t-1 {
                                border-top-style: solid;
                                border-top-width: 1px;
                            }

                            .border-b-1 {
                                border-bottom-style: solid;
                                border-bottom-width: 1px;
                            }


                            .border-primary-400 {
                                border-color: rgba(179, 179, 179, 1);
                            }

                            .instruction-block {
                                font-size: 12px;
                            }

                            .bg-primary-300 {
                                background-color: rgba(204, 204, 204, 1);
                            }

                            .bg-primary-200 {
                                background-color: rgba(230, 230, 230, 1);
                            }

                            .pagebreak {
                                page-break-after: always !important;
                                break-after: always !important;
                                page-break-after: always !important;
                                page-break-inside: avoid !important;
                            }

                            .align-top {
                                vertical-align: top;
                            }

                            .text-primary-600 {
                                color: rgba(128, 128, 128, 1);
                            }

                            .corp-primary {
                                color: {{primaryColor}}
                            }

                            .bg-corp-primary {
                                background-color: {{primaryColor}}
                            }

                            .corp-text-primary {
                                color: {{primaryTextColor}}
                            }

                            .whitespace-pre-line {
                                white-space: pre-line;
                            }

                            .uppercase {
                                text-transform: uppercase;
                            }

                            .break-all {
                                word-break: break-all;
                            }

                            .hide-on-print {
                                display: none !important;
                            }
                        </style>
                    </head>
                    <body>
                        {{HtmlContent}}
                    </body>
                </html>";

            template = template.Replace("{{primaryColor}}", primaryColor);
            template = template.Replace("{{primaryTextColor}}", primaryTextColor);
            return template;
        }
    }
}
