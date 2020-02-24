using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GridConfig
{
    public class CommonClass
    {
        public class CritRes
        {
            public bool    Cd;
            public string  FlName;
            public string  Msg;

            public CritRes()
            {
                Cd = false; FlName = "No field name"; Msg = "Unspecified data error message";
            }
            public CritRes( Boolean cd, string flName, string msg)
            {
                Cd = cd; FlName = flName; Msg = msg;
            }
        }

        public class GrdItem
        {
            public string   Nome    { get; set; }
            public string   Fone    { get; set; }
            public string   Depto   { get; set; }
            public DateTime Periodo { get; set; }
            public double   Salario { get; set; }

            public GrdItem()
            {
                Nome    = "";
                Fone    = "";
                Depto   = "";
                Periodo = DateTime.ParseExact("01/01/01", "dd/MM/yy", null);
                Salario = 0;
            }

            public GrdItem(string nome, string fone, string depto, string periodo, double salario)
            {
                Nome    = nome;
                Fone    = fone;
                Depto   = depto;
                Periodo = DateTime.ParseExact(periodo, "dd/MM/yy", null);
                Salario = salario;                
            }

            public List<CritRes> Critica()
            {
                CritRes cr;
                List<CritRes> crList = new List<CritRes>();
                                
                //  Nome
                if ( string.IsNullOrEmpty(Nome)) {
                    cr = new CritRes( false, "Nome", "Nome is required");
                    crList.Add(cr);
                }
                //  Fone
                if ( !Regex.IsMatch( Fone, "[0-9 ]{9,}" )) {
                    cr = new CritRes( false, "Fone", "Fone may contain space and at least 8 digits");
                    crList.Add(cr);
                }
                //  Salario               
                if ( Salario <= 0) {
                    cr = new CritRes( false, "Salario", "Salario deve ser maior que zero");
                    crList.Add(cr);
                }

                //  Return result
                return crList;
            }
        }
    }
}