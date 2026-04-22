using System.Text;

namespace RemoteMonitor_GUI;

public partial class Form1 : Form
{
    private readonly ServerManager _server = new();
    private readonly ClientManager _client = new();

    public Form1()
    {
        InitializeComponent();
        SetupEvents();
        SetupClientEvents(); // 
    }

    // ═══════════════════════════════════════
    // SERVER EVENTS
    // ═══════════════════════════════════════
    private void SetupEvents()
    {
        button2.Enabled = false;
        button10.Enabled = false;

        _server.OnLog += msg => AppendServerLog(msg);

        _server.OnClientsChanged += clients =>
        {
            Invoke((MethodInvoker)(() =>
            {
                listBox1.Items.Clear();
                foreach (var c in clients)
                    listBox1.Items.Add($"{c.Id} | {c.EndPoint} | {c.ConnectedAt:HH:mm:ss}");

                toolStripStatusLabel1.Text = $"Clients: {clients.Count}";
            }));
        };

        _server.OnScreenshotReceived += data =>
        {
            Invoke((MethodInvoker)(() =>
            {
                using var ms = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }));
        };
    }

    // ═══════════════════════════════════════
    // CLIENT EVENTS
    // ═══════════════════════════════════════
    private void SetupClientEvents()
    {
        _client.OnLog += msg => AppendClientLog(msg);

        _client.OnConnectionChanged += connected =>
        {
            Invoke((MethodInvoker)(() =>
            {
                button9.Enabled = !connected;
                button10.Enabled = connected;

                Host.Items.Clear();
                User.Items.Clear();
                Status.Items.Clear();

                if (connected)
                {
                    Host.Items.Add(Environment.MachineName);
                    User.Items.Add(Environment.UserName);
                    Status.Items.Add("Connected");

                    toolStripStatusLabel1.Text =
                        $"Connected → {textBox2.Text}:{numericUpDown2.Value}";
                }
                else
                {
                    Host.Items.Add("-");
                    User.Items.Add("-");
                    Status.Items.Add("Disconnected");

                    toolStripStatusLabel1.Text = "Disconnected";
                }
            }));
        };
    }

    // ═══════════════════════════════════════
    // SERVER TAB
    // ═══════════════════════════════════════

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            _server.Start((int)numericUpDown1.Value);
            button1.Enabled = false;
            button2.Enabled = true;

            toolStripStatusLabel1.Text =
                $"Listening on port {numericUpDown1.Value}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _server.Stop();
        button1.Enabled = true;
        button2.Enabled = false;

        listBox1.Items.Clear();
        pictureBox1.Image = null;

        toolStripStatusLabel1.Text = "Server stopped";
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null)
        {
            MessageBox.Show("Chọn client!");
            return;
        }

        await _server.SendToAsync(id, PacketType.RequestScreenshot, []);
    }

    private async void button4_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null) return;

        await _server.SendToAsync(id, PacketType.StreamControl, [1]);
    }

    private async void button5_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null) return;

        await _server.SendToAsync(id, PacketType.StreamControl, [0]);
    }

    private void button6_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null) return;

        _server.KickClient(id);
    }

    private void button7_Click(object sender, EventArgs e)
    {
        var clients = _server.GetClients();
        AppendServerLog($"Clients: {clients.Count}");
    }

    private async void button8_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

        var msg = "[ADMIN] " + textBox1.Text;

        await _server.SendToAllAsync(PacketType.ChatMessage,
            Encoding.UTF8.GetBytes(msg));

        AppendServerLog(msg);
        textBox1.Clear();
    }

    private string? GetSelectedClientId()
    {
        if (listBox1.SelectedItem == null) return null;
        return listBox1.SelectedItem.ToString()?.Split('|')[0].Trim();
    }

    private void AppendServerLog(string msg)
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)(() => AppendServerLog(msg)));
            return;
        }

        richTextBox1.AppendText(
            $"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");

        richTextBox1.ScrollToCaret();
    }

    // ═══════════════════════════════════════
    // CLIENT TAB
    // ═══════════════════════════════════════

    private async void button9_Click(object sender, EventArgs e)
    {
        try
        {
            string ip = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Nhập IP server!");
                return;
            }

            button9.Enabled = false;
            await _client.ConnectAsync(ip, (int)numericUpDown2.Value);
        }
        catch (Exception ex)
        {
            button9.Enabled = true;
            MessageBox.Show(ex.Message);
        }
    }

    private void button10_Click(object sender, EventArgs e)
    {
        _client.Disconnect();
    }

    private async void button11_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox3.Text)) return;

        await _client.SendChatAsync(textBox3.Text);
        textBox3.Clear();
    }

    private void button12_Click(object sender, EventArgs e)
    {
        richTextBox2.Clear();
    }

    private void button13_Click(object sender, EventArgs e)
    {
        _client.Disconnect();
        _server.Stop();
        Application.Exit();
    }

    private void AppendClientLog(string msg)
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)(() => AppendClientLog(msg)));
            return;
        }

        richTextBox2.AppendText(
            $"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");

        richTextBox2.ScrollToCaret();
    }
    
    private void tabPage2_Click(object sender, EventArgs e) { }

    private void label11_Click(object sender, EventArgs e) { }

    private void label1_Click(object sender, EventArgs e) { }

    private void Form1_Load(object sender, EventArgs e) { }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
}
