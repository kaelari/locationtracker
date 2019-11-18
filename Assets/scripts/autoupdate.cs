using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Linq;



public class autoupdate : MonoBehaviour
{
   

    public Process ReadProcess = null;
    private IntPtr handle = IntPtr.Zero;
    

    public Controller controller;


    public void OpenProcess()
    {

        handle = ProcessMemoryReaderApi.OpenProcess((uint)ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_READ, 0, (uint)ReadProcess.Id);

    }

    public byte[] ReadMemory (IntPtr memoryaddress, uint bytesToRead, out int bytesRead) {
        byte[] buffer = new byte[bytesToRead];
        IntPtr pBytesRead;
        int returned = ProcessMemoryReaderApi.ReadProcessMemory(handle, memoryaddress, buffer, bytesToRead, out pBytesRead);

        bytesRead = pBytesRead.ToInt32();
        return buffer;

    }
    uint offset = 0;
    IEnumerator getdata()
    {

        //UnityEngine.Debug.Log("running");

        if (ReadProcess != null)
        {
            Process check = Process.GetProcessById(ReadProcess.Id);
            if (check.Id != ReadProcess.Id)
            {
                UnityEngine.Debug.Log("lost process? " + check.Id + " " + ReadProcess.Id);
                ReadProcess = null;
                handle = IntPtr.Zero;

            }
        }


        if (ReadProcess == null && handle == IntPtr.Zero)
        {


            Process[] processes = Process.GetProcessesByName("fceux");
            if (processes.Length == 0)
            {
                yield break;
            }

            ReadProcess = processes[0];

            if (ReadProcess == null)
            {
                UnityEngine.Debug.Log("TEST null");

                yield break;
            }
            UnityEngine.Debug.Log("found process " + ReadProcess.Id.ToString());


            OpenProcess();
            UnityEngine.Debug.Log("opened process " + ReadProcess.Id.ToString());




        }

        uint baseaddress = 0x003B1388;

        uint paddress = baseaddress;



        offset = BitConverter.ToUInt32(ReadMemory((IntPtr)(paddress + (uint)ReadProcess.Modules[0].BaseAddress), 4, out int bytesread), 0);

        byte[] results = ReadMemory((IntPtr)(offset + 0x91), 2, out bytesread);

        byte[] resultstest = ReadMemory((IntPtr)(offset + 0x007D), 1, out bytesread);
        if (resultstest[0] != controller.writing)
        {
            controller.writing = resultstest[0];
            if (resultstest[0] == 0x3c)
            {
                UnityEngine.Debug.Log("text displayed");

                controller.record(findlocation(), "checked");
            }
            //UnityEngine.Debug.Log(BitConverter.ToString(resultstest));
        }

        
        if ((results[0] & 32) == 32)
        {
            if ((results[0] & 64) == 64 && controller.olditems["rcrystal"] == false)
            {
                UnityEngine.Debug.Log("got red crystal");
                controller.curitems["rcrystal"] = true;
            }
            else if (controller.olditems["wcrystal"] == false)
            {
                UnityEngine.Debug.Log("got white crystal");

                controller.curitems["wcrystal"] = true;

                string where = findlocation();
                controller.record(where, "crystal");

                UnityEngine.Debug.Log("found white crystal: " + where);


            }
        }
        
        if ((results[0] & 64) == 64 && controller.olditems["bcrystal"] == false)
        {
            UnityEngine.Debug.Log("Have blue crystal");
            controller.curitems["bcrystal"] = true;
            string where = findlocation();
            controller.record(where, "crystal");
        }

        if ((results[0] & 1) == 1 && controller.olditems["rib"] == false)
        {
            UnityEngine.Debug.Log("Have rib");
            controller.curitems["rib"] = true;
            string where = findlocation();
            controller.record(where, "rib");
        }
        
        if ((results[0] & 2) == 2 && controller.olditems["heart"] == false)
        {
            UnityEngine.Debug.Log("Have heart");
            controller.curitems["heart"] = true;
            string where = findlocation();
            controller.record(where, "heart");
        }
        if ((results[0] & 4) == 4 && controller.olditems["eyeball"] == false)
        {
            UnityEngine.Debug.Log("Have eye");
            controller.curitems["eyeball"] = true;
            string where = findlocation();
            controller.record(where, "eyeball");
        }
        if ((results[0] & 8) == 8 && controller.olditems["nail"] == false)
        {
            UnityEngine.Debug.Log("Have nail");
            controller.curitems["nail"] = true;
            string where = findlocation();
            controller.record(where, "nail");
        }
        if ((results[0] & 16) == 16 && controller.olditems["ring"] == false)
        {
            UnityEngine.Debug.Log("Have ring");
            controller.curitems["ring"] = true;
            string where = findlocation();
            controller.record(where, "ring");
        }
        if ((results[1] & 2) == 2 && controller.olditems["cross"] == false)
        {
            UnityEngine.Debug.Log("Have magic cross");
            controller.curitems["cross"] = true;
            string where = findlocation();
            controller.record(where, "cross");
        }
        if ((results[1] & 1) == 1 && controller.olditems["bag"] == false)
        {
            UnityEngine.Debug.Log("Have bag");
            controller.curitems["bag"] = true;
            string where = findlocation();
            controller.record(where, "bag");
        }
        results = ReadMemory((IntPtr)(offset + 0x004A), 1, out bytesread);
        
        if ((results[0] & 1) == 1 && controller.olditems["dagger"] == false)
        {
            controller.curitems["dagger"] = true;
            UnityEngine.Debug.Log("Have dagger");
            string where = findlocation();
            controller.record(where, "dagger");
        }
        if ((results[0] & 2) == 2 && controller.olditems["silver dagger"] == false)
        {
            controller.curitems["silver dagger"] = true;
            UnityEngine.Debug.Log("Have silver dagger");
            string where = findlocation();
            controller.record(where, "silver dagger");
        }
        if ((results[0] & 4) == 4 && controller.olditems["gold knife"] == false)
        {
            controller.curitems["gold knife"] = true;
            UnityEngine.Debug.Log("Have Gold Knife");
            string where = findlocation();
            controller.record(where, "gold knife");
        }
        if ((results[0] & 8) == 8 && controller.olditems["holy water"] == false)
        {
            controller.curitems["holy water"] = true;
            UnityEngine.Debug.Log("got holy water");
            string where = findlocation();
            controller.record(where, "holy water");
            

        }
        if ((results[0] & 16) == 16 && controller.olditems["diamond"] == false)
        {
            controller.curitems["diamond"] = true;
            UnityEngine.Debug.Log("Have diamond");
            string where = findlocation();
            controller.record(where, "diamond");
        }
        if ((results[0] & 32) == 32 && controller.olditems["flame"] == false)
        {
            controller.curitems["flame"] = true;
            UnityEngine.Debug.Log("Have Sacred Flame");
            string where = findlocation();
            controller.record(where, "sacred flame");
        }
        if ((results[0] & 64) == 64 && controller.olditems["stake"] == false)
        {
            controller.curitems["stake"] = true;
            UnityEngine.Debug.Log("Have Oak Stake");
            string where = findlocation();
            controller.record(where, "oak stake");
        }
        else if ((results[0] & 64) == 64)
        {
            //do nothing
        }else 
        {
            if (controller.olditems["stake"] == true )
            {
                //we threw a stake! next item we get probably came from the orb
                UnityEngine.Debug.Log("We threw a stake!");
                string where = findlocation();
                controller.record(where, "checked");
            }

            controller.olditems["stake"] = false;
            


        }


        results = ReadMemory((IntPtr)(offset + 0x004D), 1, out bytesread);
        //UnityEngine.Debug.Log("Garlic: "+results[0].ToString());
        if (results[0]> 0 && controller.garlic < results[0])
        {
            //we have more garlic now
            controller.garlic = results[0];
            string where = findlocation();
            controller.record(where, "garlic");
        }
        else if (results[0] != controller.garlic)
        {
            //we threw some garlic
            controller.garlic = results[0];
        }
        else
        {
            
        }
        results = ReadMemory((IntPtr)(offset + 0x004C), 1, out bytesread);
        //UnityEngine.Debug.Log("Laurels: " + results[0].ToString());
        if (results[0] > 0 && controller.laurels < results[0])
        {
            //we have more laurels now
            controller.laurels = results[0];
            string where = findlocation();
            controller.record(where, "laurels");
        }
        else if (results[0] != controller.laurels)
        {
            controller.laurels = results[0];
        }else 
        {
            
        }


        results = ReadMemory((IntPtr)(offset + 0x434), 1, out bytesread);
        if (results[0] != controller.whip && results[0]>0)
        {
            UnityEngine.Debug.Log("Whip: " + results[0].ToString());
            controller.whip = results[0];
            string where = findlocation();
            controller.record(where, "whip");
        }




    }

