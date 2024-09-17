using System;
using System.IO;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    private string logFilePath;

    void Start()
    {
        // Set the path for the log file to C:/Data directory
        logFilePath = "C:/Data/eventLog.txt";

        // Ensure the directory exists
        EnsureDirectoryExists("C:/Data");

        // Log an event
        LogEvent("Application started");
    }

    void OnApplicationQuit()
    {
        // Log an event
        LogEvent("Application quit");
    }

    // Function to log events
    private void LogEvent(string eventDescription)
    {
        // Append text to the existing file, creating the file if it doesn't exist
        using (StreamWriter sw = new StreamWriter(logFilePath, true))
        {
            sw.WriteLine(eventDescription + " at " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }
    }

    // Ensure the directory exists, create it if it doesn't
    private void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}
