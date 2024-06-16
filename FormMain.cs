using DpLib.Helpers;
using DpLib.Models;
using DpLib.Winform;
using DpLib.Winform.Controls;
using EzPayloadSender.Helpers;
using System.Diagnostics;

namespace EzPayloadSender
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        #region EVENTS
        #region BUTTONS
        void ButtonBrowse_Click(object sender, EventArgs e)
        {
            BrowsePayload();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            networkTools.Cancel();
        }
        async void ButtonSend_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Send());
        }
        #endregion
        #region FORM
        void FormMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose();
        }
        #endregion
        private void PictureBoxGitHub_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = "https://github.com/DjPopol/EzPayloadSender",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening page: " + ex.Message);
            }
        }
        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUpdate();
        }
        #region TEXTBOX
        #region IP ADDRESS
        void TextBoxIpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only accept digits, the period, and the backspace key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Limit the total length to 15 characters (maximum for an IPv4 address)
            if (((TextBox)sender).Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void TextBoxIpAddress_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox) return;
            RefreshForm();
        }
        #endregion
        #region PORT
        void TextBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only accept digits and the backspace key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limit the total length to 5 characters (maximum for a port)
            if (((TextBox)sender).Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void TextBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox) return;
            RefreshForm();
        }
        #endregion
        #endregion
        #endregion
        #region FUNCTIONS
        private void AdjustLayout()
        {
            int menuStripHeight = menuStrip1.Height;
            int clientHeight = 0;
            if (menuStrip1.Visible)
            {
                groupBoxConnection.Location = new Point(groupBoxConnection.Location.X, menuStrip1.Location.Y + menuStripHeight + 5);
                clientHeight += menuStripHeight + groupBoxConnection.Height + 10;
            }
            else
            {
                groupBoxConnection.Location = new Point(groupBoxConnection.Location.X, groupBoxConnection.Location.Y - menuStripHeight);
                clientHeight += groupBoxConnection.Height + 5;
            }
            groupBoxBrowse.Location = new Point(groupBoxBrowse.Location.X, groupBoxConnection.Location.Y + groupBoxConnection.Height + 5);
            groupBoxSend.Location = new Point(groupBoxSend.Location.X, groupBoxBrowse.Location.Y + groupBoxBrowse.Height + 5);

            pictureBoxGitHub.Location = new Point(pictureBoxGitHub.Location.X, groupBoxSend.Location.Y + groupBoxSend.Height + 5);
            labelDjPopol.Location = new Point(labelDjPopol.Location.X, groupBoxSend.Location.Y + groupBoxSend.Height + 5);

            clientHeight += groupBoxBrowse.Height + groupBoxSend.Height + pictureBoxGitHub.Height + 15;
            ClientSize = new Size(ClientSize.Width, clientHeight);
            Refresh();
        }
        void BrowsePayload()
        {
            OpenFileDialog opendialog = new()
            {
                CheckFileExists = true,
                Multiselect = false,
                Title = $"Select Payload file",
                Filter = $"Payload BIN File (*.bin)|*.bin",
                InitialDirectory = Tools.MyConfig.PayloadPath,
            };
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                labelPayload.Text = opendialog.SafeFileName;
                Tools.MyConfig.PayloadPathFilename = opendialog.FileName;
            }
            RefreshForm();
        }
        async void Init()
        {
            UpdateManager updateManager = new("https://api.github.com/repos/DjPopol/EzPayloadSender/releases", Tools.GetToken());
            Tools.MyConfig.Load();
            Text = Tools.GetTitle();
            textBoxIpAddress.Text = Tools.MyConfig.IpAdress;
            textBoxPort.Text = $"{Tools.MyConfig.Port}";
            labelPayload.Text = Tools.MyConfig.PayloadFilename;
            SetSendCancelButtonsVisibility(true);
            RefreshForm();
            Version currentVersion = Tools.GetVersion();
            if (await Tools.IsConnectedToInternetAsync())
            {
                latestInfos = await updateManager.GetLastReleaseInfosAsync();
            }
            else
            {
                latestInfos = new();
            }
            bool IsUptoDate = !await Tools.IsConnectedToInternetAsync() || latestInfos.Version == new Version() || latestInfos.Version <= currentVersion;
            menuStrip1.Visible = !IsUptoDate;
            AdjustLayout();
            Console.WriteLine($"DownloadUrl : {latestInfos.DownloadURL}\nVersion : {latestInfos.Version}");

            if (Tools.MyConfig.CheckUpdateOnStartUp && !IsUptoDate)
            {
                ShowUpdate();
            }
        }
        void OnClose()
        {
            if (NetworkTools.IsValidIpAddress(textBoxIpAddress.Text))
            {
                Tools.MyConfig.IpAdress = textBoxIpAddress.Text;
            }
            Tools.MyConfig.Port = int.Parse(textBoxPort.Text);
            Tools.MyConfig.Save();
        }
        void RefreshForm()
        {
            bool isIpAdressOk = NetworkTools.IsValidIpAddress(textBoxIpAddress.Text);
            bool isPortOk = NetworkTools.IsValidPort(textBoxPort.Text);
            bool isPayloadOk = Tools.MyConfig.PayloadPathFilename != string.Empty && File.Exists(Tools.MyConfig.PayloadPathFilename);

            buttonBrowse.Enabled = isIpAdressOk && isPortOk;
            buttonSend.Enabled = isIpAdressOk && isPortOk && isPayloadOk;
        }
        async Task Send()
        {
            SetSendCancelButtonsVisibility(false);
            try
            {
                string result = await networkTools.Connect2PS4Async(textBoxIpAddress.Text, textBoxPort.Text);
                if (result != string.Empty)
                {
                    MessageBox.Show("Error while connecting.\n" + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                await networkTools.SendPayloadAsync(Tools.MyConfig.PayloadPathFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while sending {labelPayload.Text}!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                networkTools.DisconnectPayload();
                MessageBox.Show($"{Tools.MyConfig.PayloadFilename} sent successful!", "Sent Payload", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while disconnecting!\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetSendCancelButtonsVisibility(true);
            RefreshForm();
        }
        public void SetSendCancelButtonsVisibility(bool sendVisible)
        {
            buttonCancel.Visible = !sendVisible;
            buttonSend.Visible = sendVisible;
        }
        async void ShowUpdate()
        {
            if (await Tools.IsConnectedToInternetAsync())
            {
                DpMessageBox messageBox = new($"{latestInfos.Name} is avaible.\nWould you like to update ?", "New Update avaible", MessageBoxButtons.YesNo, MessageBoxIcon.Question, true, Tools.MyConfig.CheckUpdateOnStartUp)
                {
                    CheckBoxText = "Show at startup"
                };
                DialogResult = messageBox.ShowDialog();
                Tools.MyConfig.CheckUpdateOnStartUp = messageBox.CheckBoxChecked;
                Tools.MyConfig.Save();
                if (DialogResult == DialogResult.Yes)
                {
                    // Update
                    DpFormUpdate formUpdate = new(latestInfos, Tools.MyConfig.ShowConsole);
                    formUpdate.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) =>
                    {
                        Enabled = true;
                        Close();
                    });
                    Enabled = false;
                    await Task.Delay(100);
                    formUpdate.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Internet connexion  required !\nYou must connect to internet and restart application", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region PROPERTIES

        readonly NetworkTools networkTools = new();
        ReleaseInfos latestInfos = new();
        #endregion
    }
}
