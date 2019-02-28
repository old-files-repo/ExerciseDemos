using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkFlowCoreTest_AskForLeave.Models;
using WorkFlowCoreTest_AskForLeave.WorkFlows;

namespace WorkFlowCoreTest_AskForLeave
{
    public partial class AskForLeave : Form
    {
        private readonly IWorkflowHost _workflowHost;
        private string _departmentApprovalEventKey = "0";
        private string _companyApprovalEventKey = "0";
        private string _userEditEventKey = "0";

        public AskForLeave()
        {
            InitializeComponent();
            infoText.Text = "点击开始启动 workflow host";

            var serviceProvider = ConfigureServices();
            _workflowHost = serviceProvider.GetService<IWorkflowHost>();
            _workflowHost.RegisterWorkflow<AskForLeaveWorkflow, AskForLeaveData>();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _workflowHost.Start();

            infoText.Text = "启动 workflow host";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _workflowHost.Stop();

            infoText.Text = "关闭 workflow host";
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            var askForLeaveData = new AskForLeaveData
            {
                AskForLeaveInfo = new AskForLeaveInfo
                {
                    Name = nameText.Text,
                    StartTime = startTimePicker.Value,
                    EndTime = endTimePicker.Value,
                    ApplyDate = DateTime.Now,
                    Reason = reasonText.Text
                },
                AskForLeaveState = AskForLeaveState.DepartmentWaited,
                DepartmentApprovalEventKey = _departmentApprovalEventKey,
                CompanyApprovalEventKey = _companyApprovalEventKey,
                UserEditEventKey = _userEditEventKey
            };

            _workflowHost.StartWorkflow("AskForLeave", askForLeaveData);

            infoText.Text = $"{nameText.Text}提交请假申请，启动 ask for leave workflow\r\n" +
                            $"时间：{startTimePicker.Text}至{endTimePicker.Text}\r\n" +
                            $"原因：{reasonText.Text}\r\n" +
                            $"申请日期：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n" +
                            $"等待部门审批";
        }

        private void departmentApplyButton_Click(object sender, EventArgs e)
        {
            var nextEventKey = (int.Parse(_departmentApprovalEventKey) + 1).ToString();
            var departmentApprovalEventModel = new DepartmentApprovalEventModel
            {
                DepartmentApprovalInfo = new ApprovalInfo
                {
                    Name = departmentNameText.Text,
                    ApprovalState = departmentStateSelect.SelectedIndex == 0
                        ? ApprovalState.Approved
                        : ApprovalState.Denied,
                    Remark = departmentRemarkText.Text,
                    ApprovalDate = DateTime.Now
                },
                DepartmentApprovalEventKey = nextEventKey
            };

            _workflowHost.PublishEvent("DepartmentApprovalEvent", _departmentApprovalEventKey, departmentApprovalEventModel);
            _departmentApprovalEventKey = nextEventKey;

            infoText.Text = $"部门审批结果：{departmentStateSelect.Text}\r\n" +
                            $"审批人：{departmentNameText.Text}\r\n" +
                            $"备注：{departmentRemarkText.Text}\r\n" +
                            $"审批日期：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n\r\n";

            if (departmentStateSelect.SelectedIndex == 0)
            {
                var timeDiff = endTimePicker.Value - startTimePicker.Value;
                var totalDays = timeDiff.TotalDays;

                if (totalDays > 3)
                {
                    infoText.Text += "请假超过3天，等待公司审批";
                }
                else
                {
                    infoText.Text += "请假少于3天，请假通过";
                }
            }
            else
            {
                infoText.Text += "请假不通过，等待确认是否修改";
            }
        }

        private void companyApplyButton_Click(object sender, EventArgs e)
        {
            var nextEventKey = (int.Parse(_companyApprovalEventKey) + 1).ToString();
            var companyApprovalEventModel = new CompanyApprovalEventModel
            {
                CompanyApprovalInfo = new ApprovalInfo
                {
                    Name = companyNameText.Text,
                    ApprovalState = companyStateSelect.SelectedIndex == 0
                        ? ApprovalState.Approved
                        : ApprovalState.Denied,
                    Remark = companyRemarkText.Text,
                    ApprovalDate = DateTime.Now
                },
                CompanyApprovalEventKey = nextEventKey
            };

            _workflowHost.PublishEvent("CompanyApprovalEvent", _companyApprovalEventKey, companyApprovalEventModel);
            _companyApprovalEventKey = nextEventKey;

            infoText.Text = $"公司审批结果：{companyStateSelect.Text}\r\n" +
                            $"审批人：{companyNameText.Text}\r\n" +
                            $"备注：{companyRemarkText.Text}\r\n" +
                            $"审批日期：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n\r\n";

            if (companyStateSelect.SelectedIndex == 0)
            {
                infoText.Text += "请假通过";
            }
            else
            {
                infoText.Text += "请假不通过，等待确认是否修改";
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var nextEventKey = (int.Parse(_userEditEventKey) + 1).ToString();
            var userEditEventModel = new UserEditEventModel
            {
                AskForLeaveInfo = new AskForLeaveInfo
                {
                    Name = nameText.Text,
                    StartTime = startTimePicker.Value,
                    EndTime = endTimePicker.Value,
                    ApplyDate = DateTime.Now,
                    Reason = reasonText.Text
                },
                AskForLeaveState = AskForLeaveState.DepartmentWaited,
                UserEditEventKey = nextEventKey
            };

            _workflowHost.PublishEvent("UserEditEvent", _userEditEventKey, userEditEventModel);
            _userEditEventKey = nextEventKey;

            infoText.Text = $"{nameText.Text}修改请假申请\r\n" +
                            $"时间：{startTimePicker.Text}至{endTimePicker.Text}\r\n" +
                            $"原因：{reasonText.Text}\r\n" +
                            $"申请日期：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n" +
                            $"等待部门审批";
        }

        private void giveupButton_Click(object sender, EventArgs e)
        {
            var nextEventKey = (int.Parse(_userEditEventKey) + 1).ToString();
            var userEditEventModel = new UserEditEventModel
            {
                AskForLeaveInfo = new AskForLeaveInfo
                {
                    Name = nameText.Text,
                    StartTime = startTimePicker.Value,
                    EndTime = endTimePicker.Value,
                    ApplyDate = DateTime.Now,
                    Reason = reasonText.Text
                },
                AskForLeaveState = AskForLeaveState.Denied,
                UserEditEventKey = nextEventKey
            };

            _workflowHost.PublishEvent("UserEditEvent", _userEditEventKey, userEditEventModel);
            _userEditEventKey = nextEventKey;

            infoText.Text = $"{nameText.Text}放弃修改请假申请，请假不通过";
        }
    }
}
