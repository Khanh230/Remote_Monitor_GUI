using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RemoteMonitor_GUI;

public partial class Form1 : Form
{
    private readonly ServerManager _server = new();
    private readonly ClientManager _client = new();

    public Form1()
    {
        InitializeComponent();
        SetupEvents();
    }

    // ═══════════════════════════════════════
    //           KHỞI TẠO SỰ KIỆN
    // ═══════════════════════════════════════
    private void SetupEvents()
    {
        // Mặc định disable Stop/Disconnect
        button2.Enabled = false;
        button10.Enabled = false;

        // Server events
        _server.OnLog += msg => AppendServerLog(msg);

        _server.OnClientsChanged += clients =>
        {
            Invoke(() =>
            {
                listBox1.Items.Clear();
                foreach (var c in clients)
                    listBox1.Items.Add($"{c.Id}  |  {c.EndPoint}  |  {c.ConnectedAt:HH:mm:ss}");
                toolStripStatusLabel1.Text = $"Status: {clients.Count} client(s) connected";
            });
        };

        _server.OnScreenshotReceived += data =>
        {
            Invoke(() =>
            {
                using var ms = new MemoryStream(data);
                var img = Image.FromStream(ms);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            });
        };

        // Client events
        _client.OnLog += msg => AppendClientLog(msg);

        _client.OnConnectionChanged += connected =>
        {
            Invoke(() =>
            {
                button9.Enabled = !connected;
                button10.Enabled = connected;

                if (connected)
                {
                    Host.Items.Clear();
                    Host.Items.Add(Environment.MachineName);

                    User.Items.Clear();
                    User.Items.Add(Environment.UserName);

                    Status.Items.Clear();
                    Status.Items.Add("Connected");
                    toolStripStatusLabel1.Text = $"Status: Connected to {textBox2.Text}";
                }
                else
                {
                    Host.Text = "Host";
                    User.Text = "User";
                    Status.Text = "Disconnected";
                    toolStripStatusLabel1.Text = "Status: Disconnected";
                }
            });
        };
    }

    // ═══════════════════════════════════════
    //           TAB SERVER
    // ═══════════════════════════════════════

    // Nút Start Service
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            _server.Start((int)numericUpDown1.Value);
            button1.Enabled = false;
            button2.Enabled = true;
            toolStripStatusLabel1.Text = $"Status: Listening on port {numericUpDown1.Value}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể khởi động server:\n{ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Nút Stop Service
    private void button2_Click(object sender, EventArgs e)
    {
        _server.Stop();
        button1.Enabled = true;
        button2.Enabled = false;
        listBox1.Items.Clear();
        pictureBox1.Image = null;
        toolStripStatusLabel1.Text = "Status: Stopped";
    }

    // Nút Capture
    private async void button3_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn client trong danh sách!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        await _server.SendToAsync(id, PacketType.RequestScreenshot, []);
        AppendServerLog($"Capture requested → [{id}]");
    }

    // Nút Stream On
    private async void button4_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn client trong danh sách!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        await _server.SendToAsync(id, PacketType.StreamControl, [1]);
        AppendServerLog($"Stream ON → [{id}]");
    }

    // Nút Stream Off
    private async void button5_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn client trong danh sách!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        await _server.SendToAsync(id, PacketType.StreamControl, [0]);
        AppendServerLog($"Stream OFF → [{id}]");
    }

    // Nút Kick
    private void button6_Click(object sender, EventArgs e)
    {
        var id = GetSelectedClientId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn client trong danh sách!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var confirm = MessageBox.Show($"Kick client [{id}]?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm == DialogResult.Yes)
        {
            _server.KickClient(id);
            AppendServerLog($"Kicked: [{id}]");
        }
    }

    // Nút List
    private void button7_Click(object sender, EventArgs e)
    {
        var clients = _server.GetClients();
        AppendServerLog($"=== {clients.Count} client(s) connected ===");
        foreach (var c in clients)
            AppendServerLog($"  [{c.Id}] {c.EndPoint} — Connected: {c.ConnectedAt:HH:mm:ss}");
    }

    // Nút Send (Server gửi chat)
    private async void button8_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text)) return;
        var msg = $"[ADMIN]: {textBox1.Text}";
        await _server.SendToAllAsync(PacketType.ChatMessage, Encoding.UTF8.GetBytes(msg));
        AppendServerLog(msg);
        textBox1.Clear();
    }

    // Lấy ID client đang được chọn trong listBox1
    private string? GetSelectedClientId()
    {
        if (listBox1.SelectedItem == null) return null;
        return listBox1.SelectedItem.ToString()?.Split('|')[0].Trim();
    }

    // Ghi log vào Activity Log
    private void AppendServerLog(string msg)
    {
        if (richTextBox1.InvokeRequired)
            richTextBox1.Invoke(() => AppendServerLog(msg));
        else
        {
            richTextBox1.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
            richTextBox1.ScrollToCaret();
        }
    }

    // ═══════════════════════════════════════
    //           TAB CLIENT
    // ═══════════════════════════════════════

    // Nút Connect
    private async void button9_Click(object sender, EventArgs e)
    {
        try
        {
            button9.Enabled = false;
            await _client.ConnectAsync(textBox2.Text.Trim(), (int)numericUpDown2.Value);
        }
        catch (Exception ex)
        {
            button9.Enabled = true;
            MessageBox.Show($"Không thể kết nối:\n{ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void SetupClientEvents()
    {
        _client.OnLog += msg => AppendClientLog(msg);

        _client.OnConnectionChanged += connected =>
        {
            Invoke(() =>
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
                    Status.Items.Add("✅ Connected");
                    toolStripStatusLabel1.Text = $"Status: Connected to {textBox2.Text}:{numericUpDown2.Value}";
                }
                else
                {
                    Host.Items.Add("-");
                    User.Items.Add("-");
                    Status.Items.Add("❌ Disconnected");
                    toolStripStatusLabel1.Text = "Status: Disconnected";
                }
            });
        };
    }
    // Nút Disconnect
    private void button10_Click(object sender, EventArgs e)
    {
        _client.Disconnect();
    }

    // Nút Send (Client gửi chat)
    private async void button11_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox3.Text)) return;
        await _client.SendChatAsync(textBox3.Text.Trim());
        textBox3.Clear();
    }

    // Nút Clear Log
    private void button12_Click(object sender, EventArgs e)
    {
        richTextBox2.Clear();
    }

    // Nút Exit
    private void button13_Click(object sender, EventArgs e)
    {
        var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm == DialogResult.Yes)
        {
            _client.Disconnect();
            _server.Stop();
            Application.Exit();
        }
    }

    // Ghi log vào Message Log
    private void AppendClientLog(string msg)
    {
        if (richTextBox2.InvokeRequired)
            richTextBox2.Invoke(() => AppendClientLog(msg));
        else
        {
            richTextBox2.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
            richTextBox2.ScrollToCaret();
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Không cần xử lý gì, bỏ trống
    }

    private void tabPage2_Click(object sender, EventArgs e)
    {
        // Không cần xử lý gì, bỏ trống
    }

    private void label11_Click(object sender, EventArgs e)
    {
        // Không cần xử lý gì, bỏ trống
    }

    private void label1_Click(object sender, EventArgs e)
    {
        // Không cần xử lý gì, bỏ trống
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Không cần xử lý gì, bỏ trống
    }
}