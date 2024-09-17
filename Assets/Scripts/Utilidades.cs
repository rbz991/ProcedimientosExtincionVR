using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Utilidades
{
    public static int GlobosSimultaneos = 1;
        public static bool startRich = true;
    public static bool StartProgram = false;
    public static bool TimeOut = false;
    private static List<int> VIList1 = new List<int>();
    private static List<int> VIList2 = new List<int>();

    public static bool[] notAvailableSpawnPoints = new bool[5];
    public static void LiberarPuntoDeSpawn(int spawnIndex)
    {
        // Marca el punto de spawn como disponible
        if (spawnIndex >= 0 && spawnIndex < notAvailableSpawnPoints.Length)
        {
            notAvailableSpawnPoints[spawnIndex] = false;

            // Añade el índice del punto de spawn a la lista de puntos disponibles
            if (!SpawnPointsIndex.Contains(spawnIndex))
            {
                SpawnPointsIndex.Add(spawnIndex);
            }
        }
    }

    // Lista de puntos disponibles
    public static List<int> SpawnPointsIndex = new List<int>();
    public static float VIGen1(int viv)
    {
        System.Random Rand = new System.Random();
        int p = 0;
        int q = 0;
        int v = viv * 1000; // Este valor representa el valor VI.
        int n = 10; // Este valor representa las iteraciones de VI.
        int[] rd = new int[n];
        int[] vi = new int[n];
        int order;

        if (VIList1.Count == 0)
        {
            for (int m = 0; m < n; m++) // Cambiado para que m empiece en 0 y vaya hasta n-1
            {
                if (m == n - 1) // Cambiado para comparar con n-1, el último índice válido
                {
                    vi[m] = (int)(v * (1 + Mathf.Log(n)));
                }
                else
                {
                    vi[m] = (int)(v * (1 + Mathf.Log(n) + (n - m - 1) * Mathf.Log(n - m - 1) - (n - m) * Mathf.Log(n - m)));
                }

            retry:
                order = Rand.Next(n); // Genera un número aleatorio entre 0 y n-1
                if (rd[order] == 0)
                {
                    rd[order] = vi[m];
                }
                else
                {
                    goto retry;
                }
            }

            for (int a = 0; a < n; a++) // Cambiado para que a empiece en 0 y vaya hasta n-1
            {
                VIList1.Add(rd[a]);
            }
        }

        p = Rand.Next(VIList1.Count);
        q = VIList1[p];
        //Debug.Log(q);
        VIList1.RemoveAt(p);
        return q;
    }

    public static float VIGen2(int viv)
    {
        System.Random Rand = new System.Random();
        int p = 0;
        int q = 0;
        int v = viv * 1000; // Este valor representa el valor VI.
        int n = 10; // Este valor representa las iteraciones de VI.
        int[] rd = new int[n];
        int[] vi = new int[n];
        int order;

        if (VIList2.Count == 0)
        {
            for (int m = 0; m < n; m++) // Cambiado para que m empiece en 0 y vaya hasta n-1
            {
                if (m == n - 1) // Cambiado para comparar con n-1, el último índice válido
                {
                    vi[m] = (int)(v * (1 + Mathf.Log(n)));
                }
                else
                {
                    vi[m] = (int)(v * (1 + Mathf.Log(n) + (n - m - 1) * Mathf.Log(n - m - 1) - (n - m) * Mathf.Log(n - m)));
                }

            retry:
                order = Rand.Next(n); // Genera un número aleatorio entre 0 y n-1
                if (rd[order] == 0)
                {
                    rd[order] = vi[m];
                }
                else
                {
                    goto retry;
                }
            }

            for (int a = 0; a < n; a++) // Cambiado para que a empiece en 0 y vaya hasta n-1
            {
                VIList2.Add(rd[a]);
            }
        }

        p = Rand.Next(VIList2.Count);
        q = VIList2[p];
        //Debug.Log(q);
        VIList2.RemoveAt(p);
        return q;
    }

    //public static LoggingManager Instance;

    public static string logFilePath;

    public static void StartLogging()
    {
       
            // Set the log file path
            logFilePath = Path.Combine(Application.persistentDataPath, "eventLogX.txt");

            // Log an event
            LogEvent("Logging Manager initialized at " + System.DateTime.Now);
       
    }

    // Public method to log events
    public static void LogEvent(string eventDescription)
    {
        using (StreamWriter sw = new StreamWriter(logFilePath, true))
        {
            sw.WriteLine(Mathf.FloorToInt(Time.time * 1000) + "," + eventDescription);
        }
    }



}