    string findlocation()
    {
        byte[] results2 = ReadMemory((IntPtr)(offset + 0x3d), 2, out int bytesread);

        UnityEngine.Debug.Log("map positions:");
        UnityEngine.Debug.Log(BitConverter.ToString(results2));
        
        if (results2[0] == 0xAC && results2[1] == 0x90)
        {
            return "jova1";
        }
        if (results2[0] == 0x43 && results2[1] == 0x91)
        {
            return "jova2";
        }
        if (results2[0] == 0x3E && results2[1] == 0x91)
        {
            return "jova3";
        }
        if (results2[0] == 0x95 && results2[1] == 0x92)
        {
            return "veros1";
        }
        if (results2[0] == 0x9A && results2[1] == 0x92)
        {
            return "veros2";
        }
        if (results2[0] == 0xA0 && results2[1] == 0xA6)
        {
            return "flame";
        }
        if (results2[0] == 0x6C && results2[1] == 0x91)
        {
            return "aljiba1";
        }
        if (results2[0] == 0xDF && results2[1] == 0x91)
        {
            return "aljiba2";
        }
        if (results2[0] == 0xEF && results2[1] == 0x91)
        {
            return "aljiba3";
        }
        if (results2[0] == 0x22 && results2[1] == 0xAF)
        {
            return "aljiba4";
        }
        if (results2[0] == 0xF5 && results2[1] == 0x90)
        {
            return "alba1";
        }
        if (results2[0] == 0x4F && results2[1] == 0x91)
        {
            return "alba2";
        }
        if (results2[0] == 0x49 && results2[1] == 0x91)
        {
            return "alba3";
        }
        if (results2[0] == 0x78 && results2[1] == 0xAF)
        {
            return "duck";
        }
        if (results2[0] == 0xB0 && results2[1] == 0x92)
        {
            return "ondol1";
        }
        if (results2[0] == 0xA4 && results2[1] == 0x92)
        {
            return "ondol2";
        }
        if (results2[0] == 0x3F && results2[1] == 0xA8)
        {
            return "diamond";
        }
        if (results2[0] == 0x50 && results2[1] == 0x9C)
        {
            return "brahm merchant";
        }
        if (results2[0] == 0xCE && results2[1] == 0x9C)
        {
            return "death";
        }
        if (results2[0] == 0xD3 && results2[1] == 0x9C)
        {
            return "brahm orb";
        }
        if (results2[0] == 0xF9 && results2[1] == 0x91)
        {
            return "doina";
        }
        if (results2[0] == 0x7D && results2[1] == 0xB2)
        {
            return "flamewhip dude";
        }
        if (results2[0] == 0xB6 && results2[1] == 0x9A)
        {
            return "carmilla";
        }
        if (results2[0] == 0xBB && results2[1] == 0x9A)
        {
            return "laruba orb";
        }

        if (results2[0] == 0x55 && results2[1] == 0x9A)
        {

            byte[] results3 = ReadMemory((IntPtr)(offset + 0x0057), 2, out bytesread);
            //this could be wrong but seems to work. i'm not 100% on what this value is but it goes up as you move the screen down.

            UnityEngine.Debug.Log("map sub-positions:");
            UnityEngine.Debug.Log(BitConverter.ToString(results3));
            if (results3[0] <= 1)
            {

                return "laruba merchant";
            }
            else
            {

                return "laruba laurels";
            }

            
        }




        if (results2[0] == 0x2D && results2[1] == 0x9B)
        {
            byte[] results3 = ReadMemory((IntPtr)(offset + 0x0058), 2, out bytesread);

            UnityEngine.Debug.Log("map sub-positions:");
            UnityEngine.Debug.Log(BitConverter.ToString(results3));
            if (results3[0] < 0x20)
            {
                return "berkley orb";
            }
            else
            {
                return "berkley merchant";
            }
        }

        if (results2[0] == 0x57 && results2[1] == 0x9F)
        {
            byte[] results3 = ReadMemory((IntPtr)(offset + 0x0058), 2, out bytesread);

            UnityEngine.Debug.Log("map sub-positions:");
            UnityEngine.Debug.Log(BitConverter.ToString(results3));
            if (results3[0] <= 0x0F && results3[0] >=0x06)
            {
                //0e-1d
                return "bodley orb";
            }
            else
            {
                //04-13
                return "bodley merchant";
            }
        }

        if (results2[0] == 0xF7 && results2[1] == 0x9B)
        {
            byte[] results3 = ReadMemory((IntPtr)(offset + 0x0057), 2, out bytesread);
            //this could be wrong but seems to work. i'm not 100% on what this value is but it goes up as you move the screen down.

            UnityEngine.Debug.Log("map sub-positions:");
            UnityEngine.Debug.Log(BitConverter.ToString(results3));
            if (results3[0] <= 1)
            {
                
                return "rover orb";
            }
            else
            {
                
                return "rover merchant";
            }
            
        }

        return "unknown";

    }

