using System;
using System.Collections.Generic;
using LeaveWebsite.Controllers;
using LeaveWebsite.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace LeaveWebsite.Workflows
{
    public partial class LeaveWorkflow : IWorkflow<Leave>
    {
        public string Id => "LeaveWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<Leave> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                .Parallel()
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelOne", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.ExamState, step => ExamState.一级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelTwo", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.ExamState, step => ExamState.二级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelThree", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.ExamState, step => ExamState.三级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("Rejected", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.ExamState, step => ExamState.已驳回)
                )
                .Join()
                //.Then<EndLeave>()
                //.Input(step => step.Id, data => data.Id)
                //.Input(step => step.ExamState, data => data.ExamState)
                .EndWorkflow();
        }
    }

    public class LeaveWorkflowJson : WorkflowJson
    {
        public override string Id => "LeaveWorkflow";
        public override int Version => 1;
        public override string DataType => "LeaveWebsite.Workflows.DynamicData, LeaveWebsite";
        public override Step[] Steps { get; set; } =
        {
            new Step
            {
                Id = "MyParallelStep",
                StepType="WorkflowCore.Primitives.Sequence, WorkflowCore",
                Do =new List<Step[]>
                {
                    new Step[]
                    {
                        //new Step
                        //{
                        //    Id= "Branch1.Step1",
                        //    NextStepId= "Branch1.Step2"
                        //},
                        new Step
                        {
                            Id= "Branch1.Step2",
                            StepType= "WorkflowCore.Primitives.WaitFor, WorkflowCore",
                            Inputs= new Event{
                                EventName= "\"ExamedLevelOne\"",
                                EventKey= "data.Workflow.Id",
                                EffectiveDate=DateTime.Now
                            },
                            Outputs =new Process
                            {
                                Data = "data.ExamState",
                                Step = ExamState.一级审批通过.ToString()
                            }
                        }
                    },
                    new Step[]
                    {
                        //new Step
                        //{
                        //    Id= "Branch2.Step1",
                        //    NextStepId= "Branch2.Step2"
                        //},
                        new Step
                        {
                            Id= "Branch2.Step2",
                            StepType= "WorkflowCore.Primitives.WaitFor, WorkflowCore",
                            Inputs= new Event{
                                EventName= "\"ExamedLevelTwo\"",
                                EventKey= "data.Workflow.Id",
                                EffectiveDate=DateTime.Now
                            },
                            Outputs =new Process
                            {
                                Data = "data.ExamState",
                                Step = ExamState.二级审批通过.ToString()
                            }
                        }

                    },
                    new Step[]
                    {
                        //new Step
                        //{
                        //    Id= "Branch3.Step1",
                        //    NextStepId= "Branch3.Step2"
                        //},
                        new Step
                        {
                            Id= "Branch3.Step2",
                            StepType= "WorkflowCore.Primitives.WaitFor, WorkflowCore",
                            Inputs= new Event{
                                EventName= "\"ExamedLevelThree\"",
                                EventKey= "data.Workflow.Id",
                                EffectiveDate=DateTime.Now
                            },
                            Outputs =new Process
                            {
                                Data = "data.ExamState",
                                Step = ExamState.三级审批通过.ToString()
                            }
                        }

                    },
                    new Step[]
                    {
                        //new Step
                        //{
                        //    Id= "Branch4.Step1",
                        //    NextStepId= "Branch4.Step2"
                        //},
                        new Step
                        {
                            Id= "Branch4.Step2",
                            StepType= "WorkflowCore.Primitives.WaitFor, WorkflowCore",
                            Inputs= new Event{
                                EventName= "\"Rejected\"",
                                EventKey= "data.Workflow.Id",
                                EffectiveDate=DateTime.Now
                            },
                            Outputs =new Process
                            {
                                Data = "data.ExamState",
                                Step = ExamState.已驳回.ToString()
                            }
                        }

                    }
                }
            }
        };
    }
}
