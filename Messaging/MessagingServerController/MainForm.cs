using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Matrix.License;

namespace MessagingServerController
{
    public partial class MainForm : Form
    {
        // Thread signal.
        private readonly ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket m_Listener;
        private bool m_Listening;

        public MainForm()
        {
            InitializeComponent();
            SetLicense();
        }

        /// <summary>
        ///     Sets the license and activate the evaluation.
        /// </summary>
        private static void SetLicense()
        {

            const string lic = @"eJxkkFtTwkAMhf+K46ujbUGoOGHHQluo3AoI1ce1u+jWtlu2u73w6wXB+0sm
yZeTnAmMWUjTnJ5VSZzm3XP8cpnzjSyxoLfxEZ0j8AUnKpQeQUupCOOgfXdg
rnAqmayRAdpXDn2VS55QgWCKE4qcAscKSy5A+6ihz5MMp/UnYDw9O1kB7ZOB
k2AWoxzHNL/74eyK7IeObD/8dWiVESypU2VMUHufoYZumPp1ow3aPwRebtOE
IynUftepgEP8rW/rrYP+D4Ale0mxVIKiMqH9MugNey633tgu2xWB7rYj+TRz
FvzVHIhnPig2hWm1zf6F6oSVVq8XI1uueX0ziXy3boxG6caUclXX8XP1FNl6
oQwRLnt+7N9bky0pVmRbGqv5ooyCmRqnbiNQg6bczQzXC53ab045CYaitRT+
TdV7fNCjjpcVVmdIldeK/YKwZrmxctvpgvbtG7TTu9G7AA==";
            LicenseManager.SetLicense(lic);

            // when something is wrong with your license you can find the error here
            Console.WriteLine(LicenseManager.LicenseError);
        }


        private void Listen()
        {
            var localEndPoint = new IPEndPoint(IPAddress.Any, 5222);

            // Create a TCP/IP socket.
            m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                m_Listener.Bind(localEndPoint);
                m_Listener.Listen(10);

                m_Listening = true;

                while (m_Listening)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    m_Listener.BeginAccept(AcceptCallback, null);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            var sock = m_Listener.EndAccept(ar);

            var con = new XmppSeverConnection(sock);
        }

        private void btnCOnnect_Click(object sender, EventArgs e)
        {
            var myThreadDelegate = new ThreadStart(Listen);
            var myThread = new Thread(myThreadDelegate);
            myThread.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            m_Listening = false;
            allDone.Set();
        }
    }
}