using Microsoft.InformationProtectionAndControl;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;

namespace FormFileEncrypt
{
    public partial class FormFileEncrypt : Form
    {
        /* please change these values to run with your 
         * application ID after registering the app in AAD <which is Client ID> and the redirectURI
         * for your application */
        private static string adalAppID = ""; //change this 
        private static string adalRedirectURI = "";  //change this
        private static SafeFileApiNativeMethods.DecryptFlags IPCF_DF_FLAG_DEFAULT = 0;
        private static string msg = "";
        
        IpcAadApplicationId currAppId = new IpcAadApplicationId(adalAppID, adalRedirectURI);
        private static Collection<TemplateInfo> templates = null;
        private static Collection<TemplateIssuer> isser = null;
        public FormFileEncrypt()
        {
            InitializeComponent();
            SafeNativeMethods.IpcInitialize();
            
            btn_fileinfo.Enabled = false;
            btn_info.Enabled = false;
            log.AppendText("請點選連線以開始動作");
           // SafeNativeMethods.IpcSetAPIMode(APIMode.Server);  
           /*        
            try
            {
                SafeNativeMethods.IpcSetApplicationId(currAppId);
                
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Error: " + ex);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }

            }

            SafeNativeMethods.IpcSetStoreName("FFE");*/


        }

        private void getTemplatesBtn_Click(object sender, EventArgs e)
        {
            
                // 表先前已初始化並連結過 RMS Server，故 reset RMSServer 變數為 null，以便重新初始化連結。
                
             templates = null;
             templateListBox.BeginUpdate();
             templateListBox.Items.Clear();
             templateListBox.EndUpdate();




            //SafeNativeMethods.IpcGetTemplateList(null, true, false, false, true, null, null, null);

            templates = SafeNativeMethods.IpcGetTemplateList(null, true, false, false, true, null, null,null);
            if (templates.Count() == 0)
            {
                DialogResult result = MessageBox.Show("Templates did not load. Please check your credentials ");
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }

            }
            else
            {
                clear_log();
                msg = "=========成功連線===========\n";
                log.AppendText(msg);
                templateListBox.Text = "=======請選取一個文件保護範本=======";
                templateListBox.Items.Clear();
            }


            for (int i = 0; i < templates.Count; i++)
            {
                templateListBox.Items.Add(templates.ElementAt(i).Name);
                msg = "取得範本：" + templates.ElementAt(i).Name + "\n";
                log.AppendText(msg);
               
                //MessageBox.Show(templates.ElementAt(i).Name);
            }
            btn_info.Enabled = true;

        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            string content = "";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Multiselect = false;
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog1.Filter = "Office Files (*.docx,*.xlsx,*.pptx)|*.docx;*.xlsx;*.pptx|Text Files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.ShowDialog();
                try
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {

                        filepathBox.Text = openFileDialog1.FileName;
                        btn_fileinfo.Enabled = true;

                    }
                    
