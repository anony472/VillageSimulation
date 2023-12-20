using UnityEngine;
using System;
using UnityEditor;
using AnotherFileBrowser.Windows;
using System.Diagnostics;
// using UnityEditor.Scripting.Python;
public class ChooseFile : MonoBehaviour
{
    public void Main()
    {
        var bp = new BrowserProperties();
        bp.filter = "Shapefiles (*.shp)|*.shp";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            if (!string.IsNullOrEmpty(path))
            {
                UnityEngine.Debug.Log("Selected file: " + path);
            }
            runPythonScript(path);
        });
    }

    public void runPythonScript(string path)
    {
        var psi = new ProcessStartInfo();
        psi.FileName = "/usr/bin/python3";
        var script = "script.py";
        var shapefile_path = path;
        psi.Arguments = $"{script} {shapefile_path}";

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;


        var errors = "";
        var results = "";

        using (var process = Process.Start(psi))
        {
            if (process != null)
            {
                process.WaitForExit();
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
                UnityEngine.Debug.Log("Hnn chal raha hai");
                UnityEngine.Debug.Log(results);
            }
        }

    }

}
