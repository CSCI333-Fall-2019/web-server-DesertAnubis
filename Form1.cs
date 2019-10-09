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
using System.IO;
using System.Linq;
using System.Net;
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
      TcpListener listener;
      int port = 85;

      // Initializes the window
      public Form1()
      {
         InitializeComponent();
      }

      // Threadsafe IsRunning flag to keep track of running state
      private bool _isRunning;
      static readonly object _isRunningLock = new object();
      public bool IsRunning
      {
         get
         {
            lock (_isRunningLock)
            {
               return this._isRunning;
            }
         }
         set
         {
            lock (_isRunningLock)
            {
               this._isRunning = value;
            }
            startBtn.Enabled = !value;
            stopBtn.Enabled = value;
         }
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
         Form1 main = new Form1();

         // Start the main object's listener
         main.listener = new TcpListener(IPAddress.Any, main.port);
         main.listener.Start();

         while (main.IsRunning) // Run until we're told to exit
         {
            try
            {
               // Each new request to the listener get a TcpClient
               TcpClient lClient = main.listener.AcceptTcpClient();
               // Send that TcpClient to its own thread to process
               ThreadPool.QueueUserWorkItem(GetRequestedItem, lClient);
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error received: " + ex.Message);
            }
         }
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

         // Response Data init
         Byte[] output = new Byte[1024];
         string response = String.Empty;
         // NetworkStream ns = client.GetStream();

         MemoryStream destination = new MemoryStream();
         using (FileStream source = File.Open(@"Content\default.html", FileMode.Open, FileAccess.Read, FileShare.Read))
         {
            Console.WriteLine("Source length: (0)", source.Length.ToString());

            // Copy source to destination
            source.CopyTo(destination);
         }

         // Create and Send the header
         string header = CreateHeader(@"HTTP/1.0", @"text/html", destination.Length, " 200 OK");
         client.Client.Send(Encoding.ASCII.GetBytes(header));
         client.Client.Send(destination.ToArray());
      }

      public string CreateHeader(string webText, string contType, long contLength, string statusCode)
      {
         return "Thank you for visiting";
      }

      public void SetForegroundData(string value)
      {
         // Is this a background thread? If so, call parent
         if (InvokeRequired)
         {
            this.BeginInvoke(new Action<string>(SetForegroundData));
            return;
         }
      }
   }
}

/* # # # # # # # # # # # Documentation # # # # # # # # # # # */
// Edit Name: 
// Edit Date: 
// Edit Note: 
/* # # # # # # # # # # # # # # # # # # # # # # # # # # # # # */