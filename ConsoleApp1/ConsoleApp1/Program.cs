using System;
using System.Collections;
using System.IO;

public class ReadFile
{
   public static string diferenciaFechas(string fechaEvento)
    {
        string CurrentDate = "04/03/2022 15:00";

        //Use of Convert.ToDateTime()   
        DateTime date1 = Convert.ToDateTime(CurrentDate);
        DateTime date2 = Convert.ToDateTime(fechaEvento);
        
        int diferM = date1.Month - date2.Month;
        TimeSpan diferencias = date1 - date2;
        double dias = diferencias.TotalDays;
        double horas = diferencias.TotalHours;
        double diferMin = diferencias.TotalMinutes;

        return "Horas " + horas + " meses " + diferM + " minutos "+ diferMin ;
        if( diferM < 0)
        {
            return "Faltan: " + diferM;
        }
        else if (diferM > 1)
        {
            return "Fue hace: " + diferM;
        }
        else if(dias > 0 & dias < 30)
        {
            return "Fue hace: " + dias;
        }
        
    }
    static void Main(string[] args)
    {


        List<string> eventos = new List<string>();
        List<string> fechas = new List<string>();
      

        string ubicacionArchivo = "doc.txt";
        System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
        string linea;
        while ((linea = archivo.ReadLine()) != null)
        {

            int position = linea.IndexOf(",");
            if (position < 0)
                continue;
            eventos.Add(
                           linea.Substring(0,position));
            fechas.Add(
                           linea.Substring(position+1));

        }

        archivo.Close();

        for (int i = 0; i < eventos.Count; i++)
        {
           
                string funcionfechas = diferenciaFechas(fechas[i]);
            Console.WriteLine(eventos[i] + " " + funcionfechas);
            
            
                
            
        }

    }
}