using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Verify.AngleSharp;
using VerifyTests;

namespace ThopFood.Blazor.BUnit.Utils
{
    public static class BunitVerifyInitiator
    {
       
        [ModuleInitializer]
        public static void Initialize()
        {
            // remove some noise from the html snapshot
            VerifierSettings.ScrubEmptyLines();
            VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));
            HtmlPrettyPrint.All();

            VerifierSettings.ScrubLinesContaining("<script src=\"_framework/dotnet.");
        }
        }


    }

