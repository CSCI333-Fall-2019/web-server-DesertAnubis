/* # # # # # # # # # # # Documentation # # # # # # # # # # # */
// Author:  Des
// Date:    10/3/2019
// Purpose: To open a window to spin up a server with multi-threading
/* # # # # # # # # # # # # # # # # # # # # # # # # # # # # # */

/* # # # # # # # # # # # # Libraries # # # # # # # # # # # # */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

/* # # # # # # # # # # # Main Action # # # # # # # # # # # */
namespace WebServer
{
   public partial class Form1 : Form
   {
      // Initializes the window
      public Form1()
      {
         InitializeComponent();
      }

      // When the start button is clicked...
      private void startBtn_Click(object sender, EventArgs e)
      {
         // Swaps which button is active
         startBtn.Enabled = false;
         stopBtn.Enabled = true;

         // Creates a new client and gives it a thread
         TcpClient client = new TcpClient();
         ThreadPool.QueueUserWorkItem(GetRequestedItem, client);
      }

      // When the stop button is clicked...
      private void stopBtn_Click(object sender, EventArgs e)
      {
         // Swaps which button is active
         startBtn.Enabled = true;
         stopBtn.Enabled = false;
      }

      // Gets the item the client has requested (provided the client exists)
      public void GetRequestedItem(object parClient)
      {
         // If the client doesn't exist, pop out
         if (parClient == null)
            return;

         // Cast the client object to a TcpClient
         TcpClient client = (TcpClient)parClient;

         // Set up a few variables
         Byte[] output = new Byte[1024];
         string response = String.Empty;
         // NetworkStream ns = client.GetStream();

         // Status report
         Console.WriteLine("Connecting...");

         // Write a request to the web server
         // Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("GET / HTTP/1.0 \nHost: " + /* ??? */ "\n\n");
         
         /*
         ns.Write(cmd, 0, cmd.Length);

         // Get the output
         Int32 bytes = ns.Read(output, 0, output.Length);

         while (bytes > 0)
         {
            response += System.Text.Encoding.ASCII.GetString(output);
            bytes = ns.Read(output, 0, output.Length);
         }
         */

         Thread.Sleep(5000);
      }
   }
}

/* # # # # # # # # # # # Documentation # # # # # # # # # # # */
// Edit Name: 
// Edit Date: 
// Edit Note: 
/* # # # # # # # # # # # # # # # # # # # # # # # # # # # # # */