    void test()
    {

        StartCoroutine(getdata());
    }

    // Start is called before the first frame update
    void Start()
    {

        controller = FindObjectOfType<Controller>();

        InvokeRepeating("test", 2.0f, 0.1f);

    }


    // Update is called once per frame
    void Update()
    {


    }

}



/// <summary>
/// ProcessMemoryReader is a class that enables direct reading a process memory
/// </summary>
class ProcessMemoryReaderApi
{
    // constants information can be found in <winnt.h>
    [Flags]
    public enum ProcessAccessType
    {
        PROCESS_TERMINATE = (0x0001),
        PROCESS_CREATE_THREAD = (0x0002),
        PROCESS_SET_SESSIONID = (0x0004),
        PROCESS_VM_OPERATION = (0x0008),
        PROCESS_VM_READ = (0x0010),
        PROCESS_VM_WRITE = (0x0020),
        PROCESS_DUP_HANDLE = (0x0040),
        PROCESS_CREATE_PROCESS = (0x0080),
        PROCESS_SET_QUOTA = (0x0100),
        PROCESS_SET_INFORMATION = (0x0200),
        PROCESS_QUERY_INFORMATION = (0x0400),
        PROCESS_QUERY_LIMITED_INFORMATION = (0x1000)
    }

    // function declarations are found in the MSDN and in <winbase.h>

    //		HANDLE OpenProcess(
    //			DWORD dwDesiredAccess,  // access flag
    //			BOOL bInheritHandle,    // handle inheritance option
    //			DWORD dwProcessId       // process identifier
    //			);
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

    //		BOOL CloseHandle(
    //			HANDLE hObject   // handle to object
    //			);
    [DllImport("kernel32.dll")]
    public static extern Int32 CloseHandle(IntPtr hObject);

    //		BOOL ReadProcessMemory(
    //			HANDLE hProcess,              // handle to the process
    //			LPCVOID lpBaseAddress,        // base of memory area
    //			LPVOID lpBuffer,              // data buffer
    //			SIZE_T nSize,                 // number of bytes to read
    //			SIZE_T * lpNumberOfBytesRead  // number of bytes read
    //			);
    [DllImport("kernel32.dll")]
    public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

    //		BOOL WriteProcessMemory(
    //			HANDLE hProcess,                // handle to process
    //			LPVOID lpBaseAddress,           // base of memory area
    //			LPCVOID lpBuffer,               // data buffer
    //			SIZE_T nSize,                   // count of bytes to write
    //			SIZE_T * lpNumberOfBytesWritten // count of bytes written
    //			);
    [DllImport("kernel32.dll")]
    public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);
}
