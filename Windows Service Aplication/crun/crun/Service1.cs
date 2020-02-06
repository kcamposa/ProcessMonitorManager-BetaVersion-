using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace crun
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer tproccess = null;
        WebReference.IS ws = new WebReference.IS();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tproccess = new System.Timers.Timer();
            tproccess.Interval = 60000;
            tproccess.Elapsed += new System.Timers.ElapsedEventHandler(tproccess_Elapsed);
            tproccess.Enabled = true;
            tproccess.Start();
        }
        void tproccess_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tproccess.Enabled = false; // 
            string user = "admin_ti";
            string pass = "$ur_pck9.";
            string Computername = System.Environment.MachineName; //name of current machine

            bool ver = searchProccesses(Computername, user, pass); // execute command and later i know if process is running or not
            ws.receiveMachines(Computername, ver); //send data to web reference 

        }

        public bool searchProccesses(string Computername, string user, string pass)
        {
            //Tasklist /S CRSCSRV05 /U gsa_kevin /P PaSsWoRd****           
            string comand = "Tasklist /S " + Computername + " /U " + user + " /P " + pass + "";
            bool ver = executeCommand(comand);
            if (ver == true)
            {
                ver = true;
            }
            return ver;
        }

        public bool executeCommand(string _Command)// execute command to know proccesses are running
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();
            //Muestra en pantalla la salida del Comando
            //Console.WriteLine(result);

            bool ver = AddProcessInArray(result); //search in the string if has a OneDrive.exe proccess
            if (ver == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddProcessInArray(string processes) //search OneDrive.exe proccesses 
        {
            bool containsSearchResult = processes.Contains("OneDrive.exe");
            if (containsSearchResult == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Finalizó la busqueda del proceso de OneDrive para la tienda");
            tproccess.Enabled = true;
        }
    }
}
