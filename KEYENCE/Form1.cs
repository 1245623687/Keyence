using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCVXLib;
using CVXLib;
using System.Threading;


namespace KEYENCE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //CVXClass cvx=new CVXClass();
            //AxCVX ax = new AxCVX();
            int status = -1;

            //status=ax.Initialize();

            //ax.Address = "192.168.0.10";
            //ax.Port = 08501;


            InitializeComponent();
            //要先初始化CVX控件
            status = axCVX1.Initialize();
            //设置远程连接IP地址
            axCVX1.Address = "192.168.0.10";
            //设置端口号，端口号是连续的3个，取第一个，端口号为与本机的CVX控件端口号相同
            axCVX1.Port = 8502;
            //注册事件
            axCVX1.OnRemoteDesktopUpdated += new AxCVXLib._DCVXEvents_OnRemoteDesktopUpdatedEventHandler(this.AxCVX1_OnRemoteDesktopUpdated);
            axCVX1.OnResultLogDataReceived += new AxCVXLib._DCVXEvents_OnResultLogDataReceivedEventHandler(this.AxCVX1_OnResultLogDataReceived);
            axCVX1.OnResultLogStopped += AxCVX1_OnResultLogStopped;

            axCVX1.OnImageLogDataReceived += AxCVX1_OnImageLogDataReceived;
            axCVX1.OnImageLogStopped += AxCVX1_OnImageLogStopped;

            axCVX1.OnArchivedImageTransferred += AxCVX1_OnArchivedImageTransferred;
            axCVX1.OnFileTransferred += AxCVX1_OnFileTransferred;
            axCVX1.MouseDownEvent += AxCVX1_MouseDownEvent;
            axCVX1.ClickEvent += AxCVX1_ClickEvent;
            axCVX1.DblClick += AxCVX1_DblClick;
            //axCVX1.MouseMoveEvent += AxCVX1_MouseMoveEvent;
            axCVX1.OnCommandFinished += AxCVX1_OnCommandFinished;
            
          

            
        }

        private void AxCVX1_OnCommandFinished(object sender, _DCVXEvents_OnCommandFinishedEvent e)
        {
            //Thread.Sleep(5000);
            string commond = e.command;
            int status = e.state;
           // MessageBox.Show("Asyn is completed");
            //throw new NotImplementedException();
        }

        private void AxCVX1_MouseMoveEvent(object sender, _DCVXEvents_MouseMoveEvent e)
        {
            
            MessageBox.Show("Mouse is moving");
           // throw new NotImplementedException();
        }

        private void AxCVX1_Enter(object sender, EventArgs e)
        {
          //  MessageBox.Show("Entring...");
            //throw new NotImplementedException();
        }

        private void AxCVX1_Move(object sender, EventArgs e)
        {
            MessageBox.Show("Mouse is Moving");
            //throw new NotImplementedException();
        }

        private void AxCVX1_DblClick(object sender, EventArgs e)
        {
          
            MessageBox.Show("Mouse is doubleclicked");

            //throw new NotImplementedException();
        }

        private void AxCVX1_ClickEvent(object sender, EventArgs e)
        {
            
           // MessageBox.Show("Mouse is clicked");
            //throw new NotImplementedException();
        }

        private void AxCVX1_MouseDownEvent(object sender, _DCVXEvents_MouseDownEvent e)
        {
            
            //MessageBox.Show("Mouse is dowm");
            //throw new NotImplementedException();
        }

        private void AxCVX1_OnFileTransferred(object sender, _DCVXEvents_OnFileTransferredEvent e)
        {
            //e.kind=0下载事件，1上传事件
            int kind = e.kind;
            int status = e.state;
            //throw new NotImplementedException();
        }

        private void AxCVX1_OnArchivedImageTransferred(object sender, _DCVXEvents_OnArchivedImageTransferredEvent e)
        {
            int status = e.state;
            throw new NotImplementedException();
        }

        private void AxCVX1_OnImageLogStopped(object sender, _DCVXEvents_OnImageLogStoppedEvent e)
        {
            int status = e.state;
            throw new NotImplementedException();
        }

        private void AxCVX1_OnImageLogDataReceived(object sender, _DCVXEvents_OnImageLogDataReceivedEvent e)
        {
            int status=e.state;
            //e.driveNo代表SD卡号
            int deriveNo = e.driveNo;
            //e.settingNO代表控制器中的程序号
            int settingNO = e.settingNo;
            //conditionType代表控制器中的存图选项0最近一张图，1所有图
            int conditype = e.conditionType;
            int prcCount = e.prcCount;


            //throw new NotImplementedException();
        }

        private void AxCVX1_OnResultLogStopped(object sender, _DCVXEvents_OnResultLogStoppedEvent e)
        {
            int a =e.state;
            bool status = axCVX1.ResultLogStarted;
            // throw new NotImplementedException();
        }

        private void AxCVX1_OnResultLogDataReceived(object sender, _DCVXEvents_OnResultLogDataReceivedEvent e)
        {
           string s= e.dstFile;
            int n = e.driveNo;
            int n1 = e.settingNo;
            //更新最新最新数据，后才能获取最新数据
            axCVX1.UpdateResultLogData();

            double num = 0;
            string str = "";
            //获取远程数据
            axCVX1.GetResultLogData(0, 0, 0,ref str,ref num);
            this.label1.Text = num.ToString();
            axCVX1.GetResultLogData(1, 0, 0, ref str, ref num);
            this.label2.Text = num.ToString();
            axCVX1.GetResultLogData(2, 0, 0, ref str, ref num);
            this.label3.Text = num.ToString();

           bool status = axCVX1.ResultLogStarted;





            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!axCVX1.Connected)
            {
                //建立连接
                axCVX1.Connect();
                //远程控制使能
                axCVX1.EnableRemoteMouseOperation = true;
            }
            else
            {
               // MessageBox.Show("已经链接");
            }

               //查看远程桌面连接状态
            if (!axCVX1.RemoteDesktopStarted)
                //开始远程桌面，远程桌面显示在CVX空间中
                axCVX1.StartRemoteDesktop(0);


        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("fangfa2");
            //throw new System.NotImplementedException();
        }

        bool remotefinished = false;
        private void AxCVX1_OnRemoteDesktopUpdated(object sender, _DCVXEvents_OnRemoteDesktopUpdatedEvent e)
        {
            int a = e.state;
            if (a == 0)
            {
                remotefinished = true;
            }
            //throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //查看远程网络连接状态
            bool b = axCVX1.Connected;
            if (b)
            {
                //断开连接
                axCVX1.Disconnect();
            }
            else
            {
                MessageBox.Show("已经断开链接");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //停止远程连接
            //if (remotefinished)
            //    axCVX1.StopRemoteDesktop();
            //获取远程屏幕截图
            //int a =axCVX1.CaptureRemoteDesktop("D:\\Image\\MyImage.bmp");
            //清空本机显示屏幕
            //axCVX1.ClearRemoteDesktop();
            //开始远程数据传输
           int a= axCVX1.StartResultLog(0, "D:\\Image");
            //显示远程数据传输状态
           bool status = axCVX1.ResultLogStarted;

            //要在这个函数出去之后才执行StopResultLog事件
            //a = axCVX1.StopResultLog();
            //Thread.Sleep(10000);
            //status = axCVX1.ResultLogStarted;
            //this.label3.Text = status.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //停止远程数据传输
            int a = axCVX1.StopResultLog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool s = true;
            //显示远程数据传输状态
            s = axCVX1.ResultLogStarted;
            s = axCVX1.Visible;
            string strver = axCVX1.Version;
            axCVX1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string baseFolder = "D:\\Image";
           
            //查看远程图片传输状态
            if(!axCVX1.ImageLogStarted)
            {
                //开始远程图片传输，在控制器中设置输出图片的条件，NG才输出，OK输出，全都输出等等
                int status = axCVX1.StartImageLog(baseFolder);
            }
           

        }

        private void button7_Click(object sender, EventArgs e)
        {

            //查看远程图片传输状态
            if (axCVX1.ImageLogStarted)
            {
                //停止远程图片传输
                int status = axCVX1.StopImageLog();
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int listNum = 0;
            //获取控制器上存储的图像列表，//最新历史图像指全部都存//综合判定为NG只存综合为NG
            //每个相机的历史图像列表数目相同，获取的是单个相机的列表信息
            //指定存档条件编号0或1?
            //参数 conditionNo设置0或1，获取listNum结果不一样，
            //0是指存下的所有图片列表，1存下的NG图片列表
            int status = axCVX1.GetArchivedImageList(0, ref listNum);

            
            int    count = 0;
            int   iscard = 0;
            int  iscom =0;
            DateTime dateTime = new DateTime(2007, 1, 1, 21, 21, 21);

            for ( int index=0; index < listNum; index++)
            {
                //获取控制器上存储的图像列表中的图像信息
                status = axCVX1.GetArchivedImageInfo(index, ref count, ref dateTime, ref iscard, ref iscom);
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool isbusy = axCVX1.ArchivedImageTransferBusy;

            string dstFile = "D:\\cv-x\\history_image.bmp";
            if (!isbusy)
            {
                //传输控制器的中存储的的图像，参数prcCount代表图片的测量计数，与imagelist(已经存储在控制器中的图像)的数目不同。
                //参数captureNo， 啥叫Multi-Capture（多重捕获）？
                //
                axCVX1.GetArchivedImage(1, 124, 2, 0, 0, dstFile, 1);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int status = 0;
            int num = 0;
            status = axCVX1.GetInspectList(ref num);
            int driveNO = 0;
            int settingNO = 0;
            string setname = "";

            status = axCVX1.GetInspectInfo(0, 1, ref driveNO, ref settingNO, ref setname);

            status = axCVX1.GetDictionaryList(ref num);

            status = axCVX1.GetDictionaryInfo(0, ref num);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int listnum = 0;
            int status = 0;
            // status=axCVX1.GetFileList("Drive1:/cv-x/setting/Program setting 1/", ref listnum);
            //获取远程文件列表
            status = axCVX1.GetFileList("SD1:\\cv-x\\setting\\000", ref listnum);

            string name = "";
            short kind=0;
            int attr = 0;
            DateTime dateTime = new DateTime(2007, 1, 1, 21, 21, 21);
            int size = 0;
            for (int index = 0; index < listnum; index++)
            {
                //显示列表中文件信息
                status = axCVX1.GetFileInfo(index, ref name, ref kind, ref attr, ref dateTime, ref size);
            }

            //查看文件传输状态
            bool isbusy = axCVX1.FileTransferBusy;

            string srcFile = "SD1:\\cv-x\\setting\\env.dat";
            string dstFile = "D:\\cv-x\\env.dat";
            //从控制器中下载文件
           // status = axCVX1.DownloadFile(srcFile, dstFile);

            string srcFile2 = "D:\\cv-x\\env.dat";
            string dstFile2 = "SD1:\\cv-x\\setting\\env3.dat";
            //上传文件到控制器中
            status = axCVX1.UploadFile(srcFile2, dstFile2);

            //删除控制器中的文件//删除失败，status=1003
            status = axCVX1.DeleteFile("SD1:\\cv-x\\setting\\env3.dat");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int status = 0;
            string response = "";
            //切换至运行模式
            status= axCVX1.ExecuteCommand("R0", ref response);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int status = 0;
            //异步执行截图，在事件中休眠5秒钟,在事件中休眠会影响主界面
            //status = axCVX1.ExecuteCommandAsync("BC");

            //发送切换程序指令，PW指令，1-SD卡，001-控制器的程序编号
           // status = axCVX1.ExecuteCommandAsync("PW,1,001");
           //获取当前运行的程序信息，
           // status = axCVX1.ExecuteCommandAsync("PR");
           //重启控制器
           // status = axCVX1.ExecuteCommandAsync("RB");
            //全部触发
            status = axCVX1.ExecuteCommandAsync("T1");

            bool isbusy = axCVX1.CommandBusy;
            //while (isbusy)
            //{
            //    this.label4.Text = isbusy.ToString();
            //    isbusy = axCVX1.CommandBusy;
            //}

            this.label4.Text = isbusy.ToString();
            //Thread.Sleep(10000);




        }
    }
}