                    var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(filepathBox.Text.Trim()); 
                    if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
                    {

                        file_label.Text += "此檔案已加密";
                        ReadEncryptedContent(filepathBox.Text.Trim(), out content);
                        clear_log();
                        log.AppendText(content);
                    }
                    else
                    {
                        file_label.Text += "此檔案尚未加密，可點選加密進行加密";
                        clear_log();
                    }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: selected file has an error" + ex.Message);
                }

            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(filepathBox.Text.Trim());
            if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
            {
                msg = "檔案已被加密 請先解密後再重新加密\n";
                log.AppendText(msg);
                //DialogResult isEncrypted = MessageBox.Show("Selected file is already encrypted \n Please Decrypt the file before encrypting");
                //if (isEncrypted == DialogResult.OK)
                //{
                //    // if you want to decrypt the file before exit then uncomment the following line 
                //    //SafeFileApiNativeMethods.IpcfDecryptFile(filepathBox.Text.Trim(), IPCF_DF_FLAG_DEFAULT, false, false, false, IntPtr.Zero, null, null, null);
                //    Application.Exit();
                //}
                      
            }
            else
            {


                try
                {
                    int templateNum = templateListBox.SelectedIndex;
                    //MessageBox.Show(templateNum.ToString());
                    TemplateInfo selectedTemplateInfo = templates.ElementAt(templateNum);
                    var license = SafeNativeMethods.IpcCreateLicenseFromTemplateId(selectedTemplateInfo.TemplateId);
                    string encryptedFilePath = SafeFileApiNativeMethods.IpcfEncryptFile(filepathBox.Text.Trim(), license, SafeFileApiNativeMethods.EncryptFlags.IPCF_EF_FLAG_DEFAULT, false, false, true, IntPtr.Zero, null);
                    DialogResult result = MessageBox.Show("檔案已加密到: " + encryptedFilePath);
                    if (result == DialogResult.OK)
                    {
                        //Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult error = MessageBox.Show("Error: " + ex);
                    if (error == DialogResult.OK)
                    {
                        //Application.Exit();
                    }

                }

            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(filepathBox.Text.Trim());
            
            if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
            {
                DialogResult isEncrypted = MessageBox.Show("此檔案已加密 \n 點選確定來解密");
                if (isEncrypted == DialogResult.OK)
                {
                  try
                    {
                        string decryptedFilePath=SafeFileApiNativeMethods.IpcfDecryptFile(filepathBox.Text.Trim(), IPCF_DF_FLAG_DEFAULT, false, false, false, IntPtr.Zero, null, null, null);
                        DialogResult result = MessageBox.Show("檔案解密到: \n " + decryptedFilePath);
                    }  
                    catch (Exception ex)
                    {
                        DialogResult error = MessageBox.Show("Error: " + ex);
                        if (error == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                    
                
                }

            }
            else if (checkEncryptionStatus.ToString().ToLower().Contains("decrypted"))
            {
                MessageBox.Show("此檔案已無加密");
            }

        }

        private void FormFileEncrypt_Load(object sender, EventArgs e)
        {

        }

        private void btn_info_Click(object sender, EventArgs e)
        {

            clear_log(); //clear data in log
            string _templateID = "";
            string _info = "";
            int i = 1;
            int j = 1;
           // Term _term;
            Collection<UserRights> userRightsList;
            try
            {
                int templateNum = templateListBox.SelectedIndex;
                TemplateInfo selectedTemplateInfo = templates.ElementAt(templateNum);
                _templateID = selectedTemplateInfo.TemplateId;                
                var license = SafeNativeMethods.IpcCreateLicenseFromTemplateId(selectedTemplateInfo.TemplateId);
                //_term = SafeNativeMethods.IpcGetLicenseValidityTime(license);
                _info += "====================範本資訊內容==========================\n";
                //_info += "\t 有效期： 自 " + _term.From.ToString() + " 開始，可使用" + _term.Duration.TotalDays.ToString() + " 天\r\n";               
                _info += "權限原則範本資訊(Template Info)：\r\n";
                _info += "\t 權限資訊來自範本: " + selectedTemplateInfo.FromTemplate + "\r\n";
                _info += "\t 範本代號: " + _templateID + "\r\n";
                _info += "\t 範本名稱: " + selectedTemplateInfo.Name + "\r\n";
                _info += "\t 範本發行者(RMS Server): " + selectedTemplateInfo.IssuerDisplayName + "\r\n";
                _info += "\t 範本說明：" + selectedTemplateInfo.Description + "\r\n";


                userRightsList = SafeNativeMethods.IpcGetLicenseUserRightsList(license);
                _info += "\t 權限列表：\r\n\t\t 授權人數：" + userRightsList.Count.ToString() + " 人\r\n";
                foreach (var u in userRightsList)
                {
                    _info += "\t\t(" + j.ToString() + ") " + u.UserId + "\r\n";
                    j++;
                    _info += "\t\t 權限：";
                    foreach (var r in u.Rights)
                    {
                        _info += r + ", ";
                        i++;
                        if (i > 6)
                        {
                            _info += "\r\n\t\t";
                            i = 1;
                        }
                    }
                    i = 1;
                    _info = _info.Substring(0, (_info.Length - 1));
                    _info += "\r\n";
                }
                _info += "==========================================================\r\n";



                log.AppendText(_info);
            }catch
            {
                clear_log();
                log.AppendText("error");
            }
            

        }
        private void clear_log()
        {
            log.Clear();
            log.Update();
        }
        public bool ReadEncryptedContent(string inputFile, out string encryptContent)
        {
            
            SafeInformationProtectionKeyHandle _keyHandle = null;
           // RMSServerURL _rmsURLs;
            TemplateInfo _template;
            Collection<UserRights> _rights;
            Term _term;
            byte[] _license;
            int i = 1;
            int j = 1;
            int days;
            string _info = "";


            _info += "=============== 擷取檔案【" + inputFile.Trim() + "】資訊 ===============\r\n";
            _info += "加密狀態：已加密\r\n";


            _license = SafeFileApiNativeMethods.IpcfGetSerializedLicenseFromFile(inputFile.Trim()); // 自加密檔案取得憑證資訊
               
            _keyHandle = SafeNativeMethods.IpcGetKey(_license, false, false, true, this); // // 從憑證中取得加密金鑰之處理指標(非金鑰內容)，  只是它的 pointer。
            _info += "憑證作者: " + SafeNativeMethods.IpcGetSerializedLicenseOwner(_license) + "\r\n"; // 自加密憑證中 取得憑證擁有者資訊
            _info += "加密內容 ID: " +SafeNativeMethods.IpcGetSerializedLicenseContentId(_license,_keyHandle) + "\r\n"; // 自加密憑證中取得憑證內容 ID            
            _info += "金鑰(Key)擁有者: " + SafeNativeMethods.IpcGetKeyUserDisplayName(_keyHandle) + "\r\n"; // 取得加密作者資訊
            _term = SafeNativeMethods.IpcGetSerializedLicenseValidityTime(_license, _keyHandle); // 取得此範本的有效期
            if (_term.From.Year != 1601)
                {
                    _info += "\t 有效期： 自 " + _term?.From.ToString() + " 開始，可使用" +
                   _term?.Duration.TotalDays.ToString() + " 天\r\n";
                }
                else
                {
                    _info += "\t 有效期： 可永久使用。\r\n";
                }

                try
                {
                days = (int)SafeNativeMethods.IpcGetSerializedLicenseIntervalTime(_license, _keyHandle);
                }
                catch
                {
                    days = -1;
                }
            _info += "\t 更新頻率：  " + ((days != -1) ? ("每 "+days.ToString()+"天更新") : ("【未設定】")) +"\r\n";
            
            try
                {
                _template = SafeNativeMethods.IpcGetSerializedLicenseDescriptor(_license, _keyHandle,null); // 得憑證的各項敘述內容
                     _info += "權限原則範本資訊(Template Info)：\r\n";
                    _info += "\t 權限資訊來自範本: " + _template.FromTemplate + "\r\n";
                    _info += "\t 範本代號: " + _template.TemplateId + "\r\n";
                    _info += "\t 範本名稱: " + _template.Name + "\r\n";
                    _info += "\t 範本發行者(RMS Server): " + _template.IssuerDisplayName + "\r\n";
                    _info += "\t 範本說明：" + _template.Description + "\r\n";
                }
                catch
                {
                    _info += "權限原則範本資訊(Template Info)：無 (此檔案由使用者自定之權限原則所加密)\r\n";
                }
                _rights = SafeNativeMethods.IpcGetSerializedLicenseUserRightsList(_license, _keyHandle); // 取得序列化憑證中的使用者權限內容
                 _info += "\t 權限列表：\r\n\t\t 授權人數：" + _rights.Count.ToString() + " 人\r\n";
                foreach (var u in _rights)
                {
                    _info += "\t\t(" + j.ToString() + ") " + u.UserId + "\r\n";
                    
                j++;
                    _info += "\t\t 權限：";
                    foreach (var r in u.Rights)
                    {
                        _info += r + ", ";
                        i++;
                        if (i > 6)
                        {
                            _info += "\r\n\t\t";
                            i = 1;
                        }
                    }
                    i = 1;
                    _info = _info.Substring(0, (_info.Length - 1));
                    _info += "\r\n";
                }
                _keyHandle.Dispose();
                _info += "==================================================\r\n";
                encryptContent = _info;
                return true;
            }

        private void btn_fileinfo_Click(object sender, EventArgs e)
        {
            string content = "";
            file_label.Text = "";
            var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(filepathBox.Text.Trim());
            try
            {
                if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
                {
                    file_label.Text += "此檔案已加密";

                    ReadEncryptedContent(filepathBox.Text.Trim(), out content);
                    clear_log();
                    log.AppendText(content);
                }
                else
                {
                    file_label.Text += "此檔案尚未加密，可點選加密進行加密";                    
                    clear_log();
                    
                }
            }
            catch
            {
                DialogResult error = MessageBox.Show("Error ");
            }
            
        }
        private void btn_info_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btn_info, "請選擇範本以開始動作");
        }
    }

 }

    

